using System;
using UnityEngine;
using BestHTTP.SocketIO3;
using BestHTTP.SocketIO3.Events;
using VContainer;

public class SocketConnector
{
    private SocketManager socketManager;
    public Action<string> OnMessageReceived;

    public SocketConnector(string uri)
    {
        socketManager = new SocketManager(new Uri(uri));

        socketManager.Socket.On<ConnectResponse>(SocketIOEventTypes.Connect, OnConnect);
        socketManager.Socket.On(SocketIOEventTypes.Disconnect, OnDisconnect);
        socketManager.Socket.On<string>("message", OnMessage);
    }

    public void Open()
    {
        Debug.Log($"SocketConnector.Open");
        socketManager.Open();
    }

    public void Disconnect()
    {
        Debug.Log($"SocketConnector.Disconnect");
        socketManager.Socket.Disconnect();
    }
    
    private void OnConnect(ConnectResponse response)
    {
        Debug.Log($"SocketConnector.OnConnected with response socket id: {response.sid}");
    }
    
    private void OnDisconnect()
    {
        Debug.Log($"SocketConnector.OnDisconnected");
    }

    public void Close()
    {
        Debug.Log($"SocketConnector.Close");
        socketManager.Close();
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
