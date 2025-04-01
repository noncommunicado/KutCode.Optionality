using System.Text.Json;
using System.Text.Json.Serialization;

namespace KutCode.Optionality.Json;

/// <summary>
/// JSON converter for serializing and deserializing OptionalValue objects
/// </summary>
public sealed class OptionalValueJsonConverter<TValue> : JsonConverter<OptionalValue<TValue>> where TValue : struct
{
	public override OptionalValue<TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.Null)
			return OptionalValue<TValue>.None;

		var value = JsonSerializer.Deserialize<TValue>(ref reader, options);
		return new OptionalValue<TValue>(value);
	}

	public override void Write(Utf8JsonWriter writer, OptionalValue<TValue> value, JsonSerializerOptions options)
	{
		if (!value.HasValue)
		{
			writer.WriteNullValue();
			return;
		}

		JsonSerializer.Serialize(writer, value.Value, options);
	}
}