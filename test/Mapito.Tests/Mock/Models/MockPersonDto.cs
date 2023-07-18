namespace Mapito.Tests.Mock.Models;

public class MockPersonDto
{
    public MockPersonDto(string fullName)
    {
        FullName = fullName;
    }

    public string FullName { get; set; }
}