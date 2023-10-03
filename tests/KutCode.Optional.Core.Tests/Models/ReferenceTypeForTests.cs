namespace KutCode.Optional.Core.Tests.Models;

public sealed class ReferenceTypeForTests
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }

	public static ReferenceTypeForTests GetJohnDoe() => new()
	{
		FirstName = "John",
		LastName = "Doe",
		Age = 21
	};
}