using System;
using UnityEngine;
using VContainer.Unity;

public class SocketMessageTransporter : IMessageSender<string>, IMessageReceiver, IInitializable, IDisposable
{
    public event Action<string> OnMessageReceived;
    private ISocketConnector SocketConnector;
    
    public void Initialize()
    {
        
    }
    
    public SocketMessageTransporter(ISocketConnector socketConnector)
    {
        SocketConnector = socketConnector;
        SocketConnector.OnMessageReceived += OnMessage;
        SocketConnector.Open();
    }
    
    public void Dispose()
    {
        SocketConnector.OnMessageReceived -= OnMessage;
        SocketConnector.Close();
    }

    public void Send(string message)
    {
        Debug.Log($"SocketMessageTransporter.Send: {message}");
        SocketConnector.Emit(message);
    }

    private void OnMessage(string message)
    {
        Debug.Log($"SocketMessageTransporter.OnMessage: {message}");
        OnMessageReceived?.Invoke(message);
    }
}