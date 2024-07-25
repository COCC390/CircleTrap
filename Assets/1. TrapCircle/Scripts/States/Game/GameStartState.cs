using Konzit.CasualGame.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : BaseState
{
    private IStateManager _stateManager;

    public GameStartState(IStateManager stateManager)
    {
        _stateManager = stateManager;
    }

    public override void Initialize()
    {
        Debug.Log("Game Start State");
    }

}
