namespace EasyTradeLibs.Abstractions;

public interface IProducersProvider
{
    IMessageProducer<T> GetProducer<T>();
}