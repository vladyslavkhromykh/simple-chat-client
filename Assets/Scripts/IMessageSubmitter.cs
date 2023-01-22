using System;

public interface IMessageSubmitter
{
    public event Action<string> OnSubmit;
}