using System;
using UnityEngine;
using BestHTTP.SocketIO3;
using BestHTTP.SocketIO3.Events;

public class SocketConnector
{
    private SocketManager socketManager;

    public SocketConnector(string uri, bool autoConnect = false)
    {
        socketManager = new SocketManager(new Uri(uri), new SocketOptions{AutoConnect = autoConnect});
        Debug.Log($"Initialized socket connector with uri {uri}");
       
        socketManager.Socket.On<ConnectResponse>(SocketIOEventTypes.Connect, OnConnect);
        socketManager.Socket.On(SocketIOEventTypes.Disconnect, OnDisconnect);
        socketManager.Socket.On<string>("message", OnReceiveMessage);
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

    public void Close()
    {
        Debug.Log($"SocketConnector.Close");
        socketManager.Close();
    }

    public void Emit(string message)
    {
        Debug.Log($"SocketConnector.Emit '{message}'");
        socketManager.Socket.Emit("message", message);
    }

    private void OnConnect(ConnectResponse response)
    {
        Debug.Log($"SocketConnector.OnConnected with response socket id: {response.sid}");
    }
    
    private void OnDisconnect()
    {
        Debug.Log($"SocketConnector.OnDisconnected");
    }

    private void OnReceiveMessage(string message)
    {
        Debug.Log($"SocketConnector.OnReceiveMessage '{message}'");
    }
}
