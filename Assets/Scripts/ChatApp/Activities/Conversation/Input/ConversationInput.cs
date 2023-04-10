using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMP_InputField))]
public class ConversationInput : MonoBehaviour, IConversationInput
{
    private TMP_InputField InputField;
    private IMessageSender<string> MessageSender;
    
    private void Awake()
    {
        InputField = GetComponent<TMP_InputField>();
        InputField.onSubmit.AddListener(new UnityAction<string>(OnInputFieldSubmit));
    }

    private void OnInputFieldSubmit(string input)
    {
        OnSubmitMessage?.Invoke(input);
    }

    public event Action<string> OnSubmitMessage;
}