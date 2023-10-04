
namespace KutCode.Optional.Core.Tests;

[TestFixture]
public sealed class ImplicitTypeConversionTests
{
	[Test]
	public void FromRefObject_ToOptional()
	{
		ReferenceTypeForTests obj = new();
		InputOptionalRef(obj);
		Assert.Pass();
	}
	
	[Test]
	public void FromOptional_ToRefObject()
	{
		Optional<ReferenceTypeForTests> obj = new();
		InputObjectRef(obj);
		Assert.Pass();
	}
	
	[Test]
	public void FromValueObject_ToOptional()
	{
		ValueTypeForTests obj = new();
		InputOptionalValue(obj);
		Assert.Pass();
	}
	
	[Test]
	public void FromOptional_ToValueObject()
	{
		OptionalValue<ValueTypeForTests> obj = new();
		InputObjectValue(obj);
		Assert.Pass();
	}
	
	private void InputOptionalRef(Optional<ReferenceTypeForTests> optional) { }
	private void InputObjectRef(ReferenceTypeForTests? classObject) { }
	private void InputOptionalValue(OptionalValue<ValueTypeForTests> optional) { }
	private void InputObjectValue(ValueTypeForTests? structObject) { }
}