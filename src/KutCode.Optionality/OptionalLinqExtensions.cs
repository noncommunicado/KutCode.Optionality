namespace KutCode.Optionality;

/// <summary>
/// LINQ extension methods for working with collections of Optional objects
/// </summary>
public static class OptionalLinqExtensions
{
    /// <summary>
    /// Filters a collection, keeping only elements with values
    /// </summary>
    /// <param name="source">Source collection of Optional elements</param>
    /// <typeparam name="TValue">Type of the value</typeparam>
    /// <returns>Collection of values without empty elements</returns>
    public static IEnumerable<TValue> WhereHasValue<TValue>(this IEnumerable<Optional<TValue>> source) 
        where TValue : class
    {
        return source.Where(x => x.HasValue).Select(x => x.Value!);
    }

    /// <summary>
    /// Applies a transformation to elements that have values
    /// </summary>
    /// <param name="source">Source collection of Optional elements</param>
    /// <param name="selector">Transformation function</param>
    /// <typeparam name="TValue">Type of the source value</typeparam>
    /// <typeparam name="TResult">Type of the result</typeparam>
    /// <returns>Collection of transformed values</returns>
    public static IEnumerable<TResult> SelectIfHasValue<TValue, TResult>(
        this IEnumerable<Optional<TValue>> source, 
        Func<TValue, TResult> selector) 
        where TValue : class
    {
        return source.Where(x => x.HasValue).Select(x => selector(x.Value!));
    }

    /// <summary>
    /// Filters a collection, keeping only elements with values
    /// </summary>
    /// <param name="source">Source collection of OptionalValue elements</param>
    /// <typeparam name="TValue">Type of the value</typeparam>
    /// <returns>Collection of values without empty elements</returns>
    public static IEnumerable<TValue> WhereHasValue<TValue>(this IEnumerable<OptionalValue<TValue>> source) 
        where TValue : struct
    {
        return source.Where(x => x.HasValue).Select(x => x.Value);
    }

    /// <summary>
    /// Applies a transformation to elements that have values
    /// </summary>
    /// <param name="source">Source collection of OptionalValue elements</param>
    /// <param name="selector">Transformation function</param>
    /// <typeparam name="TValue">Type of the source value</typeparam>
    /// <typeparam name="TResult">Type of the result</typeparam>
    /// <returns>Collection of transformed values</returns>
    public static IEnumerable<TResult> SelectIfHasValue<TValue, TResult>(
        this IEnumerable<OptionalValue<TValue>> source, 
        Func<TValue, TResult> selector) 
        where TValue : struct
    {
        return source.Where(x => x.HasValue).Select(x => selector(x.Value));
    }
} 