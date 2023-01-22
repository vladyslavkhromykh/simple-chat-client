using TMPro;
using UnityEngine;
using UnityEngine.Events;
using VContainer;

[RequireComponent(typeof(TMP_InputField))]
public class UIInputField : MonoBehaviour
{
    private TMP_InputField InputField;
    private IMessageSender<string> MessageSender;
    
    [Inject]
    private void Construct(IMessageSender<string> messageSender)
    {
        MessageSender = messageSender;
    }

    private void Awake()
    {
        InputField = GetComponent<TMP_InputField>();
        InputField.onSubmit.AddListener(new UnityAction<string>(OnInputFieldSubmit));
    }

    private void OnInputFieldSubmit(string input)
    {
        MessageSender.Send(input);
    }
}