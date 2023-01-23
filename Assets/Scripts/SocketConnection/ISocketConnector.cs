using System;

public interface ISocketConnector
{
    public event Action<string> OnMessageReceived;
    public void Open();
    public void Close();
    public void Emit(string eventName, params object[] args);
}
