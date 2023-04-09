using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ConversationContext : LifetimeScope
{
    [SerializeField] private ConnectionSettings ConnectionSettings;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<KeyboardInput>().As<IUserInput>();
        builder.RegisterComponentInHierarchy<ConversationView>().AsImplementedInterfaces();
        builder.RegisterInstance(ConnectionSettings);
        builder.Register<ISocketConnector, SocketIOSocketConnector>(Lifetime.Scoped);
        builder.RegisterEntryPoint<Messenger>(Lifetime.Scoped);
        builder.RegisterEntryPoint<UserInputReceiver>(Lifetime.Scoped);
        builder.RegisterEntryPoint<ConversationUpdater>(Lifetime.Scoped);
    }
}