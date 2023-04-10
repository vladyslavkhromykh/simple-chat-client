using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MessengerServiceTestsContext : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        ConnectionSettings connectionSettings = Resources.Load("ConnectionSettings/DevelopmentConnectionSettings") as ConnectionSettings;
        builder.RegisterInstance(connectionSettings);
        builder.Register<ISocketConnector, SocketIOSocketConnector>(Lifetime.Scoped);
        builder.Register<Messenger>(Lifetime.Scoped).AsImplementedInterfaces();
    }
}
