using System.Diagnostics.CodeAnalysis;

namespace KutCode.Optionality;

public static class Optional
{
	#region Optional

	/// <summary>
	/// Create Optional instance from value 
	/// </summary>
	/// <param name="value">Object represents TValue type</param>
	/// <typeparam name="TValue">Type of value</typeparam>
	/// <returns>New Optional instance</returns>
	public static Optional<TValue> From<TValue>(TValue? value) where TValue : class
		=> new (value);
	
	/// <summary>
	/// Create <see cref="Optional{TValue}"/> instance from async Task result
	/// </summary>
	/// <param name="task">Task returning TValue</param>
	/// <typeparam name="TValue">Type of value</typeparam>
	/// <returns>New Optional instance</returns>
	public static async Task<Optional<TValue>> FromAsync<TValue>(Task<TValue?> task) where TValue : class
		=> new (await task);
	
	/// <summary>
	/// Returns <see cref="Optional{TValue}.None">Optional{TValue}.None</see> property - represents empty value
	/// </summary>
	public static Optional<TValue> None<TValue>() where TValue : class => Optional<TValue>.None;
	
	/// <summary>
	/// Allows replace Optional value by fallback value if Optional value is null
	/// </summary>
	/// <param name="fallback">Value, which will be returned, if <see cref="Optional{TValue}"/> instance value is null</param>
	/// <returns>Optional value, if it's null, fallback value</returns>
	public static TValue Fallback<TValue>(this Optional<TValue> optionalValue, [NotNull] TValue fallback) where TValue : class
		=> optionalValue.HasValue ? optionalValue! : fallback;

	/// <summary>
	/// Allows replace Optional value by fallback value if Optional value is null
	/// </summary>
	/// <param name="fallbackValues">Values, if Optional instance value is null, will be returned the first not null value.<br/>
	/// </param>
	/// <returns><see cref="Optional{TValue}.None"/> will be returned, if "not null" value isn't presented in fallbacks.</returns>
	public static Optional<TValue> FallbackCoalesce<TValue>(
		this Optional<TValue> optionalValue, params TValue?[] fallbackValues) where TValue : class
	{
		if (optionalValue.HasValue) return optionalValue;
		foreach (var fallback in fallbackValues)
			if (fallback is not null) return fallback;
		return None<TValue>();
	}

	/// <summary>
	/// Executes the specified action if the Optional contains a value
	/// </summary>
	/// <param name="optionalValue">Optional object</param>
	/// <param name="action">Action to perform with the value</param>
	/// <typeparam name="TValue">Type of the value</typeparam>
	/// <returns>The original Optional object for method chaining</returns>
	public static Optional<TValue> IfHasValue<TValue>(this Optional<TValue> optionalValue, Action<TValue> action) 
		where TValue : class
	{
		if (optionalValue.HasValue && action != null)
		{
			action(optionalValue.Value!);
		}
		return optionalValue;
	}

	/// <summary>
	/// Executes the specified action if the Optional does not contain a value
	/// </summary>
	/// <param name="optionalValue">Optional object</param>
	/// <param name="action">Action to perform</param>
	/// <typeparam name="TValue">Type of the value</typeparam>
	/// <returns>The original Optional object for method chaining</returns>
	public static Optional<TValue> IfEmpty<TValue>(this Optional<TValue> optionalValue, Action action) 
		where TValue : class
	{
		if (!optionalValue.HasValue && action != null)
		{
			action();
		}
		return optionalValue;
	}

	/// <summary>
	/// Safely extracts a value from Optional into an out parameter
	/// </summary>
	/// <param name="optionalValue">Optional object</param>
	/// <param name="value">Extracted value, if it exists</param>
	/// <typeparam name="TValue">Type of the value</typeparam>
	/// <returns>true if the value exists, otherwise false</returns>
	public static bool TryGetValue<TValue>(this Optional<TValue> optionalValue, [NotNullWhen(true)] out TValue? value) 
		where TValue : class
	{
		value = optionalValue.Value;
		return optionalValue.HasValue;
	}

	#endregion
	#region OptionalValue

