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

    public void OnConnect(ConnectResponse response)
    {
        Debug.Log($"SocketConnector.OnConnected with response socket id: {response.sid}");
    }
    
    public void OnDisconnect()
    {
        Debug.Log($"SocketConnector.OnDisconnected");
    }
}
