using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using VContainer;

public class PlayModeTests
{
    private IMessageSender<string> MessageSender;
    private IMessageReceiver MessageReceiver;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        PlayModeTestsScope scope = new GameObject("PlayModeTestsScope").AddComponent<PlayModeTestsScope>();
        scope.Container.Inject(this);
        yield return null;
    }

    [Inject]
    public void Construct(IMessageSender<string> messageSender, IMessageReceiver messageReceiver)
    {
        MessageSender = messageSender;
        MessageReceiver = messageReceiver;
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
}