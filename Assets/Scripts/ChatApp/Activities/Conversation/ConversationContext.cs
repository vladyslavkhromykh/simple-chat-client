using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ConversationContext : LifetimeScope
{
    [SerializeField] private ConnectionSettings ConnectionSettings;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(ConnectionSettings);
        builder.Register<ISocketConnector, SocketIOSocketConnector>(Lifetime.Scoped);
        builder.RegisterComponentInHierarchy<ConversationInput>().As<IConversationInput>();
        builder.RegisterComponentInHierarchy< ConversationView>().As<IConversationView>();
        builder.RegisterEntryPoint<Messenger>(Lifetime.Scoped);
        builder.RegisterEntryPoint<ConversationPresenter>(Lifetime.Scoped);
    }
}