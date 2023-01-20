using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MessageSubmitter : MonoBehaviour
{
    public SocketDebugger SocketDebugger;
    
    [SerializeField]
    private TMP_InputField InputField;

    private void Awake()
    {
        InputField.onSubmit.AddListener(new UnityAction<string>(OnSubmit));
    }

    private void OnSubmit(string message)
    {
        SocketDebugger.Emit(message);
    }
}
