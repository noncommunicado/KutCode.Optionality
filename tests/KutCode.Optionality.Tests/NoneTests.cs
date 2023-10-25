
namespace KutCode.Optionality.Tests;

[TestFixture]
public sealed class NoneTests
{
	[Test]
	public void RefNone_Prop()
	{
		Assert.IsFalse(Optional<ReferenceTypeForTests>.None.HasValue);
	}
	[Test]
	public void RefNone_Method()
	{
		Assert.IsFalse(Optional.None<ReferenceTypeForTests>().HasValue);
	}
	
	[Test]
	public void ValueNone_Prop()
	{
		Assert.IsFalse(OptionalValue<ValueTypeForTests>.None.HasValue);
	}
	[Test]
	public void ValueNone_Method()
	{
		Assert.IsFalse(Optional.NoneValue<ValueTypeForTests>().HasValue);
	}
}