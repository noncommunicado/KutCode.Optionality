using System.Text.Json;

namespace KutCode.Optionality.Tests.Json;

/// <summary>
/// <see cref="Optional{TValue}"/> convert Object to JSON string tests
/// </summary>
[TestFixture] 
public sealed class Optional_JsonSerialization_Value_Tests
{
	[Test]
	public void SimpleObject_Serialization_ValidString()
	{
		var optionalObject = Optional.From<ValueTypeForTests>(ValueTypeForTests.GetJohnDoe());
		var jsonResult = JsonSerializer.Serialize(optionalObject);
		Assert.IsTrue(jsonResult == ValueTypeForTests.Json);
	}
	
	[Test]
	public void SimpleObject_Deserialization_ValidObject()
	{
		var result = JsonSerializer.Deserialize<OptionalValue<ValueTypeForTests>>(ValueTypeForTests.Json);
		Assert.IsTrue(result.HasValue);
		Assert.IsTrue(result.Value.Age == ReferenceTypeForTests.GetJohnDoe().Age);
		Assert.IsTrue(result.Value.FirstName == ReferenceTypeForTests.GetJohnDoe().FirstName);
		Assert.IsTrue(result.Value.LastName == ReferenceTypeForTests.GetJohnDoe().LastName);
	}
}