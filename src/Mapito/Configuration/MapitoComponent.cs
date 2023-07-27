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
        Mapito,
    }

    internal readonly Dictionary<ServicesEnum, ServiceDescriptor> Services = new()
    {
        [ServicesEnum.Mapito] = ServiceDescriptor.Transient<IMapito, Domain.Services.Mapito>(),
    };

    public IMapitoComponent SetMapito<T>()
        where T : IMapito
    {
        Services[ServicesEnum.Mapito] = ServiceDescriptor.Describe(typeof(IMapito), typeof(T), ServiceLifetime.Transient);
        return this;
    }

    #endregion

    #region Mappers

    internal readonly Dictionary<Tuple<Type, Type>, ServiceDescriptor> Mappers = new();
    public IMapitoComponent SetMapper<TSource, TDest, TMapper>(ServiceLifetime lifetime)
        where TSource : class
        where TDest : class
        where TMapper : IMapper<TSource, TDest>
    {
        var mapperTypes = new Tuple<Type, Type>(typeof(TSource), typeof(TDest));

        var serviceDescriptor = ServiceDescriptor.Describe(typeof(IMapper<TSource, TDest>), typeof(TMapper), lifetime);

        Mappers.TryAdd(mapperTypes, serviceDescriptor);

        return this;
    }

    #endregion
}