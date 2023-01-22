public interface IMessageSender<T>
{
    public void Send(T message);
}