using System;
using System.Collections.Generic;
using BestHTTP;
using Newtonsoft.Json;
using UnityEngine;
using VContainer.Unity;

public class Messenger : IMessageSender<string>, IMessageReceiver, IMessageHistoryProvider, IDisposable
{
    public event Action<string> OnMessageReceived;
    private ISocketConnector SocketConnector;
    private Action<List<string>> OnGetMessageHistoryCallback;
    private ConnectionSettings ConnectionSettings;

    public Messenger(ISocketConnector socketConnector, ConnectionSettings connectionSettings)
    {
        ConnectionSettings = connectionSettings;
        
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
        SocketConnector.Emit("message", message);
    }

    private void OnMessage(string message)
    {
        Debug.Log($"Messenger.OnMessage: {message}");
        OnMessageReceived?.Invoke(message);
    }

    public void GetMessageHistory(Action<List<string>> onGetMessageHistory)
    {
        OnGetMessageHistoryCallback = onGetMessageHistory;
        HTTPRequest request = new HTTPRequest(new Uri(ConnectionSettings.Uri + "/getHistory"), HTTPMethods.Get, OnGetMessageHistoryResponse);
        request.Send();
    }

    private void OnGetMessageHistoryResponse(HTTPRequest request, HTTPResponse response)
    {
        List<string> history = JsonConvert.DeserializeObject<List<string>>(response.DataAsText);
        OnGetMessageHistoryCallback?.Invoke(history);
    }
}