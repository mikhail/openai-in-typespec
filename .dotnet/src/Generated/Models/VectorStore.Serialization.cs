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
    public partial class VectorStore : IJsonModel<VectorStore>
    {
        internal VectorStore()
        {
        }

        void IJsonModel<VectorStore>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStore>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStore)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("created_at") != true)
            {
                writer.WritePropertyName("created_at"u8);
                writer.WriteNumberValue(CreatedAt, "U");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("name") != true)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("usage_bytes") != true)
            {
                writer.WritePropertyName("usage_bytes"u8);
                writer.WriteNumberValue(UsageBytes);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("file_counts") != true)
            {
                writer.WritePropertyName("file_counts"u8);
                writer.WriteObjectValue(FileCounts, options);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("status") != true)
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.ToSerialString());
            }
            if (Optional.IsDefined(ExpiresAt) && _additionalBinaryDataProperties?.ContainsKey("expires_at") != true)
            {
                writer.WritePropertyName("expires_at"u8);
                writer.WriteNumberValue(ExpiresAt.Value, "U");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("last_active_at") != true)
            {
                if (Optional.IsDefined(LastActiveAt))
                {
                    writer.WritePropertyName("last_active_at"u8);
                    writer.WriteNumberValue(LastActiveAt.Value, "U");
                }
                else
                {
                    writer.WriteNull("last_active_at"u8);
                }
            }
            if (_additionalBinaryDataProperties?.ContainsKey("metadata") != true)
            {
                if (options.Format != "W" && Optional.IsCollectionDefined(Metadata))
                {
                    writer.WritePropertyName("metadata"u8);
                    writer.WriteStartObject();
                    foreach (var item in Metadata)
                    {
                        writer.WritePropertyName(item.Key);
                        if (item.Value == null)
                        {
                            writer.WriteNullValue();
                            continue;
                        }
                        writer.WriteStringValue(item.Value);
                    }
                    writer.WriteEndObject();
                }
                else
                {
                    writer.WriteNull("metadata"u8);
                }
            }
            if (_additionalBinaryDataProperties?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object.ToString());
            }
            if (Optional.IsDefined(ExpirationPolicy) && _additionalBinaryDataProperties?.ContainsKey("expires_after") != true)
            {
                writer.WritePropertyName("expires_after"u8);
                writer.WriteObjectValue(ExpirationPolicy, options);
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

        VectorStore IJsonModel<VectorStore>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual VectorStore JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStore>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStore)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVectorStore(document.RootElement, options);
        }

        internal static VectorStore DeserializeVectorStore(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            DateTimeOffset createdAt = default;
            string name = default;
            int usageBytes = default;
            VectorStoreFileCounts fileCounts = default;
            VectorStoreStatus status = default;
            DateTimeOffset? expiresAt = default;
            DateTimeOffset? lastActiveAt = default;
            IReadOnlyDictionary<string, string> metadata = default;
            InternalVectorStoreObjectObject @object = default;
            VectorStoreExpirationPolicy expirationPolicy = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("usage_bytes"u8))
                {
                    usageBytes = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("file_counts"u8))
                {
                    fileCounts = VectorStoreFileCounts.DeserializeVectorStoreFileCounts(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("status"u8))
                {
                    status = prop.Value.GetString().ToVectorStoreStatus();
                    continue;
                }
                if (prop.NameEquals("expires_at"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        expiresAt = null;
                        continue;
                    }
                    expiresAt = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                    continue;
                }
                if (prop.NameEquals("last_active_at"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        lastActiveAt = null;
                        continue;
                    }
                    lastActiveAt = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                    continue;
                }
                if (prop.NameEquals("metadata"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        metadata = new ChangeTrackingDictionary<string, string>();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        if (prop0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(prop0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(prop0.Name, prop0.Value.GetString());
                        }
                    }
                    metadata = dictionary;
                    continue;
                }
                if (prop.NameEquals("object"u8))
                {
                    @object = new InternalVectorStoreObjectObject(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("expires_after"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    expirationPolicy = VectorStoreExpirationPolicy.DeserializeVectorStoreExpirationPolicy(prop.Value, options);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new VectorStore(
                id,
                createdAt,
                name,
                usageBytes,
                fileCounts,
                status,
                expiresAt,
                lastActiveAt,
                metadata,
                @object,
                expirationPolicy,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<VectorStore>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStore>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(VectorStore)} does not support writing '{options.Format}' format.");
            }
        }

        VectorStore IPersistableModel<VectorStore>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual VectorStore PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStore>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeVectorStore(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VectorStore)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VectorStore>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(VectorStore vectorStore)
        {
            if (vectorStore == null)
            {
                return null;
            }
            return BinaryContent.Create(vectorStore, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator VectorStore(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeVectorStore(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
