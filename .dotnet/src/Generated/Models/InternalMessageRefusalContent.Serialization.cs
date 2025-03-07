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
    internal partial class InternalMessageRefusalContent : IJsonModel<InternalMessageRefusalContent>
    {
        internal InternalMessageRefusalContent()
        {
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageRefusalContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageRefusalContent)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("refusal") != true)
            {
                writer.WritePropertyName("refusal"u8);
                writer.WriteStringValue(InternalRefusal);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(_type);
            }
        }

        InternalMessageRefusalContent IJsonModel<InternalMessageRefusalContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalMessageRefusalContent)JsonModelCreateCore(ref reader, options);

        protected override MessageContent JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageRefusalContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageRefusalContent)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageRefusalContent(document.RootElement, options);
        }

        internal static InternalMessageRefusalContent DeserializeInternalMessageRefusalContent(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            string internalRefusal = default;
            string @type = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("refusal"u8))
                {
                    internalRefusal = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalMessageRefusalContent(additionalBinaryDataProperties, internalRefusal, @type);
        }

        BinaryData IPersistableModel<InternalMessageRefusalContent>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageRefusalContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageRefusalContent)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageRefusalContent IPersistableModel<InternalMessageRefusalContent>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalMessageRefusalContent)PersistableModelCreateCore(data, options);

        protected override MessageContent PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageRefusalContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageRefusalContent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageRefusalContent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageRefusalContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageRefusalContent internalMessageRefusalContent)
        {
            if (internalMessageRefusalContent == null)
            {
                return null;
            }
            return BinaryContent.Create(internalMessageRefusalContent, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageRefusalContent(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageRefusalContent(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
