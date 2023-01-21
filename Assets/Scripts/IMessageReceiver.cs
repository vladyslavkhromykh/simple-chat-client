using System;

public interface IMessageReceiver
{
    public event Action<string> OnMessageReceived;
}