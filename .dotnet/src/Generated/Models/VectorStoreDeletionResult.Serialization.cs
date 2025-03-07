// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.VectorStores
{
    public partial class VectorStoreDeletionResult : IJsonModel<VectorStoreDeletionResult>
    {
        internal VectorStoreDeletionResult()
        {
        }

        void IJsonModel<VectorStoreDeletionResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStoreDeletionResult)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("deleted") != true)
            {
                writer.WritePropertyName("deleted"u8);
                writer.WriteBooleanValue(Deleted);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(VectorStoreId);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object.ToString());
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

        VectorStoreDeletionResult IJsonModel<VectorStoreDeletionResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual VectorStoreDeletionResult JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStoreDeletionResult)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVectorStoreDeletionResult(document.RootElement, options);
        }

        internal static VectorStoreDeletionResult DeserializeVectorStoreDeletionResult(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool deleted = default;
            string vectorStoreId = default;
            InternalDeleteVectorStoreResponseObject @object = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("deleted"u8))
                {
                    deleted = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("id"u8))
                {
                    vectorStoreId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("object"u8))
                {
                    @object = new InternalDeleteVectorStoreResponseObject(prop.Value.GetString());
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new VectorStoreDeletionResult(deleted, vectorStoreId, @object, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<VectorStoreDeletionResult>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(VectorStoreDeletionResult)} does not support writing '{options.Format}' format.");
            }
        }

        VectorStoreDeletionResult IPersistableModel<VectorStoreDeletionResult>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual VectorStoreDeletionResult PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeVectorStoreDeletionResult(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VectorStoreDeletionResult)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VectorStoreDeletionResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(VectorStoreDeletionResult vectorStoreDeletionResult)
        {
            if (vectorStoreDeletionResult == null)
            {
                return null;
            }
            return BinaryContent.Create(vectorStoreDeletionResult, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator VectorStoreDeletionResult(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeVectorStoreDeletionResult(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
