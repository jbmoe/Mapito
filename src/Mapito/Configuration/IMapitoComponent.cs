﻿using Mapito.Api.Mappers;
using Mapito.Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Mapito.Configuration;

public interface IMapitoComponent
{
    /// <summary>
    /// Sets the <see cref="IMapito"/> implementation used to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the implementation.</typeparam>
    /// <returns>Returns component for chaining.</returns>
    IMapitoComponent SetMapito<T>()
        where T : IMapito;

    /// <summary>
    /// Sets the mapper implementation used to type <typeparamref name="TMapper"/> for handling mapping of type <typeparamref name="TSource"/> to type <typeparamref name="TDest"/>.
    /// </summary>
    /// <param name="lifetime">The lifetime of the mapper, <see cref="ServiceLifetime.Transient"/> by default.</param>
    /// <typeparam name="TSource">The source type to map from.</typeparam>
    /// <typeparam name="TDest">The destination type to map to.</typeparam>
    /// <typeparam name="TMapper">The type of the mapper implementation.</typeparam>
    /// <returns>Returns component for chaining.</returns>
    IMapitoComponent SetMapper<TSource, TDest, TMapper>(ServiceLifetime lifetime = ServiceLifetime.Transient)
        where TSource : class
        where TDest : class
        where TMapper : IMapper<TSource, TDest>;
}