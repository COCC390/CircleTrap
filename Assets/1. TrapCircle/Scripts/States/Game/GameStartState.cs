using Konzit.CasualGame.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameStartState : BaseState
{
    private IStateManager _stateManager;

    public GameStartState()
    {
    }

    public GameStartState(IObjectResolver container)
    {
        _stateManager = container.Resolve<IStateManager>();
    }

    public override void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public override void Initialize()
    {
        Debug.Log("Game Start State");
    }

    public override void OnState()
    {
        throw new System.NotImplementedException();
    }
}
