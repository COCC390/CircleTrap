using Konzit.CasualGame.State;
using UnityEngine;
using VContainer;

public class GameInitializeState : BaseState
{
    private IStateManager _stateManager;

    public GameInitializeState(IObjectResolver container)
    {
        _stateManager = container.Resolve<IStateManager>();
    }

    public override void Initialize()
    {
        Debug.Log("Game Initialize State");
        ChangeState(StateName.StartGame);
    }

    public override void Dispose()
    {
        Debug.Log("Game Initialize State Dispose");
    }

    public override void OnState()
    {
        Debug.Log("Game Initialize On State");
    }

    public override void ChangeState(string stateName)
    {
        base.ChangeState(stateName);
        _stateManager.SwitchToState(stateName);
    }
}

public abstract class BaseState : IState
{
    public abstract void Initialize();

    public abstract void OnState();


    public abstract void Dispose();

    public virtual void ChangeState(string stateName)
    {
        Dispose();
    }
}
