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
    public partial class ChatFunctionCall : IJsonModel<ChatFunctionCall>
    {
        internal ChatFunctionCall()
        {
        }

        void IJsonModel<ChatFunctionCall>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatFunctionCall>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatFunctionCall)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("name") != true)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(FunctionName);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("arguments") != true)
            {
                writer.WritePropertyName("arguments"u8);
                SerializeFunctionArgumentsValue(writer, options);
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

        ChatFunctionCall IJsonModel<ChatFunctionCall>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ChatFunctionCall JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatFunctionCall>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatFunctionCall)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeChatFunctionCall(document.RootElement, options);
        }

        internal static ChatFunctionCall DeserializeChatFunctionCall(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string functionName = default;
            BinaryData functionArguments = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    functionName = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("arguments"u8))
                {
                    DeserializeFunctionArgumentsValue(prop, ref functionArguments);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new ChatFunctionCall(functionName, functionArguments, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ChatFunctionCall>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatFunctionCall>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ChatFunctionCall)} does not support writing '{options.Format}' format.");
            }
        }

        ChatFunctionCall IPersistableModel<ChatFunctionCall>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ChatFunctionCall PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatFunctionCall>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeChatFunctionCall(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ChatFunctionCall)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ChatFunctionCall>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ChatFunctionCall chatFunctionCall)
        {
            if (chatFunctionCall == null)
            {
                return null;
            }
            return BinaryContent.Create(chatFunctionCall, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ChatFunctionCall(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeChatFunctionCall(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
