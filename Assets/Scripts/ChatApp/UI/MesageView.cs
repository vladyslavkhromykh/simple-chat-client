using UnityEngine;

public class MesageView : MonoBehaviour
{
    [SerializeField]
    private StringUnityEvent OnUpdated;
    
    public void UpdateUI(string message)
    {
        OnUpdated?.Invoke(message);
    }
}
