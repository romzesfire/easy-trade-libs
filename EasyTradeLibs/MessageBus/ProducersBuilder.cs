using EasyTradeLibs.Abstractions;

namespace EasyTradeLibs.MessageBus;

public class ProducersBuilder : IProducersBuilder
{
    private IDictionary<string, string> _config;
    private List<IMessageProducer> Producers { get; set; }
    
    public ProducersBuilder(IDictionary<string, string> config)
    {
        _config = config;
        Producers = new List<IMessageProducer>();
    }

    public IProducersBuilder AddProducer<T>(string topic) where T: class 
    {
        Producers.Add(new MessageProducer<T>(topic, _config));
        return this;
    }

    public IProducersProvider Build()
    {
        return new ProducersProvider(Producers);
    }
    
    public void Dispose()
    {
        Producers.ForEach(h=>h.Dispose());
    }
}
