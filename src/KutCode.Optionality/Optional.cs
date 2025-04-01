using System.Diagnostics;
using System.Text.Json.Serialization;
using KutCode.Optionality.Json;

namespace KutCode.Optionality;

/// <summary>
/// An object that defines optional value state
/// and provides features for easily handling nullability
/// of reference types 
/// </summary>
/// <typeparam name="TValue">Type of value (reference type)</typeparam>
[DebuggerDisplay("{DebuggerDisplay,nq}")]
[JsonConverter(typeof(OptionalJsonConverterFactory))]
public readonly struct Optional<TValue>
	where TValue : class
{
	private const string EmptyToStringInvocationResult = "null";
	private readonly TValue? _value;
	public Optional(TValue? value) => _value = value;

	public static implicit operator TValue?(Optional<TValue> optionalValue) => optionalValue._value;
	public static implicit operator Optional<TValue>(TValue? value) => new(value);

	/// <summary>
	/// Returns an empty Optional instance
	/// </summary>
	public static Optional<TValue> None => _none;
	private static Optional<TValue> _none = new(null);

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
	/// May return null if value wasn't set.<br/>
	/// It's highly recommended to check <see cref="HasValue"/> first.
	/// </summary>
	public TValue? Value => _value;

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