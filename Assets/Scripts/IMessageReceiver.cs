using System;

public interface IMessageReceiver
{
    public void ReceiveMessage(string message);
    public event Action<string> OnReceiveMessage;
}