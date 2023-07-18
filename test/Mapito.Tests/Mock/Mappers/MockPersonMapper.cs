using Mapito.Api.Mappers;
using Mapito.Tests.Mock.Models;

namespace Mapito.Tests.Mock.Mappers;

public class MockPersonMapper : IMapper<MockPerson, MockPersonDto>
{
    public Task<MockPersonDto> Map(MockPerson source)
    {
        return Task.FromResult(new MockPersonDto($"{source.FirstName} {source.LastName}"));
    }
}