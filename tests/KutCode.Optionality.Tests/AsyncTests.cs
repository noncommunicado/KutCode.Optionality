
namespace KutCode.Optionality.Tests;

[TestFixture]
public sealed class AsyncTests
{
	[Test]
	public async Task FromAsync()
	{
		Optional<ReferenceTypeForTests> val = await Optional.FromAsync(Task.FromResult(new ReferenceTypeForTests()));
	}

}