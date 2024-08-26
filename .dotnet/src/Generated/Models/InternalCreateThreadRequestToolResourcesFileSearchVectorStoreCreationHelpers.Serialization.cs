// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers : IJsonModel<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers>
    {
        void IJsonModel<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("vector_stores") != true && Optional.IsCollectionDefined(VectorStores))
            {
                writer.WritePropertyName("vector_stores"u8);
                writer.WriteStartArray();
                foreach (var item in VectorStores)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData != null)
            {
                foreach (var item in SerializedAdditionalRawData)
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
            writer.WriteEndObject();
        }

        InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers IJsonModel<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers(document.RootElement, options);
        }

        internal static InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers DeserializeInternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpersVectorStore> vectorStores = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vector_stores"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpersVectorStore> array = new List<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpersVectorStore>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpersVectorStore.DeserializeInternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpersVectorStore(item, options));
                    }
                    vectorStores = array;
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers(vectorStores ?? new ChangeTrackingList<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpersVectorStore>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers IPersistableModel<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateThreadRequestToolResourcesFileSearchVectorStoreCreationHelpers(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}