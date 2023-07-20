using AutoFixture;
using Mapito.Api.Exceptions;
using Mapito.Api.Services;
using Mapito.Configuration;
using Mapito.Tests.Mock.Mappers;
using Mapito.Tests.Mock.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Mapito.Tests.Domain.Services;

public class MapitoTests
{
    public class MapitoTestFixture : Fixture
    {
        public IMapito Mapito { get; set; }

        public MapitoTestFixture()
        {
            var services = new ServiceCollection();
            services.AddMapito(mapito =>
            {
                mapito.SetMapper<MockPerson, MockPersonDto, MockPersonMapper>();
            });

            var serviceProvider = services.BuildServiceProvider();

            Mapito = serviceProvider.GetRequiredService<IMapito>();
        }
    }

    [Fact]
    public void Mapper_Map_Not_Found()
    {
        var fixture = new MapitoTestFixture();

        var source = new NullModel();

        Assert.ThrowsAsync<MapperNotFoundException>(() => fixture.Mapito.Map<NullModel, MockPerson>(source));
    }

    [Fact]
    public void Mapper_MapEnumerable_Not_Found()
    {
        var fixture = new MapitoTestFixture();

        var source = new List<NullModel>
        {
            new NullModel(),
            new NullModel(),
            new NullModel(),
        };

        Assert.ThrowsAsync<MapperNotFoundException>(() => fixture.Mapito.Map<NullModel, MockPerson>(source));
    }

    [Fact]
    public async void Mapper_Map_Found()
    {
        var fixture = new MapitoTestFixture();

        var source = new MockPerson("Chris P.", "Bacon");

        MockPersonDto destination = await fixture.Mapito.Map<MockPerson, MockPersonDto>(source);

        Assert.NotNull(destination);
        Assert.IsType<MockPersonDto>(destination);
        Assert.Equal("Chris P. Bacon", destination.FullName);
    }

    [Fact]
    public async void Mapper_MapEnumerable_Found()
    {
        var fixture = new MapitoTestFixture();

        var source = new List<MockPerson>
        {
            new("Gabe", "Itch"),
            new("Ben", "Dover"),
            new("Hugh", "Mungus"),
        };

        var destination = await fixture.Mapito.Map<MockPerson, MockPersonDto>(source);

        Assert.NotNull(destination);
        Assert.Equal(3, destination.Count);
        Assert.Collection(
            destination,
            dto =>
            {
                Assert.IsType<MockPersonDto>(dto);
                Assert.Equal("Gabe Itch", dto.FullName);
            },
            dto =>
            {
                Assert.IsType<MockPersonDto>(dto);
                Assert.Equal("Ben Dover", dto.FullName);
            },
            dto =>
            {
                Assert.IsType<MockPersonDto>(dto);
                Assert.Equal("Hugh Mungus", dto.FullName);
            });
    }
}