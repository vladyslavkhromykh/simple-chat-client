using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class UIMessagesFiller : MonoBehaviour
{
    [SerializeField]
    private UIMessage UIMessagePrefab;
    [SerializeField]
    private RectTransform UIMesssagesParent;
    private IMessageReceiver MessageReceiver;
    private IMessageHistoryProvider MessageHistoryProvider;

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
    
    private void OnDestroy()
    {
        MessageReceiver.OnMessageReceived -= OnMessageReceived;
    }

    private void Start()
    {
        MessageHistoryProvider.GetMessageHistory(OnGetMessageHistory);
    }

    private void InsertMessage(string message)
    {
        UIMessage uiMessage = Instantiate(UIMessagePrefab).GetComponent<UIMessage>();
        uiMessage.UpdateUI(message);
        uiMessage.transform.SetParent(UIMesssagesParent);
    }

    private void OnGetMessageHistory(List<string> history)
    {
        foreach (string message in history)
        {
            InsertMessage(message);
        }
    }


    private void OnMessageReceived(string message)
    {
        InsertMessage(message);
    }
}
