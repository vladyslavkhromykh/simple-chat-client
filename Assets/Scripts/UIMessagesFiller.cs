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
        UIMessage uiMessage = Instantiate(UIMessagePrefab).GetComponent<UIMessage>();
        uiMessage.UpdateUI(message);
        uiMessage.transform.SetParent(UIMesssagesParent);
    }
}
