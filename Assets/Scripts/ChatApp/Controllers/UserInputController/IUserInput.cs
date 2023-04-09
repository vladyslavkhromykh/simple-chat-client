using System;

public interface IUserInput
{
    event Action<string> OnSubmitMessage;
}