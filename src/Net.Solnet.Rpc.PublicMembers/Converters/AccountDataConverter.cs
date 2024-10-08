﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Solnet.Rpc.PublicMembers.Converters
{
    /// <inheritdoc/>
    public class AccountDataConverter : JsonConverter<List<string>>
    {
        /// <inheritdoc/>
        public override List<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
                return JsonSerializer.Deserialize<List<string>>(ref reader, options);

            if(reader.TokenType == JsonTokenType.StartObject)
            {
                JsonDocument doc = JsonDocument.ParseValue(ref reader);
                var jsonAsString = doc.RootElement.ToString();

                return new List<string>() { jsonAsString, "jsonParsed" };
            }

            throw new JsonException("Unable to parse account data");
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, List<string> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
