// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Audio
{
    internal partial class InternalCreateTranscriptionResponseJson : IJsonModel<InternalCreateTranscriptionResponseJson>
    {
        internal InternalCreateTranscriptionResponseJson()
        {
        }

        void IJsonModel<InternalCreateTranscriptionResponseJson>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateTranscriptionResponseJson>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateTranscriptionResponseJson)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("text") != true)
            {
                writer.WritePropertyName("text"u8);
                writer.WriteStringValue(Text);
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

        InternalCreateTranscriptionResponseJson IJsonModel<InternalCreateTranscriptionResponseJson>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalCreateTranscriptionResponseJson JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateTranscriptionResponseJson>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateTranscriptionResponseJson)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateTranscriptionResponseJson(document.RootElement, options);
        }

        internal static InternalCreateTranscriptionResponseJson DeserializeInternalCreateTranscriptionResponseJson(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string text = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("text"u8))
                {
                    text = prop.Value.GetString();
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalCreateTranscriptionResponseJson(text, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalCreateTranscriptionResponseJson>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateTranscriptionResponseJson>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateTranscriptionResponseJson)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateTranscriptionResponseJson IPersistableModel<InternalCreateTranscriptionResponseJson>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalCreateTranscriptionResponseJson PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateTranscriptionResponseJson>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalCreateTranscriptionResponseJson(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateTranscriptionResponseJson)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateTranscriptionResponseJson>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalCreateTranscriptionResponseJson internalCreateTranscriptionResponseJson)
        {
            if (internalCreateTranscriptionResponseJson == null)
            {
                return null;
            }
            return BinaryContent.Create(internalCreateTranscriptionResponseJson, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalCreateTranscriptionResponseJson(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateTranscriptionResponseJson(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
