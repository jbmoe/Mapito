# Mapito - Simple Type-to-Type Mapping Library

Mapito is a C# library designed to facilitate simple type-to-type mapping in your projects. It provides an easy-to-use interface and DI (Dependency Injection) integration for mapping objects from one type to another.

> **Note:** Parts of this readme file was written with the help of ChatGPT, an AI language model developed by OpenAI.

## Features

- **Type Mapping:** Map entities of type `TSource` to type `TDest`.
- **Asynchronous Mapping:** Asynchronous mapping methods for better performance and scalability.
- **Dependency Injection:** Use Mapito seamlessly with Dependency Injection by using the provided extension method.

## Installation

You can install Mapito via by using the .NET CLI, NuGet Package Manager or PackageReference.

#### .NET CLI

```
> dotnet add package Mapito --version 1.2.0-alpha
```

#### Package Manager Console

```
PM> NuGet\Install-Package Mapito -Version 1.2.0-alpha
```

#### PackageReference

```
<PackageReference Include="Mapito" Version="1.1.0-alpha" />
```
## Getting Started

1. First, install the Mapito library in your project using the installation steps mentioned above.

2. Define your classes or models for which you want to perform the mapping.

3. Create a class that implements the `IMapper<TSource, TDest>` interface to handle the mapping logic for specific types. For example:

```csharp
public class MyModelToDtoMapper : IMapper<MyModel, MyDto>
{
    public async Task<MyDto> Map(MyModel source)
    {
        // Mapping logic here
        // e.g., return new MyDto { ... };
    }
}
```

4. Register your mapper classes with the DI container using the `AddMapito` extension method:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Other service registrations

    // Register Mapito with mappers
    services.AddMapito(config =>
    {
        config.AddMapper<MyModel, MyDto, MyModelToDtoMapper>();
        // Add other mappers as needed
    });
}
```

5. Inject the `IMapito` into your classes where you need to perform the mapping:

```csharp
public class MyClass
{
    private readonly IMapito _mapito;

    public MyClass(IMapito mapito)
    {
        _mapito = mapito;
    }

    public async Task<MyDto> PerformMapping(MyModel source)
    {
        MyDto result = await _mapito.Map<MyModel, MyDto>(source);
        return result;
    }
}
```

6. Enjoy the benefits of seamless type-to-type mapping with Mapito in your projects!

## API Documentation

### IMapito

#### `Task<TDest> Map<TSource, TDest>(TSource source);`

Maps an entity of type `TSource` to type `TDest`.

- `TSource`: The source type to map from.
- `TDest`: The destination type to map to.
- `source`: Source entity to map from.
- Returns: The source entity mapped to the destination type.

#### `Task<IList<TDest>> Map<TSource, TDest>(IEnumerable<TSource> source);`

Maps entities of type `TSource` to type `TDest`.

- `TSource`: The source type to map from.
- `TDest`: The destination type to map to.
- `source`: Source entities to map from.
- Returns: A list of source entities mapped to the destination type.

## Contribution

Contributions to Mapito are welcome! If you encounter any issues or have ideas for improvements, feel free to open an issue or submit a pull request.

## License

Mapito is released under the [MIT License](LICENSE).

---

Thank you for choosing Mapito for your type-to-type mapping needs! If you have any questions or need further assistance, feel free to reach out. Happy coding!

## Note on Alpha Version

Please be aware that Mapito is currently in the alpha stage, which means it's still undergoing early testing and development. As a result, changes may occur in subsequent releases as I refine and improve the library based on user feedback and requirements.