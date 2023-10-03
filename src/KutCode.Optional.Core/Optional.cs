using System.Diagnostics.CodeAnalysis;

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
	public Optional([AllowNull] TValue? value) => _value = value;

	public static Optional<TValue> From(TValue? value) => new(value);
	
	public static explicit operator TValue?(Optional<TValue> optionalValue) => optionalValue._value;
	public static explicit operator Optional<TValue>(TValue? value) => new(value);

	public override string ToString() => _value?.ToString() ?? EmptyToStringInvocationResult;
}