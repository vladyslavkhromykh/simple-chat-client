using System;
using UnityEngine;
using VContainer.Unity;

public class SocketSocketMessageTransporter : IMessageSender<string>, IMessageReceiver, ISocketMessageTransporter, IInitializable
{
    private SocketConnector SocketConnector;
    public event Action<string> OnReceiveMessage;

    public void Initialize()
    {
        
    }
    
    public SocketSocketMessageTransporter()
    {
        SocketConnector = new SocketConnector(SocketUriType.LocalHost);
        SocketConnector.Open();
    }
    
    public void Send(string message)
    {
        SocketConnector.Emit(message);
    }

    public void ReceiveMessage(string message)
    {
        Debug.Log($"OnReceiveMessage '{message}'");
        OnReceiveMessage?.Invoke(message);
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