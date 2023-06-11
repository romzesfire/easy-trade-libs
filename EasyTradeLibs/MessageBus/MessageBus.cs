using Confluent.Kafka;

namespace EasyTradeLibs.MessageBus;

public class MessageBus : IDisposable
{
    private IProducer<Null, string> _producer;
    private IConsumer<Null, string> _consumer;
    
    
    
    
    public void Dispose()
    {
        _producer.Dispose();
        _consumer.Dispose();
    }
}