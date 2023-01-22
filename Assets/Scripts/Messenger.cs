using System;
using UnityEngine;
using VContainer.Unity;

public class Messenger : IMessageSender<string>, IMessageReceiver, IInitializable, IDisposable
{
    public event Action<string> OnMessageReceived;
    private ISocketConnector SocketConnector;

    public void Initialize()
    {
        
    }
    
    public Messenger(ISocketConnector socketConnector)
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
        Debug.Log($"Messenger.Send: {message}");
        SocketConnector.Emit(message);
    }

    private void OnMessage(string message)
    {
        Debug.Log($"Messenger.OnMessage: {message}");
        OnMessageReceived?.Invoke(message);
    }
}