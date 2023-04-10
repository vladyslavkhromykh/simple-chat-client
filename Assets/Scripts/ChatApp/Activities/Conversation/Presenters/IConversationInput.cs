using System;

public interface IConversationInput
{
    event Action<string> OnSubmitMessage;
}