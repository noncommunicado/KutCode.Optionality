using System.Text.Json;
using System.Text.Json.Serialization;

namespace KutCode.Optional.Core.Json;

/// <summary>
/// Json converter for map json values into Optional
/// </summary>
public sealed class OptionalJsonConverter<TValue>  : JsonConverter<Optional<TValue>> where TValue : class
{
	public override Optional<TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var value = JsonSerializer.Deserialize(ref reader, typeToConvert.GenericTypeArguments[0], options);
		return Optional.From((TValue?)value);
	 }

	public override void Write(Utf8JsonWriter writer, Optional<TValue> value, JsonSerializerOptions options)
	{
		writer.WriteRawValue(JsonSerializer.Serialize(value.Value, options));
	}
}