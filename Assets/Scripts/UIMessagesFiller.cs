using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class UIMessagesFiller : MonoBehaviour
{
    private IMessageReceiver MessageReceiver;
    
    [Inject]
    private void Construct(IMessageReceiver messageReceiver)
    {
        MessageReceiver = messageReceiver;
        Debug.Log($"UIMessagesFiller construct with " + MessageReceiver);
    }

    private void Awake()
    {
        MessageReceiver.OnMessageReceived += OnMessageReceived;
    }

    private void OnMessageReceived(string message)
    {
        
    }
}
