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
    public partial class ChatCompletion : IJsonModel<ChatCompletion>
    {
        internal ChatCompletion()
        {
        }

        void IJsonModel<ChatCompletion>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatCompletion>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatCompletion)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("model") != true)
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model);
            }
            if (Optional.IsDefined(SystemFingerprint) && _additionalBinaryDataProperties?.ContainsKey("system_fingerprint") != true)
            {
                writer.WritePropertyName("system_fingerprint"u8);
                writer.WriteStringValue(SystemFingerprint);
            }
            if (Optional.IsDefined(Usage) && _additionalBinaryDataProperties?.ContainsKey("usage") != true)
            {
                writer.WritePropertyName("usage"u8);
                writer.WriteObjectValue(Usage, options);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object.ToString());
            }
            if (Optional.IsDefined(ServiceTier) && _additionalBinaryDataProperties?.ContainsKey("service_tier") != true)
            {
                writer.WritePropertyName("service_tier"u8);
                writer.WriteStringValue(ServiceTier.Value.ToString());
            }
            if (_additionalBinaryDataProperties?.ContainsKey("choices") != true)
            {
                writer.WritePropertyName("choices"u8);
                writer.WriteStartArray();
                foreach (InternalCreateChatCompletionResponseChoice item in Choices)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (_additionalBinaryDataProperties?.ContainsKey("created") != true)
            {
                writer.WritePropertyName("created"u8);
                writer.WriteNumberValue(CreatedAt, "U");
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

        ChatCompletion IJsonModel<ChatCompletion>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ChatCompletion JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatCompletion>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatCompletion)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeChatCompletion(document.RootElement, options);
        }

        internal static ChatCompletion DeserializeChatCompletion(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            string model = default;
            string systemFingerprint = default;
            ChatTokenUsage usage = default;
            InternalCreateChatCompletionResponseObject @object = default;
            InternalCreateChatCompletionResponseServiceTier? serviceTier = default;
            IReadOnlyList<InternalCreateChatCompletionResponseChoice> choices = default;
            DateTimeOffset createdAt = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("model"u8))
                {
                    model = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("system_fingerprint"u8))
                {
                    systemFingerprint = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("usage"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    usage = ChatTokenUsage.DeserializeChatTokenUsage(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("object"u8))
                {
                    @object = new InternalCreateChatCompletionResponseObject(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("service_tier"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        serviceTier = null;
                        continue;
                    }
                    serviceTier = new InternalCreateChatCompletionResponseServiceTier(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("choices"u8))
                {
                    List<InternalCreateChatCompletionResponseChoice> array = new List<InternalCreateChatCompletionResponseChoice>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(InternalCreateChatCompletionResponseChoice.DeserializeInternalCreateChatCompletionResponseChoice(item, options));
                    }
                    choices = array;
                    continue;
                }
                if (prop.NameEquals("created"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new ChatCompletion(
                id,
                model,
                systemFingerprint,
                usage,
                @object,
                serviceTier,
                choices,
                createdAt,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ChatCompletion>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatCompletion>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ChatCompletion)} does not support writing '{options.Format}' format.");
            }
        }

        ChatCompletion IPersistableModel<ChatCompletion>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ChatCompletion PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatCompletion>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeChatCompletion(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ChatCompletion)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ChatCompletion>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ChatCompletion chatCompletion)
        {
            if (chatCompletion == null)
            {
                return null;
            }
            return BinaryContent.Create(chatCompletion, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ChatCompletion(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeChatCompletion(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
