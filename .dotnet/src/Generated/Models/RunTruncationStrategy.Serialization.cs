// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Assistants
{
    public partial class RunTruncationStrategy : IJsonModel<RunTruncationStrategy>
    {
        internal RunTruncationStrategy()
        {
        }

        void IJsonModel<RunTruncationStrategy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunTruncationStrategy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunTruncationStrategy)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(LastMessages) && _additionalBinaryDataProperties?.ContainsKey("last_messages") != true)
            {
                writer.WritePropertyName("last_messages"u8);
                writer.WriteNumberValue(LastMessages.Value);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(_type.ToString());
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

        RunTruncationStrategy IJsonModel<RunTruncationStrategy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual RunTruncationStrategy JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunTruncationStrategy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunTruncationStrategy)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRunTruncationStrategy(document.RootElement, options);
        }

        internal static RunTruncationStrategy DeserializeRunTruncationStrategy(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? lastMessages = default;
            InternalTruncationObjectType @type = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("last_messages"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        lastMessages = null;
                        continue;
                    }
                    lastMessages = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = new InternalTruncationObjectType(prop.Value.GetString());
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new RunTruncationStrategy(lastMessages, @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<RunTruncationStrategy>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunTruncationStrategy>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RunTruncationStrategy)} does not support writing '{options.Format}' format.");
            }
        }

        RunTruncationStrategy IPersistableModel<RunTruncationStrategy>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual RunTruncationStrategy PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunTruncationStrategy>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeRunTruncationStrategy(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RunTruncationStrategy)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RunTruncationStrategy>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(RunTruncationStrategy runTruncationStrategy)
        {
            if (runTruncationStrategy == null)
            {
                return null;
            }
            return BinaryContent.Create(runTruncationStrategy, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator RunTruncationStrategy(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeRunTruncationStrategy(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
