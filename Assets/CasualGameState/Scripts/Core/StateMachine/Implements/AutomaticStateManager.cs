/*
 * Author: DevDaosi
 * @2024
 * 
 * Using this automatic state manager when you don't need to switch state manual
 * Only create new enum define by extend StateName enum class
 * And write name of enum element the same as state class name 
 * 
 * Eg:
 * AnimalState : StateName
 * -
 * Idle,
 * Sit,
 * Walk,
 * Eat,
 * ...
 * - 
 * 
 * class Idle();
 * class Sit();
 * class Walk();
 * class Eat();
 * ...
 * 
 */
using Konzit.Core.Adapter;
using System;

namespace Konzit.CasualGame.State
{
    //public class AutomaticStateManager<T> : StateManager where T: Enum
    //{
    //    private Array _allState;
    //    private int _nextState = 0;

    //    public AutomaticStateManager(IGenericAdapter adapter) : base(adapter)
    //    {
    //    }

    //    public override void Initialize() 
    //    { 
    //        base.Initialize();
    //        CreateInstanceOfAllState();
    //    }

    //    #region
    //    private void CreateInstanceOfAllState()
    //    {
    //        _allState = Enum.GetValues(typeof(T));
    //        foreach (var state in _allState)
    //        {
    //            CreateStateByName((string)state);
    //        }
    //    }

    //    public void SwitchToState()
    //    {
    //        if(_allState.Length > 0 && _nextState < _allState.Length)
    //        {
    //            SwitchToState((string)_allState.GetValue(_nextState));
    //            _nextState++;
    //        }
    //    }
    //    #endregion
    //}
}
