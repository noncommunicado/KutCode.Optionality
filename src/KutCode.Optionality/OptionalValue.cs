using System.Diagnostics;
using System.Text.Json.Serialization;
using KutCode.Optionality.Json;

namespace KutCode.Optionality;

/// <summary>
/// An object that defines optional value state
/// and provides features for easily handling nullability
/// of value types
/// </summary>
/// <typeparam name="TValue">Type of value (value type)</typeparam>
[DebuggerDisplay("{DebuggerDisplay,nq}")]
[JsonConverter(typeof(OptionalJsonConverterFactory))]
public readonly struct OptionalValue<TValue> where TValue : struct
{
	private const string EmptyToStringInvocationResult = "null";
	private readonly TValue? _value;
	public OptionalValue(TValue? value) => _value = value;

	public static implicit operator TValue?(OptionalValue<TValue> optionalValue) => optionalValue._value;
	public static implicit operator OptionalValue<TValue>(TValue? value) => new(value);
	public static OptionalValue<TValue> None => new(null);

	/// <summary>
	/// Indicates whether the value of <see cref="TValue"/> type is NOT null
	/// </summary>
	public bool HasValue => _value != null;
	
	/// <summary>
	/// Indicates whether the value of <see cref="TValue"/> type is null
	/// </summary>
	public bool IsEmpty => !HasValue;

	/// <summary>
	/// Gets the value if it exists.<br/>
	/// Throws <see cref="NullReferenceException"/> if value wasn't set.<br/>
	/// It's highly recommended to check <see cref="HasValue"/> first.
	/// </summary>
	/// <exception cref="NullReferenceException">Throws if value wasn't set</exception>
	public TValue Value => _value!.Value;
	
	/// <summary>
	/// Returns null if the internal object doesn't have a value<br/>
	/// No exceptions will be thrown
	/// </summary>
	public TValue? NullIfEmpty => _value.HasValue ? _value.Value : null;

	/// <summary>
	/// Returns the result of calling <see cref="ToString"/> on the <see cref="TValue"/> object.<br/>
	/// </summary>
	/// <returns>If the <see cref="TValue"/> object is null - returns <b>"null"</b> as a string.</returns>
	public override string ToString() => _value?.ToString() ?? EmptyToStringInvocationResult;

	/// <summary>
	/// String to display in debugger 
	/// </summary>
	private string DebuggerDisplay => $"OptionalValue: {_value}";
}