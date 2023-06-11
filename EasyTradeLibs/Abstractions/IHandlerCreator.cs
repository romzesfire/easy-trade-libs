namespace EasyTradeLibs.Abstractions;

public interface IHandlerProvider : IDisposable
{
    public IHandlerProvider AddHandler<T>(string topic, Action<T> action) where T: class ;
}