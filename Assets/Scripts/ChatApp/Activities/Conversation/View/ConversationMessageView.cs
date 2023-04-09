using UnityEngine;

public class ConversationMessageView : MonoBehaviour
{
    [SerializeField]
    private StringUnityEvent OnUpdated;
    
    public void UpdateUI(string message)
    {
        OnUpdated?.Invoke(message);
    }
}
