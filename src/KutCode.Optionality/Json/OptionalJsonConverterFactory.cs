using System.Text.Json;
using System.Text.Json.Serialization;

namespace KutCode.Optionality.Json;

/// <summary>
/// JSON converter factory that selects the appropriate converter for Optional and OptionalValue objects
/// </summary>
public sealed class OptionalJsonConverterFactory : JsonConverterFactory
{
	public override bool CanConvert(Type typeToConvert)
	{
		return typeToConvert.GenericTypeArguments.Length == 1;
	}

	public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
	{
		var genericType = typeToConvert.GenericTypeArguments[0];
		var isValueType = genericType.IsValueType;
		var gType = isValueType ? typeof(OptionalValueJsonConverter<>) : typeof(OptionalJsonConverter<>);
		var resultType = gType.MakeGenericType(genericType);
		return (JsonConverter?) Activator.CreateInstance(resultType);
	}
}