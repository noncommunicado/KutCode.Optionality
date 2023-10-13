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
	
	/// <summary>
	/// Is internal init-only set value of <see cref="TValue"/> type is not null
	/// </summary>
	public bool HasValue => _value is not null;
	
	/// <summary>
	/// Get value if it's existed.<br/>
	/// Throws <see cref="NullReferenceException"/> if value wasn't set.<br/>
	/// Highly recommended to use <see cref="HasValue"/> first.
	/// </summary>
	/// <exception cref="NullReferenceException">Throws if value wasn't set</exception>
	public TValue? Value => _value;
	
	/// <summary>
	/// Produce <see cref="ToString"/> call result of <see cref="TValue"/> object.<br/>
	/// </summary>
	/// <returns>If <see cref="TValue"/> object is null - returns <b>"null"</b> as string.</returns>
	public override string ToString() => _value?.ToString() ?? EmptyToStringInvocationResult;
}