using Konzit.Core.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Konzit.CasualGame.State
{
    public class StateManager<T> : IStateManager
    {
        protected IGenericAdapter<T> _adapter;        
        protected IState _currentState;

        public Dictionary<string,IState> _gameStates;

        public StateManager(IGenericAdapter<T> adapter) 
        {
            _adapter = adapter;
            Initialize();
        }

        #region Interface implement
        public virtual void Initialize() 
        {
            _gameStates = new Dictionary<string, IState>();
        }

        public void SwitchToState(string stateName)
        {
            IState state = GetStateByName(stateName);
            if (state == null) return;
            if (_currentState != null) _currentState.Dispose();

            state.Initialize();
            _currentState = state;
        }

        private IState GetStateByName(string stateName)
        {
            /*
             * Check dictionary -> if it has state name -> return state
             * if it not have any state name -> create instance of state name -> add to dictionary -> return state
             */
            CreateStateByName(stateName);

            if (_gameStates.ContainsKey(stateName)) return _gameStates[stateName];
            return null;
        }

        protected void CreateStateByName(string stateName)
        {
            if (_gameStates.ContainsKey(stateName)) return;
            try
            {
                Type type = Type.GetType(stateName);
                var constructor = type.GetConstructors()[0];
                IState state;
                if(!constructor.GetParameters().Any())
                {
                    state = (IState)constructor.Invoke(null);
                }
                else
                {
                    var parameters = constructor.GetParameters();
                    List<object> modules = new List<object>
                    {
                        _adapter.GetModule()
                    };
                    state = (IState)constructor.Invoke(modules.ToArray());
                }

                _gameStates.Add(stateName, state);
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"<color=yellow>The state with name {stateName} doesn't have define in project, more info: </color> {ex}");
            }
        }

        protected void SimpleCreateStateByName(string stateName)
        {
            if (_gameStates.ContainsKey(stateName)) return;
            try
            {
                //IState state = (IState)Activator.CreateInstance("IState", stateName.ToString());
                Type type = Type.GetType(stateName);
                var state = (IState)Activator.CreateInstance(type);
                _gameStates.Add(stateName, state);
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"<color=yellow>The state with name {stateName} doesn't have define in project, more info: </color> {ex}");
            }
        }
        #endregion
    }

}
