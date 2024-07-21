using Konzit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameEntryMono : MonoBehaviour
{
    [Inject] private IUIController _uiController;
    
    void Start()
    {
        _uiController.OpenPopupByName(PopupName.MainMenuPopup.ToString());    
    }

}
