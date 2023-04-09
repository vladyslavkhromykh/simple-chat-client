using System;
using VContainer.Unity;

public class UserInputReceiver : IStartable, IDisposable
{
    private IUserInput UserInput;
    private IMessageSender<string> MessageSender;

    public UserInputReceiver(IUserInput userInput, IMessageSender<string> messageSender)
    {
        UserInput = userInput;
        MessageSender = messageSender;
    }
    
    public void Start()
    {
        UserInput.OnSubmitMessage += UserInputOnOnSubmitMessage;
    }
    
    public void Dispose()
    {
        UserInput.OnSubmitMessage -= UserInputOnOnSubmitMessage;
    }

    private void UserInputOnOnSubmitMessage(string message)
    {
        // place for validation/filtering
        
        MessageSender.Send(message);
    }


}