using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using VContainer;

public class PlayModeTests
{
    private IMessageSender<string> MessageSender;
    private IMessageReceiver MessageReceiver;
    private IMessageHistoryProvider MessageHistoryProvider;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        PlayModeTestsScope scope = new GameObject("PlayModeTestsScope").AddComponent<PlayModeTestsScope>();
        scope.Container.Inject(this);
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
    public IEnumerator TestThatSentMessageIsEqualToReceivedMessage()
    {
        string testMessage = System.Guid.NewGuid().ToString();
        string receivedMessage = string.Empty;
        
        MessageReceiver.OnMessageReceived += message =>
        {
            receivedMessage = message;
        };
        MessageSender.Send(testMessage);

        yield return new WaitForSeconds(1.0f);
        
        Assert.AreEqual(testMessage, receivedMessage);
    }

    [UnityTest]
    public IEnumerator TestThatHistoryNotEmptyAfterOneSentMessage()
    {
        string testMessage = System.Guid.NewGuid().ToString();
        MessageSender.Send(testMessage);

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