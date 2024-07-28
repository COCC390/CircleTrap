using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Konzit.UI;
using Konzit.CasualGame.State;
using UnityEngine.SceneManagement;
using VContainer;

public class MainMenuPopup : BasePopup
{
    private IStateManager _stateManager;
    private IObjectResolver _container;

    private bool _isInited = false;
     
    public override void OnShowing()
    {
        if(_isInited) return;
        UIController uiController = (UIController)_manager;
        _container = uiController.adapter.GetModule();

        _stateManager = _container.Resolve<IStateManager>();
        _isInited = true;
    }

    #region OnClick
    public void OnClickPlayGame()
    {
        Debug.Log("---Start Game By Switch To Game Init State");
        SceneManager.LoadScene(1, LoadSceneMode.Additive);

        _manager.HidePopupByName(PopupName.MainMenuPopup.ToString());
        _stateManager.SwitchToState(StateName.StartGame);
    }

    public void OnClickMusicBtn()
    {
        Debug.Log("---Music On Off");
    }

    public void OnClickSoundBtn()
    {
        Debug.Log("---Sound Effect On Off");
    }

    public void OnClickHighScoreBtn()
    {
        Debug.Log("---Open High Score Popup");
    }
    #endregion
}
