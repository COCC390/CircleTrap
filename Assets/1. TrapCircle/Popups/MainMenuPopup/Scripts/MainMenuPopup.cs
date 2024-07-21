using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Konzit.UI;

public class MainMenuPopup : BasePopup
{
    public override void OnShowing()
    {
        
    }

    #region OnClick
    public void OnClickPlayGame()
    {
        Debug.Log("---Start Game By Switch To Game Init State");
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