	/// <summary>
	/// Create Optional instance from value 
	/// </summary>
	/// <param name="value">Object represents TValue type</param>
	/// <typeparam name="TValue">Type of value</typeparam>
	/// <returns>New Optional instance</returns>
	public static OptionalValue<TValue> From<TValue>(TValue? value) where TValue : struct
		=> new (value);

	/// <summary>
	/// Create <see cref="OptionalValue{TValue}"/> instance from async Task result
	/// </summary>
	/// <param name="task">Task returning TValue</param>
	/// <typeparam name="TValue">Type of value</typeparam>
	/// <returns>New Optional instance</returns>
	public static async Task<OptionalValue<TValue>> FromAsync<TValue>(Task<TValue?> task) where TValue : struct
		=> new (await task);

	/// <summary>
	/// Returns <see cref="OptionalValue{TValue}.None">OptionalValue{TValue}.None</see> property - represents empty value
	/// </summary>
	public static OptionalValue<TValue> NoneValue<TValue>() where TValue : struct => OptionalValue<TValue>.None;

	/// <summary>
	/// Allows replace Optional value by fallback value if Optional value is null
	/// </summary>
	/// <param name="fallback">Value, which will be returned, if Optional instance value is null</param>
	/// <returns>Optional value, if it's null, fallback value</returns>
	public static TValue Fallback<TValue>(this OptionalValue<TValue> value, TValue fallback) where TValue : struct
		=> value.HasValue ? value.Value : fallback;

	/// <summary>
	/// Allows replace Optional value by fallback value if Optional value is null
	/// </summary>
	/// <param name="fallbackValues">Values, if <see cref="OptionalValue{TValue}"/> instance value is null, will be returned the first not null value.<br/>
	/// </param>
	/// <returns><see cref="OptionalValue{TValue}.None"/> will be returned, if "not null" value isn't presented in fallbacks.</returns>
	public static OptionalValue<TValue> FallbackCoalesce<TValue>(
		this OptionalValue<TValue> optionalValue, params TValue?[] fallbackValues) where TValue : struct
	{
		if (optionalValue.HasValue) return optionalValue;
		foreach (var fallback in fallbackValues)
			if (fallback is not null) return fallback;
		return NoneValue<TValue>();
	}

	/// <summary>
	/// Executes the specified action if the OptionalValue contains a value
	/// </summary>
	/// <param name="optionalValue">OptionalValue object</param>
	/// <param name="action">Action to perform with the value</param>
	/// <typeparam name="TValue">Type of the value</typeparam>
	/// <returns>The original OptionalValue object for method chaining</returns>
	public static OptionalValue<TValue> IfHasValue<TValue>(this OptionalValue<TValue> optionalValue, Action<TValue> action) 
		where TValue : struct
	{
		if (optionalValue.HasValue && action != null)
		{
			action(optionalValue.Value);
		}
		return optionalValue;
	}

	/// <summary>
	/// Executes the specified action if the OptionalValue does not contain a value
	/// </summary>
	/// <param name="optionalValue">OptionalValue object</param>
	/// <param name="action">Action to perform</param>
	/// <typeparam name="TValue">Type of the value</typeparam>
	/// <returns>The original OptionalValue object for method chaining</returns>
	public static OptionalValue<TValue> IfEmpty<TValue>(this OptionalValue<TValue> optionalValue, Action action) 
		where TValue : struct
	{
		if (!optionalValue.HasValue && action != null)
		{
			action();
		}
		return optionalValue;
	}

	/// <summary>
	/// Safely extracts a value from OptionalValue into an out parameter
	/// </summary>
	/// <param name="optionalValue">OptionalValue object</param>
	/// <param name="value">Extracted value, if it exists</param>
	/// <typeparam name="TValue">Type of the value</typeparam>
	/// <returns>true if the value exists, otherwise false</returns>
	public static bool TryGetValue<TValue>(this OptionalValue<TValue> optionalValue, out TValue value) 
		where TValue : struct
	{
		value = optionalValue.HasValue ? optionalValue.Value : default;
		return optionalValue.HasValue;
	}
	
	#endregion
}