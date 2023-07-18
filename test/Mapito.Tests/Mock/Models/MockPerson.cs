namespace Mapito.Tests.Mock.Models;

public class MockPerson
{
    public MockPerson(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }
}