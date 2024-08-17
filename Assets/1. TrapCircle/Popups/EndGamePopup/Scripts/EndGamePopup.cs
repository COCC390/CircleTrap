using Konzit.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePopup : BasePopup
{
    //text
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _highestScore;

    public override void OnShow()
    {
        base.OnShow();

        if (_parameter != null)
        {
            var score= (int)_parameter;
            _score.text = score.ToString();
        }

        //_highestScore.text = GameModel.Score;
    }

    #region OnClick
    public void OnClickReplayGame()
    {
        var currentSceneIndex = SceneManager.GetSceneByName("GameScene");
        SceneManager.UnloadSceneAsync(currentSceneIndex);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void OnClickHighScores()
    {
        Debug.Log($"<color=yellow>HighScores feature is comming soon!!</color>");
    }

    public void OnClickHomeScene()
    {
        var currentSceneIndex = SceneManager.GetSceneByName("GameScene");
        SceneManager.UnloadSceneAsync(currentSceneIndex);
    }
    #endregion
}
