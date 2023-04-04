using EasyTradeLibs.Validation;

namespace EasyTradeLibs.Abstractions;

public interface IValidationOptionsProvider
{
    Dictionary<Type, ValidationOptions> Get();
}