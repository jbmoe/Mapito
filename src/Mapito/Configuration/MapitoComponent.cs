using Mapito.Api.Mappers;
using Mapito.Api.Services;
using Microsoft.Extensions.DependencyInjection;
#pragma warning disable SA1401

namespace Mapito.Configuration;

public class MapitoComponent : IMapitoComponent
{
    #region Services

    internal enum ServicesEnum
    {
        MappingService,
    }

    internal readonly Dictionary<ServicesEnum, ServiceDescriptor> Services = new()
    {
        [ServicesEnum.MappingService] = ServiceDescriptor.Transient<IMapitoService, Domain.Services.MapitoService>(),
    };

    public IMapitoComponent SetMapitoService<T>()
        where T : IMapitoService
    {
        Services[ServicesEnum.MappingService] = ServiceDescriptor.Describe(typeof(IMapitoService), typeof(T), ServiceLifetime.Transient);
        return this;
    }

    #endregion

    #region Mappers

    internal readonly Dictionary<Tuple<Type, Type>, ServiceDescriptor> Mappers = new();
    public IMapitoComponent SetMapper<TSource, TDest, TMapper>()
        where TSource : class
        where TDest : class
        where TMapper : IMapper<TSource, TDest>
    {
        var mapperTypes = new Tuple<Type, Type>(typeof(TSource), typeof(TDest));

        var serviceDescriptor = ServiceDescriptor.Describe(typeof(IMapper<TSource, TDest>), typeof(TMapper), ServiceLifetime.Transient);

        Mappers.TryAdd(mapperTypes, serviceDescriptor);

        return this;
    }

    #endregion
}