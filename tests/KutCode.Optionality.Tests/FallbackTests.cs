
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

	[Test]
	public void FallbackCoalesceRefType_NullInput_SuccessFallback()
	{
		var opt = Optional.From<ReferenceTypeForTests>(null);
		Assert.IsFalse(opt.HasValue);
		var fallback = opt.FallbackCoalesce(
			null,
			new ReferenceTypeForTests() {Age = 2},
			new() {Age = 3});
		Assert.IsTrue(fallback.HasValue);
		Assert.IsTrue(fallback.Value!.Age == 2);
	}
	
	[Test]
	public void FallbackCoalesceValueType_NullInput_SuccessFallback()
	{
		var opt = Optional.From<ValueTypeForTests>(null);
		Assert.IsFalse(opt.HasValue);
		var fallback = opt.FallbackCoalesce(
			null,
			new () {Age = 2},
			new() {Age = 3});
		Assert.IsTrue(fallback.HasValue);
		Assert.IsTrue(fallback.Value!.Age == 2);
	}
}