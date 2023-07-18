namespace Mapito.Api.Exceptions;

public class MapperNotFoundException : Exception
{
    public MapperNotFoundException(Type sourceType, Type destType, string? message = null)
        : base(message ?? $"Mapper for {sourceType} to {destType} not found.")
    {
    }
}