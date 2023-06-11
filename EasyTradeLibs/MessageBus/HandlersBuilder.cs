using EasyTradeLibs.Abstractions;

namespace EasyTradeLibs.MessageBus;

public class HandlersBuilder : IHandlerProvider
{
    private IDictionary<string, string> _config;
    private List<IMessageHandler> Handlers { get; set; }
    
    public HandlersBuilder(IDictionary<string, string> config)
    {
        _config = config;
        Handlers = new List<IMessageHandler>();
    }

    public IHandlerProvider AddHandler<T>(string topic, Action<T> action) where T: class 
    {
        Handlers.Add(new MessageHandler<T>(topic, action, _config));
        return this;
    }

    public IHandlersService Build()
    {
        return new HandlersService(Handlers);
    }
    
    public void Dispose()
    {
        Handlers.ForEach(h=>h.Dispose());
    }
}