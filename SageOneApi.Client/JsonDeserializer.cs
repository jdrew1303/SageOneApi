using System;
using SageOneApi.Client.Responses;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SageOneApi.Client
{
#if DEBUG
	public // for testing
#else
	internal
#endif
	static class JsonDeserializer
	{
		private static readonly JsonSerializerOptions _options = getOptions();

		private static JsonSerializerOptions getOptions()
		{
			var options = new JsonSerializerOptions(JsonSerializerDefaults.General);

			options.NumberHandling = JsonNumberHandling.AllowReadingFromString;
			
			options.Converters.Add(new NullableDateTimeConverter());

			return options;
		}

		public static T DeserializeObject<T>(string json)
		{
			return JsonSerializer.Deserialize<T>(json, _options);
		}

		public static GetAllResponse<T> DeserializeObjects<T>(string json)
		{
			return JsonSerializer.Deserialize<GetAllResponse<T>>(json, _options);
		}

		private class NullableDateTimeConverter : JsonConverter<DateTime?>
		{
			public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				string sval = reader.GetString();
				if (string.IsNullOrWhiteSpace(sval))
					return null;
				else
					return DateTime.Parse(sval);
			}

			public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
			{
				writer.WriteStringValue(value.HasValue ? value.ToString() : null);
			}
		}
	}
}
