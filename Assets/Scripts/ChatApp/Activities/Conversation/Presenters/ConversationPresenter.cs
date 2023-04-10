using System;
using System.Collections.Generic;
using VContainer.Unity;

public class ConversationPresenter : IStartable, IDisposable
{
    private IMessenger Messenger;
    private IConversationView ConversationView;
    private IConversationInput ConversationInput;

    private ConversationPresenter(
        IMessenger messenger,
        IConversationView conversationView,
        IConversationInput conversationInput)
    {
        this.Messenger = messenger;
        this.ConversationView = conversationView;
        this.ConversationInput = conversationInput;
    }

    public void Start()
    {
        this.Messenger.OnMessageReceived += OnMessageReceived;
        this.ConversationInput.OnSubmitMessage += OnSubmitMessage;
        
        this.Messenger.GetMessageHistory(OnGetMessageHistory);
    }

    public void Dispose()
    {
        this.Messenger.OnMessageReceived -= OnMessageReceived;
        this.ConversationInput.OnSubmitMessage -= OnSubmitMessage;
    }

    private void OnSubmitMessage(string message)
    {
        this.Messenger.Send(message);
    }
    
    private void OnMessageReceived(string message)
    {
        ConversationView.AddMessage(message);
    }

    private void OnGetMessageHistory(List<string> history)
    {
        foreach (string message in history)
        {
            OnMessageReceived(message);
        }
    }
}