using System;
using VContainer.Unity;

public class UserInputController : IStartable, IDisposable
{
    private IUserInput UserInput;
    private IMessageSender<string> MessageSender;

    public UserInputController(IUserInput userInput, IMessageSender<string> messageSender)
    {
        UserInput = userInput;
        MessageSender = messageSender;
        UserInput.OnSubmitMessage += UserInputOnOnSubmitMessage;
    }
    
    public void Start()
    {
        
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