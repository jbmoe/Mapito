using Mapito.Api.Exceptions;
using Mapito.Api.Mappers;
using Mapito.Api.Services;

namespace Mapito.Domain.Services;

public class Mapito : IMapito
{
    private readonly IServiceProvider _serviceProvider;

    public Mapito(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TDest> Map<TSource, TDest>(TSource source)
    {
        if (_serviceProvider.GetService(typeof(IMapper<TSource, TDest>)) is not IMapper<TSource, TDest> mapper)
        {
            throw new MapperNotFoundException(typeof(TSource), typeof(TDest));
        }

        return mapper.Map(source);
    }

    public async Task<IList<TDest>> Map<TSource, TDest>(IEnumerable<TSource> source)
    {
        if (_serviceProvider.GetService(typeof(IMapper<TSource, TDest>)) is not IMapper<TSource, TDest> mapper)
        {
            throw new MapperNotFoundException(typeof(TSource), typeof(TDest));
        }

        var results = await Task.WhenAll(source.Select(mapper.Map));

        return results
            .ToList();
    }
}