using VContainer;
using VContainer.Unity;

public class ChatSceneLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<InputFieldMessageSubmitter>().AsImplementedInterfaces();
        builder.Register<ISocketConnector, SocketIOSocketConnector>(Lifetime.Scoped).WithParameter<string>(SocketUriType.LocalHost);
        builder.Register<SocketMessageTransporter>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();
    }
}
