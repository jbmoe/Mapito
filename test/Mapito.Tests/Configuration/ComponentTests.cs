using AutoFixture;
using Mapito.Api.Mappers;
using Mapito.Api.Services;
using Mapito.Configuration;
using Mapito.Tests.Mock.Mappers;
using Mapito.Tests.Mock.Models;
using Mapito.Tests.Mock.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Mapito.Tests.Configuration;

public class ComponentTests
{
    public class ComponentTestFixture : Fixture
    {
        public IServiceCollection Services { get; set; }

        public ComponentTestFixture()
        {
            Services = new ServiceCollection();
        }
    }

    [Fact]
    public void Component_Configuration_Is_Invoked()
    {
        var fixture = new ComponentTestFixture();

        var invoked = false;

        fixture.Services.AddMapito(_ =>
        {
            invoked = true;
        });

        Assert.True(invoked);
    }

    [Fact]
    public void Component_Set_Mapito()
    {
        var fixture = new ComponentTestFixture();

        // Add component
        fixture.Services.AddMapito(mapito =>
        {
            mapito.SetMapito<MockMapito>();
        });

        var serviceProvider = fixture.Services.BuildServiceProvider();

        Assert.IsType<MockMapito>(serviceProvider.GetService<IMapito>());
    }

    [Fact]
    public void Component_Set_Mapper()
    {
        var fixture = new ComponentTestFixture();

        // Add component
        fixture.Services.AddMapito(mapito =>
        {
            mapito.SetMapper<MockPerson, MockPersonDto, MockPersonMapper>();
        });

        var serviceProvider = fixture.Services.BuildServiceProvider();

        Assert.IsType<MockPersonMapper>(serviceProvider.GetService<IMapper<MockPerson, MockPersonDto>>());
    }
}