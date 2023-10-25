using System.Text.Json;
using System.Text.Json.Serialization;

namespace KutCode.Optionality.Json;

/// <summary>
/// Json converter for map json values into Optional
/// </summary>
public sealed class OptionalValueJsonConverter<TValue>  : JsonConverter<OptionalValue<TValue>> where TValue : struct
{
	public override OptionalValue<TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var value = JsonSerializer.Deserialize(ref reader, typeToConvert.GenericTypeArguments[0], options);
		return Optional.From((TValue?)value);
	 }

	public override void Write(Utf8JsonWriter writer, OptionalValue<TValue> value, JsonSerializerOptions options)
	{
		writer.WriteRawValue(JsonSerializer.Serialize(value.Value, options));
	}
}