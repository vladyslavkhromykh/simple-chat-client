using VContainer;
using VContainer.Unity;

public class ChatSceneLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<SocketSocketMessageTransporter>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
    }
}
