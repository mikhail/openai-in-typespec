// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Chat
{
    public partial class StreamingChatOutputAudioUpdate : IJsonModel<StreamingChatOutputAudioUpdate>
    {
        void IJsonModel<StreamingChatOutputAudioUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StreamingChatOutputAudioUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StreamingChatOutputAudioUpdate)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Id) && _additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(ExpiresAt) && _additionalBinaryDataProperties?.ContainsKey("expires_at") != true)
            {
                writer.WritePropertyName("expires_at"u8);
                writer.WriteNumberValue(ExpiresAt.Value, "U");
            }
            if (Optional.IsDefined(TranscriptUpdate) && _additionalBinaryDataProperties?.ContainsKey("transcript") != true)
            {
                writer.WritePropertyName("transcript"u8);
                writer.WriteStringValue(TranscriptUpdate);
            }
            if (Optional.IsDefined(AudioBytesUpdate) && _additionalBinaryDataProperties?.ContainsKey("data") != true)
            {
                writer.WritePropertyName("data"u8);
                writer.WriteBase64StringValue(AudioBytesUpdate.ToArray(), "D");
            }
            if (_additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                    {
                        continue;
                    }
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        StreamingChatOutputAudioUpdate IJsonModel<StreamingChatOutputAudioUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual StreamingChatOutputAudioUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StreamingChatOutputAudioUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StreamingChatOutputAudioUpdate)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeStreamingChatOutputAudioUpdate(document.RootElement, options);
        }

        internal static StreamingChatOutputAudioUpdate DeserializeStreamingChatOutputAudioUpdate(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            DateTimeOffset? expiresAt = default;
            string transcriptUpdate = default;
            BinaryData audioBytesUpdate = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("expires_at"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    expiresAt = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                    continue;
                }
                if (prop.NameEquals("transcript"u8))
                {
                    transcriptUpdate = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("data"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    audioBytesUpdate = BinaryData.FromBytes(prop.Value.GetBytesFromBase64("D"));
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new StreamingChatOutputAudioUpdate(id, expiresAt, transcriptUpdate, audioBytesUpdate, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<StreamingChatOutputAudioUpdate>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StreamingChatOutputAudioUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(StreamingChatOutputAudioUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        StreamingChatOutputAudioUpdate IPersistableModel<StreamingChatOutputAudioUpdate>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual StreamingChatOutputAudioUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StreamingChatOutputAudioUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeStreamingChatOutputAudioUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(StreamingChatOutputAudioUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<StreamingChatOutputAudioUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(StreamingChatOutputAudioUpdate streamingChatOutputAudioUpdate)
        {
            if (streamingChatOutputAudioUpdate == null)
            {
                return null;
            }
            return BinaryContent.Create(streamingChatOutputAudioUpdate, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator StreamingChatOutputAudioUpdate(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeStreamingChatOutputAudioUpdate(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
