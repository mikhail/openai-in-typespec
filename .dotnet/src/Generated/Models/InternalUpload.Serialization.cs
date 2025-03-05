// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Files
{
    internal partial class InternalUpload : IJsonModel<InternalUpload>
    {
        internal InternalUpload()
        {
        }

        void IJsonModel<InternalUpload>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalUpload>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalUpload)} does not support writing '{format}' format.");
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
            if (_additionalBinaryDataProperties?.ContainsKey("filename") != true)
            {
                writer.WritePropertyName("filename"u8);
                writer.WriteStringValue(Filename);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("bytes") != true)
            {
                writer.WritePropertyName("bytes"u8);
                writer.WriteNumberValue(Bytes);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("purpose") != true)
            {
                writer.WritePropertyName("purpose"u8);
                writer.WriteStringValue(Purpose);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("status") != true)
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.ToString());
            }
            if (_additionalBinaryDataProperties?.ContainsKey("expires_at") != true)
            {
                writer.WritePropertyName("expires_at"u8);
                writer.WriteNumberValue(ExpiresAt, "U");
            }
            if (Optional.IsDefined(Object) && _additionalBinaryDataProperties?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object.Value.ToString());
            }
            if (Optional.IsDefined(File) && _additionalBinaryDataProperties?.ContainsKey("file") != true)
            {
                writer.WritePropertyName("file"u8);
                writer.WriteObjectValue(File, options);
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

        InternalUpload IJsonModel<InternalUpload>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalUpload JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalUpload>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalUpload)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalUpload(document.RootElement, options);
        }

        internal static InternalUpload DeserializeInternalUpload(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            DateTimeOffset createdAt = default;
            string filename = default;
            int bytes = default;
            string purpose = default;
            InternalUploadStatus status = default;
            DateTimeOffset expiresAt = default;
            InternalUploadObject? @object = default;
            OpenAIFile @file = default;
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
                if (prop.NameEquals("filename"u8))
                {
                    filename = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("bytes"u8))
                {
                    bytes = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("purpose"u8))
                {
                    purpose = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("status"u8))
                {
                    status = new InternalUploadStatus(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("expires_at"u8))
                {
                    expiresAt = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                    continue;
                }
                if (prop.NameEquals("object"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    @object = new InternalUploadObject(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("file"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        @file = null;
                        continue;
                    }
                    @file = OpenAIFile.DeserializeOpenAIFile(prop.Value, options);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalUpload(
                id,
                createdAt,
                filename,
                bytes,
                purpose,
                status,
                expiresAt,
                @object,
                @file,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalUpload>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalUpload>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalUpload)} does not support writing '{options.Format}' format.");
            }
        }

        InternalUpload IPersistableModel<InternalUpload>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalUpload PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalUpload>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalUpload(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalUpload)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalUpload>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalUpload internalUpload)
        {
            if (internalUpload == null)
            {
                return null;
            }
            return BinaryContent.Create(internalUpload, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalUpload(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalUpload(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
