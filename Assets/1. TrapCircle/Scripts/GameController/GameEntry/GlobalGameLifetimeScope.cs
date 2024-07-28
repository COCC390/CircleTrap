using Konzit.CasualGame.State;
using Konzit.Core.Adapter;
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
        builder.Register<IGenericAdapter<IObjectResolver>, ServiceToAdapter<IObjectResolver>>(Lifetime.Singleton);
        builder.RegisterComponent(_uiControlView);  
        builder.Register<IUIController, UIController>(Lifetime.Singleton);

        builder.Register<IStateManager, StateManager<IObjectResolver>>(Lifetime.Singleton);
    }
}
