using System;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP.SocketIO3;
using BestHTTP.SocketIO3.Events;

public class SocketIOSocketConnector : ISocketConnector
{
    public event Action<string> OnMessageReceived;
    private SocketManager SocketManager;

    public SocketIOSocketConnector(ConnectionSettings connectionSettings)
    {
        SocketManager = new SocketManager(new Uri(connectionSettings.Uri));
        Debug.Log($"Created SocketIOSocketConnector with uri {connectionSettings.Uri}");

        SocketManager.Socket.On<ConnectResponse>(SocketIOEventTypes.Connect, OnConnect);
        SocketManager.Socket.On(SocketIOEventTypes.Disconnect, OnDisconnect);
        SocketManager.Socket.On<string>("message", OnMessage);
    }

    public void Open()
    {
        Debug.Log($"SocketIOSocketConnector.Open");
        SocketManager.Open();
    }
    
    public void Close()
    {
        Debug.Log($"SocketIOSocketConnector.Close");
        SocketManager.Close();
    }
    
    private void OnConnect(ConnectResponse response)
    {
        Debug.Log($"SocketConnector.OnConnected with response socket id: {response.sid}");
    }
    
    private void OnDisconnect()
    {
        Debug.Log($"SocketConnector.OnDisconnected");
    }

    public void Emit(string eventName, params object[] args)
    {
        SocketManager.Socket.Emit(eventName, args);
    }

    private void OnMessage(string message)
    {
        OnMessageReceived?.Invoke(message);
    }
}
