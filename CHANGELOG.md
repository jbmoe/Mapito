# Mapito - Changelog

All notable changes to the Mapito library will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.2.0-alpha] - 2023-07-27

### Added
- Source link for better debugging experience
- `ServiceLifetime` parameter to `SetMapper` method

## [1.1.0-alpha] - 2023-07-18

### Changed
- Renamed `IMapitoService` to `IMapito`

## [0.1.0-alpha] - 2023-07-18

### Added
- Basic type-to-type mapping functionality.
- Asynchronous mapping support for better performance.
- `IMapitoService` interface for mapping types.
- `IMapper<TSource, TDest>` interface for custom type mapping.
- Convenient extension method `AddMapito` for DI integration.

### Examples
- Added usage examples in the README to help developers get started quickly.

### Documentation
- Detailed API documentation for `IMapito` and `IMapper<TSource, TDest>`.
- Usage instructions and contribution guidelines in the README.
## Note on Alpha Version

Please be aware that Mapito is currently in the alpha stage, which means it's still undergoing early testing and development. As a result, changes may occur in subsequent releases as I refine and improve the library based on user feedback and requirements.

Thank you for choosing Mapito for your type-to-type mapping needs! We hope you find the library useful and easy to integrate into your projects. If you encounter any issues or have ideas for improvements, feel free to open an issue or submit a pull request. Happy coding!