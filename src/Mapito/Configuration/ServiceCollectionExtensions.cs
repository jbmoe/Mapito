using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Mapito.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMapito(this IServiceCollection services, Action<IMapitoComponent>? componentConfig = null)
    {
        var component = new MapitoComponent();

        componentConfig?.Invoke(component);

        services
            .Add(component.Services.Values)
            .Add(component.Mappers.Values);

        return services;
    }
}