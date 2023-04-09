using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ChatLifetimeScope : LifetimeScope
{
    [SerializeField]
    private ConnectionSettings ConnectionSettings;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<KeyboardInput>().As<IUserInput>();
        builder.RegisterInstance(ConnectionSettings);
        builder.Register<ISocketConnector, SocketIOSocketConnector>(Lifetime.Scoped);
        builder.RegisterEntryPoint<Messenger>(Lifetime.Scoped);
        builder.RegisterEntryPoint<UserInputController>(Lifetime.Scoped);
    }
}
