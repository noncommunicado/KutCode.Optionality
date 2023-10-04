namespace KutCode.Optional.Core;

/// <summary>
/// Object, that define optional value state
/// and provides features for easy-handling nullability
/// of reference types 
/// </summary>
/// <typeparam name="TValue">Type of value (reference type)</typeparam>
public readonly struct Optional<TValue> where TValue : class
{
	private const string EmptyToStringInvocationResult = "null";
	private readonly TValue? _value;
	public Optional(TValue? value) => _value = value;

	public static implicit operator TValue?(Optional<TValue> optionalValue) => optionalValue._value;
	public static implicit operator Optional<TValue>(TValue? value) => new(value);
	public static Optional<TValue> None => new(null);
	public bool HasValue => _value is not null;
	public TValue? Value => _value;
	public override string ToString() => _value?.ToString() ?? EmptyToStringInvocationResult;
}