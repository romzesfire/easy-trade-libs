namespace EasyTradeLibs.Abstractions;

internal interface IMessageHandler : IDisposable
{
    internal void Run(CancellationToken token = default(CancellationToken));
}