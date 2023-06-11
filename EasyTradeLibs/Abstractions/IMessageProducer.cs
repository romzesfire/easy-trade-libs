namespace EasyTradeLibs.Abstractions;

public interface IMessageProducer : IDisposable
{
    
}
public interface IMessageProducer<T> : IMessageProducer
{
    public void SendMessage(T message);
}