using System.Text.Json.Serialization;
using Confluent.Kafka;
using EasyTradeLibs.Abstractions;
using Newtonsoft.Json;

namespace EasyTradeLibs.MessageBus;

internal class MessageHandler<T>  : IMessageHandler where T: class
{
    private IConsumer<Null, string> _consumer;
    private string _topic;
    private IDictionary<string, string> _config;
    private Action<T> _action;
    
    public MessageHandler(string topic, Action<T> action, IDictionary<string, string> config)
    {
        _topic = topic;
        _config = config;
        _action = action;
    }
    
    public void Run(CancellationToken token = default(CancellationToken))
    {
        var thread = new Thread(() =>
            {
                using (_consumer = new ConsumerBuilder<Null, string>(_config).Build())
                {
                    _consumer.Subscribe(_topic);
                    while (!token.IsCancellationRequested)
                    {
                        try
                        {
                            var result = _consumer.Consume();
                            _action(JsonConvert.DeserializeObject<T>(result.Message.Value));
                        }
                        catch (Exception e)
                        {
                            _consumer.Close();
                        }
                    }
                }
            }
        );
    }

    public void Dispose()
    {
        _consumer.Dispose();
    }
}