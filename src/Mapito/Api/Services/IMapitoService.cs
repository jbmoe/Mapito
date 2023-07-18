namespace Mapito.Api.Services;

/// <summary>
/// A mapping service for mapping types.
/// </summary>
public interface IMapitoService
{
    /// <summary>
    /// Maps entity of type <typeparamref name="TSource"/> to type <typeparamref name="TDest"/>.
    /// </summary>
    /// <typeparam name="TSource">The source type to map from.</typeparam>
    /// <typeparam name="TDest">The destination type to map to.</typeparam>
    /// <param name="source">Source entity to map from.</param>
    /// <returns>Returns source mapped to destination type.</returns>
    Task<TDest> Map<TSource, TDest>(TSource source);

    /// <summary>
    /// Maps entities of type <typeparamref name="TSource"/> to type <typeparamref name="TDest"/>.
    /// </summary>
    /// <typeparam name="TSource">The source type to map from.</typeparam>
    /// <typeparam name="TDest">The destination type to map to.</typeparam>
    /// <param name="source">Source entities to map from.</param>
    /// <returns>Returns source entities mapped to destination type.</returns>
    Task<IList<TDest>> Map<TSource, TDest>(IEnumerable<TSource> source);
}