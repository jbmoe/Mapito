using Mapito.Api.Mappers;
using Mapito.Tests.Mock.Models;

namespace Mapito.Tests.Mock.Mappers;

public class MockPersonDtoMapper : IMapper<MockPersonDto, MockPerson>
{
    public Task<MockPerson> Map(MockPersonDto source)
    {
        return Task.FromResult(new MockPerson(
            source.FullName.Split(" ").First(),
            source.FullName.Split(" ").Last()));
    }
}