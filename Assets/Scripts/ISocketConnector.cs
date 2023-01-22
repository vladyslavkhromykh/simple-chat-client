using System;

public interface ISocketConnector
{
    public void Open();
    public void Close();
    public void Emit(string message);
    public event Action<string> OnMessageReceived;
}
