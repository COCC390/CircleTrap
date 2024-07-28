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
        _uiController.OpenPopupByName(PopupName.MainMenuPopup.ToString());
        _stateManager.SwitchToState(StateName.InitState);
    }

}
