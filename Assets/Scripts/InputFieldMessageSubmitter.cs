using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InputFieldMessageSubmitter : MonoBehaviour, IMessageSubmitter
{
    [SerializeField]
    private TMP_InputField InputField;
    public event Action<string> OnSubmit;

    private void Awake()
    {
        InputField.onSubmit.AddListener(new UnityAction<string>(OnInputFieldSubmit));
    }

    private void OnInputFieldSubmit(string input)
    {
        OnSubmit?.Invoke(input);
    }
}
