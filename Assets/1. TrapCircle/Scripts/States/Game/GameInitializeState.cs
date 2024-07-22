using Konzit.CasualGame.State;
using UnityEngine;

public class GameInitializeState : IState
{
    public void Initialize()
    {
        Debug.Log("Game Initialize State");
    }

    public void ChangeState(string stateName)
    {
        throw new System.NotImplementedException();
    }

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }

   
    public void OnState()
    {
        throw new System.NotImplementedException();
    }
}
