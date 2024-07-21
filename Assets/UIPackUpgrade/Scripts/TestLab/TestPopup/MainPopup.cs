using Konzit.UI;
using UnityEngine;

public class MainPopup : BasePopup
{
    public override void OnShow()
    {
        Debug.Log($"Show main popup {_parameter}");
    }

    public override void OnShowing()
    {
        Debug.Log($"Showing main popup {_parameter}");
    }
}
