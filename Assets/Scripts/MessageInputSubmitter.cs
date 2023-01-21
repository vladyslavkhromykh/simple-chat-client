using TMPro;
using UnityEngine;
using UnityEngine.Events;
using VContainer;

public class MessageInputSubmitter : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField InputField;
    private IMessageSender<string> MessageSender;

    [Inject]
    public void Construct(IMessageSender<string> messageSender)
    {
        MessageSender = messageSender;
        Debug.Log($"Injected {messageSender.GetType()} into MessageInputSubmitter");
    }

    private void Awake()
    {
        InputField.onSubmit.AddListener(new UnityAction<string>(OnSubmit));
    }

    private void OnSubmit(string message)
    {
        MessageSender.Send(message);
    }
}
