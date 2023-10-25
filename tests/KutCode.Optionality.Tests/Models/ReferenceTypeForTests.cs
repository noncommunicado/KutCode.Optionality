namespace KutCode.Optionality.Tests.Models;

public sealed class ReferenceTypeForTests
{
	public const string Json = """{"FirstName":"John","LastName":"Doe","Age":21}""";
	
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