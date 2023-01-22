using System;
using UnityEngine;
using VContainer.Unity;

public class SocketMessageTransporter : IMessageSender<string>, IMessageReceiver, IInitializable, IDisposable
{
    public event Action<string> OnMessageReceived;
    private ISocketConnector SocketConnector;
    private IMessageSubmitter MessageSubmitter;
    
    public void Initialize()
    {
        
    }
    
    public SocketMessageTransporter(ISocketConnector socketConnector, IMessageSubmitter messageSubmitter)
    {
        SocketConnector = socketConnector;
        SocketConnector.OnMessageReceived += OnMessage;
        SocketConnector.Open();

        MessageSubmitter = messageSubmitter;
        Debug.Log("MessageSubmitter:"+MessageSubmitter);
        MessageSubmitter.OnSubmit += OnMessageSubmitted;
    }
    
    public void Dispose()
    {
        SocketConnector.OnMessageReceived -= OnMessage;
        SocketConnector.Close();
    }

    private void OnMessageSubmitted(string message)
    {
        Send(message);
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