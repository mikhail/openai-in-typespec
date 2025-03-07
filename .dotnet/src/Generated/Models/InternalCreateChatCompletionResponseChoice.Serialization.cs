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
    internal partial class InternalCreateChatCompletionResponseChoice : IJsonModel<InternalCreateChatCompletionResponseChoice>
    {
        internal InternalCreateChatCompletionResponseChoice()
        {
        }

        void IJsonModel<InternalCreateChatCompletionResponseChoice>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionResponseChoice>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateChatCompletionResponseChoice)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("finish_reason") != true)
            {
                writer.WritePropertyName("finish_reason"u8);
                writer.WriteStringValue(FinishReason.ToSerialString());
            }
            if (_additionalBinaryDataProperties?.ContainsKey("index") != true)
            {
                writer.WritePropertyName("index"u8);
                writer.WriteNumberValue(Index);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("message") != true)
            {
                writer.WritePropertyName("message"u8);
                writer.WriteObjectValue(Message, options);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("logprobs") != true)
            {
                if (Optional.IsDefined(Logprobs))
                {
                    writer.WritePropertyName("logprobs"u8);
                    writer.WriteObjectValue(Logprobs, options);
                }
                else
                {
                    writer.WriteNull("logprobs"u8);
                }
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

        InternalCreateChatCompletionResponseChoice IJsonModel<InternalCreateChatCompletionResponseChoice>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalCreateChatCompletionResponseChoice JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionResponseChoice>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateChatCompletionResponseChoice)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateChatCompletionResponseChoice(document.RootElement, options);
        }

        internal static InternalCreateChatCompletionResponseChoice DeserializeInternalCreateChatCompletionResponseChoice(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ChatFinishReason finishReason = default;
            int index = default;
            InternalChatCompletionResponseMessage message = default;
            InternalCreateChatCompletionResponseChoiceLogprobs logprobs = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("finish_reason"u8))
                {
                    finishReason = prop.Value.GetString().ToChatFinishReason();
                    continue;
                }
                if (prop.NameEquals("index"u8))
                {
                    index = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("message"u8))
                {
                    message = InternalChatCompletionResponseMessage.DeserializeInternalChatCompletionResponseMessage(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("logprobs"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        logprobs = null;
                        continue;
                    }
                    logprobs = InternalCreateChatCompletionResponseChoiceLogprobs.DeserializeInternalCreateChatCompletionResponseChoiceLogprobs(prop.Value, options);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalCreateChatCompletionResponseChoice(finishReason, index, message, logprobs, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalCreateChatCompletionResponseChoice>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionResponseChoice>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateChatCompletionResponseChoice)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateChatCompletionResponseChoice IPersistableModel<InternalCreateChatCompletionResponseChoice>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalCreateChatCompletionResponseChoice PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionResponseChoice>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalCreateChatCompletionResponseChoice(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateChatCompletionResponseChoice)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateChatCompletionResponseChoice>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalCreateChatCompletionResponseChoice internalCreateChatCompletionResponseChoice)
        {
            if (internalCreateChatCompletionResponseChoice == null)
            {
                return null;
            }
            return BinaryContent.Create(internalCreateChatCompletionResponseChoice, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalCreateChatCompletionResponseChoice(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateChatCompletionResponseChoice(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
