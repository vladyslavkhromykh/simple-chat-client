using UnityEngine;

public class UIMessage : MonoBehaviour
{
    [SerializeField]
    private StringUnityEvent OnUpdated;
    
    public void UpdateUI(string message)
    {
        OnUpdated?.Invoke(message);
    }
}
