using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using VContainer;

public class MessengerServiceTests
{
    private IMessageSender<string> MessageSender;
    private IMessageReceiver MessageReceiver;
    private IMessageHistoryProvider MessageHistoryProvider;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        MessengerServiceTestsContext context = new GameObject(nameof(MessengerServiceTestsContext)).AddComponent<MessengerServiceTestsContext>();
        context.Container.Inject(this);
        yield return null;
    }

    [Inject]
    public void Construct(IMessageSender<string> messageSender, IMessageReceiver messageReceiver, IMessageHistoryProvider messageHistoryProvider)
    {
        MessageSender = messageSender;
        MessageReceiver = messageReceiver;
        MessageHistoryProvider = messageHistoryProvider;
    }
    
    [UnityTest]
    public IEnumerator TestThatSentMessageIsReceivedUnderHalfSecond()
    {
        string sentMessage = System.Guid.NewGuid().ToString();
        string receivedMessage = string.Empty;
        
        float messageSendTime = 0.0f;
        float messageReceiveTime = 0.0f;
        
        MessageReceiver.OnMessageReceived += message =>
        {
            receivedMessage = message;
            messageReceiveTime = Time.time;
        };
        messageSendTime = Time.time;
        MessageSender.Send(sentMessage);

        yield return new WaitForSeconds(1.0f);
        Assert.That(() => (messageReceiveTime-messageSendTime) < 0.1f);
    }

    [UnityTest]
    public IEnumerator TestThatSentMessageIsEqualToReceivedMessage()
    {
        string sentMessage = System.Guid.NewGuid().ToString();
        string receivedMessage = string.Empty;
        
        MessageReceiver.OnMessageReceived += message =>
        {
            receivedMessage = message;
        };
        MessageSender.Send(sentMessage);
        
        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual(sentMessage, receivedMessage);
    }

    [UnityTest]
    public IEnumerator TestThatHistoryNotEmptyAfterOneSentMessage()
    {
        string sentMessage = System.Guid.NewGuid().ToString();
        MessageSender.Send(sentMessage);

        yield return new WaitForSeconds(1.0f);

        List<string> messageHistory = null;
        MessageHistoryProvider.GetMessageHistory(history =>
        {
            messageHistory = history;
        });
        
        yield return new WaitForSeconds(1.0f);
        Assert.That(messageHistory is { Count: > 0});
    }
}