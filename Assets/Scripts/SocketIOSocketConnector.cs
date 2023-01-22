using System;
using UnityEngine;
using BestHTTP.SocketIO3;
using BestHTTP.SocketIO3.Events;

public class SocketIOSocketConnector : ISocketConnector
{
    public event Action<string> OnMessageReceived;
    private SocketManager socketManager;

    public SocketIOSocketConnector(string uri)
    {
        socketManager = new SocketManager(new Uri(uri));
        Debug.Log($"Created SocketIOSocketConnector with uri {uri}");

        socketManager.Socket.On<ConnectResponse>(SocketIOEventTypes.Connect, OnConnect);
        socketManager.Socket.On(SocketIOEventTypes.Disconnect, OnDisconnect);
        socketManager.Socket.On<string>("message", OnMessage);
    }

    public void Open()
    {
        Debug.Log($"SocketIOSocketConnector.Open");
        socketManager.Open();
    }
    
    public void Close()
    {
        Debug.Log($"SocketIOSocketConnector.Close");
        socketManager.Close();
    }
    
    private void OnConnect(ConnectResponse response)
    {
        Debug.Log($"SocketConnector.OnConnected with response socket id: {response.sid}");
    }
    
    private void OnDisconnect()
    {
        Debug.Log($"SocketConnector.OnDisconnected");
    }

    public void Emit(string message)
    {
        socketManager.Socket.Emit("message", message);
    }

    private void OnMessage(string message)
    {
        OnMessageReceived?.Invoke(message);
    }
}
