namespace KutCode.Optional.Core.Tests;

[TestFixture]
public class NullabilityTests
{
	[Test]
	public void Null_Option_Instance_ToString_NotNull_Result__ForReferenceType()
	{
		var value = Optional<ReferenceTypeForTests>.From(null);
		Assert.IsNotNull(value.ToString());
		Assert.IsNotEmpty(value.ToString());
	}
	
	[Test]
	public void Null_Option_Instance_ToString_NotNull_Result__ForValueType()
	{
		var value = OptionalValue<ValueTypeForTests>.From(null);
		Assert.IsNotNull(value.ToString());
		Assert.IsNotEmpty(value.ToString());
	}
}