using System;
using VContainer.Unity;

public class SocketSocketMessageTransporter : IMessageSender<string>, IMessageReceiver, ISocketMessageTransporter, IInitializable, IDisposable
{
    private SocketConnector SocketConnector;
    public event Action<string> OnMessageReceived;

    public void Initialize()
    {
        
    }
    
    public SocketSocketMessageTransporter()
    {
        SocketConnector = new SocketConnector(SocketUriType.LocalHost);
        SocketConnector.OnMessageReceived += OnMessage;
        SocketConnector.Open();
    }
    
    public void Dispose()
    {
        SocketConnector.OnMessageReceived -= OnMessage;
    }

    public void Send(string message)
    {
        SocketConnector.Emit(message);
    }

    private void OnMessage(string message)
    {
        OnMessageReceived?.Invoke(message);
    }

    public void Open()
    {
        SocketConnector.Open();
    }

    public void Close()
    {
        SocketConnector.Close();
    }
}