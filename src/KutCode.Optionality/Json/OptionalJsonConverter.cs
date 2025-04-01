using System.Text.Json;
using System.Text.Json.Serialization;

namespace KutCode.Optionality.Json;

/// <summary>
/// JSON converter for serializing and deserializing Optional objects
/// </summary>
public sealed class OptionalJsonConverter<TValue> : JsonConverter<Optional<TValue>> where TValue : class
{
	public override Optional<TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.Null)
			return Optional.None<TValue>();

		var value = JsonSerializer.Deserialize<TValue>(ref reader, options);
		return Optional.From(value);
	}

	public override void Write(Utf8JsonWriter writer, Optional<TValue> value, JsonSerializerOptions options)
	{
		if (!value.HasValue)
		{
			writer.WriteNullValue();
			return;
		}

		JsonSerializer.Serialize(writer, value.Value, options);
	}
}