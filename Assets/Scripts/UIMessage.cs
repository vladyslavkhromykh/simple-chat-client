using UnityEngine;

public class UIMessage : MonoBehaviour
{
    public StringUnityEvent OnMessageUpdate;
    
    public void UpdateUI(string message)
    {
        OnMessageUpdate?.Invoke(message);
    }
}
