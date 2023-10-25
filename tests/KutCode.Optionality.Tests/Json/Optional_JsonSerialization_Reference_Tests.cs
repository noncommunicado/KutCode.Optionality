using System.Text.Json;

namespace KutCode.Optionality.Tests.Json;

/// <summary>
/// <see cref="Optional{TValue}"/> convert Object to JSON string tests
/// </summary>
[TestFixture] 
public sealed class Optional_JsonSerialization_Reference_Tests
{
	[Test]
	public void SimpleObject_Serialization_ValidString()
	{
		var optionalObject = Optional.From(ReferenceTypeForTests.GetJohnDoe());
		var jsonResult = JsonSerializer.Serialize(optionalObject);
		Assert.IsTrue(jsonResult == ReferenceTypeForTests.Json);
	}
	
	[Test]
	public void SimpleObject_Deserialization_ValidObject()
	{
		Optional<ReferenceTypeForTests> result = JsonSerializer.Deserialize<Optional<ReferenceTypeForTests>>(ReferenceTypeForTests.Json);
		Assert.IsTrue(result.HasValue);
		Assert.IsTrue(result.Value.Age == ReferenceTypeForTests.GetJohnDoe().Age);
		Assert.IsTrue(result.Value.FirstName == ReferenceTypeForTests.GetJohnDoe().FirstName);
		Assert.IsTrue(result.Value.LastName == ReferenceTypeForTests.GetJohnDoe().LastName);
	}
	
	[Test]
	public void OptionalInOptional_Deserialization_ValidObject()
	{
		var result = JsonSerializer.Deserialize<OptionalValue<Optional<ReferenceTypeForTests>>>(ReferenceTypeForTests.Json);
		Assert.IsTrue(result.HasValue);
		Assert.IsTrue(result.Value.HasValue);
		Assert.IsTrue(result.Value.Value.Age == ReferenceTypeForTests.GetJohnDoe().Age);
		Assert.IsTrue(result.Value.Value.FirstName == ReferenceTypeForTests.GetJohnDoe().FirstName);
		Assert.IsTrue(result.Value.Value.LastName == ReferenceTypeForTests.GetJohnDoe().LastName);
	}

	[Test]
	public void OptionalInOptional_Serialization_ValidObject()
	{
		var optionalObject = Optional.From<Optional<ReferenceTypeForTests>>(Optional.From(ReferenceTypeForTests.GetJohnDoe()));
		var jsonResult = JsonSerializer.Serialize(optionalObject);
		Assert.IsTrue(jsonResult == ReferenceTypeForTests.Json);
	}
}