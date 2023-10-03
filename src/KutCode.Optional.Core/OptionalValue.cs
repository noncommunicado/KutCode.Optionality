using System.Diagnostics.CodeAnalysis;

namespace KutCode.Optional.Core;

/// <summary>
/// Object, that define optional value state
/// and provides features for easy-handling nullability
/// of value types
/// </summary>
/// <typeparam name="TValue">Type of value (value type)</typeparam>
public struct OptionalValue<TValue> where TValue : struct
{
	private const string EmptyToStringInvocationResult = "null";
	private readonly TValue? _value;
	public OptionalValue([AllowNull] TValue? value) => _value = value;

	public static OptionalValue<TValue> From(TValue? value) => new(value);
	
	public static explicit operator TValue?(OptionalValue<TValue> optionalValue) => optionalValue._value;
	public static explicit operator OptionalValue<TValue>(TValue? value) => new(value);

	public override string ToString() => _value?.ToString() ?? EmptyToStringInvocationResult;
}