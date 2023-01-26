using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ChatSceneLifetimeScope : LifetimeScope
{
    [SerializeField]
    private ConnectionSettings ConnectionSettings;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(ConnectionSettings);
        builder.Register<ISocketConnector, SocketIOSocketConnector>(Lifetime.Scoped);
        builder.RegisterEntryPoint<Messenger>();
    }
}
