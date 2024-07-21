using Konzit.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GlobalGameLifetimeScope : LifetimeScope
{
    [Header("Custom Assign Component")]
    [SerializeField] private UIControllerView _uiControlView;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_uiControlView);  
        builder.Register<IUIController, UIController>(Lifetime.Singleton);
    }
}
