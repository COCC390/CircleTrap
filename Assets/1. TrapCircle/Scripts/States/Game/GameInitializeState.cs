using Konzit.CasualGame.State;
using UnityEngine;
using VContainer;

public class GameInitializeState : BaseState
{
    [Inject] private StateManager _stateManager;

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
        throw new System.NotImplementedException();
    }

    public override void ChangeState(string stateName)
    {
        base.ChangeState(stateName);
        _stateManager.SwitchToState(stateName);
    }
}

public class BaseState : IState
{
    public virtual void Initialize()
    {
    }

    public virtual void OnState()
    {
    }

    public virtual void Dispose()
    {
    }

    public virtual void ChangeState(string stateName)
    {
        Dispose();
    }
}
