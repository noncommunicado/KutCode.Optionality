using System.Diagnostics.CodeAnalysis;

namespace KutCode.Optional.Core;

/// <summary>
/// Object, that define optional value state
/// and provides features for easy-handling nullability
/// of value types
/// </summary>
/// <typeparam name="TValue">Type of value (value type)</typeparam>
public readonly struct OptionalValue<TValue> where TValue : struct
{
	private const string EmptyToStringInvocationResult = "null";
	private readonly TValue? _value;
	public OptionalValue([AllowNull] TValue? value) => _value = value;
	
	public static implicit operator TValue?(OptionalValue<TValue> optionalValue) => optionalValue._value;
	public static implicit operator OptionalValue<TValue>(TValue? value) => new(value);
	public static OptionalValue<TValue> None => new(null);
	public bool HasValue => _value is not null;
	public TValue? Value => _value;
	public override string ToString() => _value?.ToString() ?? EmptyToStringInvocationResult;
}