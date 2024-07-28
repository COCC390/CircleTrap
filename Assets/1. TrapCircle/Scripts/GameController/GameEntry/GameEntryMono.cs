using Konzit.CasualGame.State;
using Konzit.UI;
using UnityEngine;
using VContainer;

public class GameEntryMono : MonoBehaviour
{
    [Inject] private IUIController _uiController;
    [Inject] private IStateManager _stateManager;
    
    void Start()
    {
        _stateManager.SwitchToState(StateName.InitState);
    }

}
