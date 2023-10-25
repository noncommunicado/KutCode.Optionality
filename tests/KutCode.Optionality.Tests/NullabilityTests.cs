namespace KutCode.Optionality.Tests;

[TestFixture]
public class NullabilityTests
{
	[Test]
	public void Null_Option_Instance_ToString_NotNull_Result__ForReferenceType()
	{
		var value = Optional.From<ReferenceTypeForTests>(null);
		Assert.IsNotNull(value.ToString());
		Assert.IsNotEmpty(value.ToString());
	}
	
	[Test]
	public void Null_Option_Instance_ToString_NotNull_Result__ForValueType()
	{
		var value = Optional.From<ValueTypeForTests>(null);
		Assert.IsNotNull(value.ToString());
		Assert.IsNotEmpty(value.ToString());
	}
}