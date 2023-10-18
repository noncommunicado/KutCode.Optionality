namespace KutCode.Optional.Core.Tests.Models;

public struct ValueTypeForTests
{
	public const string Json = """{"FirstName":"John","LastName":"Doe","Age":21}""";
	
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }

	public static ValueTypeForTests GetJohnDoe() => new()
	{
		FirstName = "John",
		LastName = "Doe",
		Age = 21
	};
}