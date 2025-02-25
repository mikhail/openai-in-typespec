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
    internal partial class InternalMessageDeltaContentTextObjectText : IJsonModel<InternalMessageDeltaContentTextObjectText>
    {
        void IJsonModel<InternalMessageDeltaContentTextObjectText>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextObjectText>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextObjectText)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Value) && _additionalBinaryDataProperties?.ContainsKey("value") != true)
            {
                writer.WritePropertyName("value"u8);
                writer.WriteStringValue(Value);
            }
            if (Optional.IsCollectionDefined(Annotations) && _additionalBinaryDataProperties?.ContainsKey("annotations") != true)
            {
                writer.WritePropertyName("annotations"u8);
                writer.WriteStartArray();
                foreach (InternalMessageDeltaTextContentAnnotation item in Annotations)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
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

        InternalMessageDeltaContentTextObjectText IJsonModel<InternalMessageDeltaContentTextObjectText>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalMessageDeltaContentTextObjectText JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextObjectText>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextObjectText)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageDeltaContentTextObjectText(document.RootElement, options);
        }

        internal static InternalMessageDeltaContentTextObjectText DeserializeInternalMessageDeltaContentTextObjectText(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string value = default;
            IList<InternalMessageDeltaTextContentAnnotation> annotations = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("value"u8))
                {
                    value = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("annotations"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InternalMessageDeltaTextContentAnnotation> array = new List<InternalMessageDeltaTextContentAnnotation>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(InternalMessageDeltaTextContentAnnotation.DeserializeInternalMessageDeltaTextContentAnnotation(item, options));
                    }
                    annotations = array;
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalMessageDeltaContentTextObjectText(value, annotations ?? new ChangeTrackingList<InternalMessageDeltaTextContentAnnotation>(), additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalMessageDeltaContentTextObjectText>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextObjectText>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextObjectText)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageDeltaContentTextObjectText IPersistableModel<InternalMessageDeltaContentTextObjectText>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalMessageDeltaContentTextObjectText PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextObjectText>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageDeltaContentTextObjectText(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextObjectText)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageDeltaContentTextObjectText>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageDeltaContentTextObjectText internalMessageDeltaContentTextObjectText)
        {
            if (internalMessageDeltaContentTextObjectText == null)
            {
                return null;
            }
            return BinaryContent.Create(internalMessageDeltaContentTextObjectText, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageDeltaContentTextObjectText(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageDeltaContentTextObjectText(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
