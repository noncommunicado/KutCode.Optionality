using System.Text.Json.Serialization;
using KutCode.Optional.Core.Json;

namespace KutCode.Optional.Core;

/// <summary>
/// Object, that define optional value state
/// and provides features for easy-handling nullability
/// of reference types 
/// </summary>
/// <typeparam name="TValue">Type of value (reference type)</typeparam>
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
	/// Produce default 
	/// </summary>
	public static Optional<TValue> None => _none;
	private static Optional<TValue> _none = new(null);
	
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
	public TValue Value {
		get {
			if (_value is null) throw new NullReferenceException("Value is null");
			return _value;
		}
	}

	/// <summary>
	/// Produce <see cref="ToString"/> call result of <see cref="TValue"/> object.<br/>
	/// </summary>
	/// <returns>If <see cref="TValue"/> object is null - returns <b>"null"</b> as string.</returns>
	public override string ToString() => _value?.ToString() ?? EmptyToStringInvocationResult;
}