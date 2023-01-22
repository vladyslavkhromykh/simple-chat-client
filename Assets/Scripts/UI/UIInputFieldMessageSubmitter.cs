using TMPro;
using UnityEngine;
using UnityEngine.Events;
using VContainer;

public class UIInputFieldMessageSubmitter : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField InputField;
    private IMessageSender<string> MessageSender;

    [Inject]
    private void Construct(IMessageSender<string> messageSender)
    {
        MessageSender = messageSender;
    }

    private void Awake()
    {
        InputField.onSubmit.AddListener(new UnityAction<string>(OnInputFieldSubmit));
    }

    private void OnInputFieldSubmit(string input)
    {
        MessageSender.Send(input);
    }
}
