using Mapito.Api.Services;

namespace Mapito.Tests.Mock.Services;

public class MockMapito : IMapito
{
    public Task<TDest> Map<TSource, TDest>(TSource source)
    {
        return Task.FromResult(default(TDest)!);
    }

    public Task<IList<TDest>> Map<TSource, TDest>(IEnumerable<TSource> source)
    {
        return Task.FromResult<IList<TDest>>(new List<TDest>());
    }
}