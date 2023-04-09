using UnityEngine;
using UnityEngine.UI;

public class ConversationView : MonoBehaviour, IConversationView
{
    [SerializeField] private ScrollRect ScrollRect;
    [SerializeField] private MessageView MessageViewPrefab;
    [SerializeField] private RectTransform MessagesParent;

    public void AddMessage(string message)
    {
        Instantiate(MessageViewPrefab, MessagesParent).UpdateUI(message);
        ScrollToBottom();
    }

    public void ScrollToBottom()
    {
        Canvas.ForceUpdateCanvases();
        ScrollRect.verticalNormalizedPosition = 0.0f;
    }
}