using UnityEngine;

public class MessageView : MonoBehaviour
{
    public StringUnityEvent OnMessageUpdate;
    
    public void UpdateView(string message)
    {
        OnMessageUpdate?.Invoke(message);
    }
}
