using System;
using System.Collections.Generic;
using VContainer.Unity;

public class ConversationUpdater : IStartable, IDisposable
{
    private IMessageReceiver MessageReceiver;
    private IMessageHistoryProvider MessageHistoryProvider;
    private IConversationView ConversationView;

    private ConversationUpdater(IMessageReceiver messageReceiver, IMessageHistoryProvider messageHistoryProvider,
        IConversationView conversationView)
    {
        MessageReceiver = messageReceiver;
        MessageHistoryProvider = messageHistoryProvider;
        ConversationView = conversationView;
    }

    public void Start()
    {
        MessageReceiver.OnMessageReceived += OnMessageReceived;
        MessageHistoryProvider.GetMessageHistory(OnGetMessageHistory);
    }

    public void Dispose()
    {
        MessageReceiver.OnMessageReceived -= OnMessageReceived;
    }

    private void AddMessage(string message)
    {
        ConversationView.AddMessage(message);
    }

    private void OnMessageReceived(string message)
    {
        AddMessage(message);
    }

    private void OnGetMessageHistory(List<string> history)
    {
        foreach (string message in history)
        {
            AddMessage(message);
        }
    }
}