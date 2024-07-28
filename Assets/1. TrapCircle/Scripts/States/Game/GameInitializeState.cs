using Konzit.CasualGame.State;
using Konzit.UI;
using UnityEngine;
using VContainer;

public class GameInitializeState : BaseState
{
    private IStateManager _stateManager;
    private IUIController _uiController;

    public GameInitializeState(IObjectResolver container)
    {
        _stateManager = container.Resolve<IStateManager>();
        _uiController = container.Resolve<IUIController>();
    }

    public override void Initialize()
    {
        Debug.Log("Game Initialize State");
        _uiController.OpenPopupByName(PopupName.MainMenuPopup.ToString());
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
