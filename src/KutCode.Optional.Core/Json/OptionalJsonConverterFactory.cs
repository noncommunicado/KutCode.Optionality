using System.Text.Json;
using System.Text.Json.Serialization;

namespace KutCode.Optional.Core.Json;

/// <summary>
/// Json converter factory for map json values into Optional
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
		bool isValueType = genericType.IsSubclassOf(typeof(ValueType));
		var gType = isValueType ? typeof(OptionalValueJsonConverter<>) : typeof(OptionalJsonConverter<>);
		var resultType = gType.MakeGenericType(genericType);
		return (JsonConverter?) Activator.CreateInstance(resultType);
	}
}