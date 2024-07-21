using Konzit.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        Debug.Log("Run on this");
        builder.RegisterComponentInHierarchy<UIControllerView>();
        builder.Register<IUIController, UIController>(Lifetime.Singleton);
        builder.RegisterEntryPoint<GameEntry>(Lifetime.Singleton);
    }
}
