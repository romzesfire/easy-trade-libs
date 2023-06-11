using EasyTradeLibs.Abstractions;

namespace EasyTradeLibs.MessageBus;

public class ProducersProvider : IProducersProvider
{
    private IEnumerable<IMessageProducer> _producers;
    
    public ProducersProvider(IEnumerable<IMessageProducer> producers)
    {
        _producers = producers;
    }

    public IMessageProducer<T> GetProducer<T>()
    {
        return _producers.OfType<IMessageProducer<T>>().First();
    }
}