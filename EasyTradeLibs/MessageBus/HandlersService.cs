using EasyTradeLibs.Abstractions;

namespace EasyTradeLibs.MessageBus;

internal class HandlersService : IHandlersService
{
    private List<IMessageHandler> Handlers { get; set; }

    internal HandlersService(List<IMessageHandler> handlers)
    {
        Handlers = handlers;
    }
    
    public void RunAll()
    {
        Handlers.ForEach(h=> h.Run());
    }
}