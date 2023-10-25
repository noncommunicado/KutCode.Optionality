
namespace KutCode.Optionality.Tests;

[TestFixture]
public sealed class FallbackTests
{
	[Test]
	public void Fallback_RefType()
	{
		var opt = Optional.From<ReferenceTypeForTests>(null);
		Assert.IsFalse(opt.HasValue);
		var fallback = new ReferenceTypeForTests {Age = 22};
		Assert.IsTrue(opt.Fallback(fallback).Age == fallback.Age);
		Assert.That(fallback, Is.SameAs(opt.Fallback(fallback)));
	}
	
	[Test]
	public void Fallback_ValueType()
	{
		var opt = Optional.From<ValueTypeForTests>(null);
		Assert.IsFalse(opt.HasValue); 
		var fallback = new ValueTypeForTests {Age = 22};
		Assert.IsTrue(opt.Fallback(fallback).Age == fallback.Age);
		Assert.That(Equals(fallback, opt.Fallback(fallback)));
	}
}