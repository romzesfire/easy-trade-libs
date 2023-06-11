using Confluent.Kafka;
using EasyTradeLibs.Abstractions;
using Newtonsoft.Json;

namespace EasyTradeLibs.MessageBus;

public class MessageProducer<T> : IMessageProducer<T>, IDisposable where T: class 
{
    private IProducer<Null, string> _producer;
    private string _topic;
    private IDictionary<string, string> _config;
    
    public MessageProducer(string topic, IDictionary<string, string> config)
    {
        _topic = topic;
        _config = config;
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public void SendMessage(T message)
    {
        _producer.ProduceAsync(_topic, new Message<Null, string>() 
            { Value = JsonConvert.SerializeObject(message) });
    }

    public void Dispose()
    {
        _producer.Dispose();
    }
}

