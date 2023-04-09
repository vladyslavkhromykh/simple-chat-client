using UnityEngine;

public class MessageView : MonoBehaviour
{
    [SerializeField]
    private StringUnityEvent OnUpdated;
    
    public void UpdateUI(string message)
    {
        OnUpdated?.Invoke(message);
    }
}
