using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class ConversationView : MonoBehaviour
{
    private IMessageReceiver MessageReceiver;
    private IMessageHistoryProvider MessageHistoryProvider;
    
    [SerializeField]
    private ConversationMessageView MessageViewPrefab;
    [SerializeField]
    private RectTransform MessagesParent;

    [Inject]
    private void Construct(IMessageReceiver messageReceiver, IMessageHistoryProvider messageHistoryProvider)
    {
        MessageReceiver = messageReceiver;
        MessageHistoryProvider = messageHistoryProvider;
    }

    private void Awake()
    {
        MessageReceiver.OnMessageReceived += OnMessageReceived;
    }
    
    private void Start()
    {
        MessageHistoryProvider.GetMessageHistory(OnGetMessageHistory);
    }
    
    private void OnDestroy()
    {
        MessageReceiver.OnMessageReceived -= OnMessageReceived;
    }
    
    private void PushMessage(string message)
    {
        ConversationMessageView messageView = Instantiate(MessageViewPrefab, MessagesParent);
        messageView.UpdateUI(message);
    }

    private void OnGetMessageHistory(List<string> history)
    {
        foreach (string message in history)
        {
            PushMessage(message);
        }
    }


    private void OnMessageReceived(string message)
    {
        PushMessage(message);
    }
}
