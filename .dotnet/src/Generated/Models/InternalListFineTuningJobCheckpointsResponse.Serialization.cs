// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.FineTuning
{
    internal partial class InternalListFineTuningJobCheckpointsResponse : IJsonModel<InternalListFineTuningJobCheckpointsResponse>
    {
        internal InternalListFineTuningJobCheckpointsResponse()
        {
        }

        void IJsonModel<InternalListFineTuningJobCheckpointsResponse>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalListFineTuningJobCheckpointsResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalListFineTuningJobCheckpointsResponse)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("data") != true)
            {
                writer.WritePropertyName("data"u8);
                writer.WriteStartArray();
                foreach (FineTuningCheckpoint item in Data)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (_additionalBinaryDataProperties?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object.ToString());
            }
            if (Optional.IsDefined(FirstId) && _additionalBinaryDataProperties?.ContainsKey("first_id") != true)
            {
                writer.WritePropertyName("first_id"u8);
                writer.WriteStringValue(FirstId);
            }
            if (Optional.IsDefined(LastId) && _additionalBinaryDataProperties?.ContainsKey("last_id") != true)
            {
                writer.WritePropertyName("last_id"u8);
                writer.WriteStringValue(LastId);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("has_more") != true)
            {
                writer.WritePropertyName("has_more"u8);
                writer.WriteBooleanValue(HasMore);
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

        InternalListFineTuningJobCheckpointsResponse IJsonModel<InternalListFineTuningJobCheckpointsResponse>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalListFineTuningJobCheckpointsResponse JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalListFineTuningJobCheckpointsResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalListFineTuningJobCheckpointsResponse)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalListFineTuningJobCheckpointsResponse(document.RootElement, options);
        }

        internal static InternalListFineTuningJobCheckpointsResponse DeserializeInternalListFineTuningJobCheckpointsResponse(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<FineTuningCheckpoint> data = default;
            InternalListFineTuningJobCheckpointsResponseObject @object = default;
            string firstId = default;
            string lastId = default;
            bool hasMore = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("data"u8))
                {
                    List<FineTuningCheckpoint> array = new List<FineTuningCheckpoint>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(FineTuningCheckpoint.DeserializeFineTuningCheckpoint(item, options));
                    }
                    data = array;
                    continue;
                }
                if (prop.NameEquals("object"u8))
                {
                    @object = new InternalListFineTuningJobCheckpointsResponseObject(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("first_id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        firstId = null;
                        continue;
                    }
                    firstId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("last_id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        lastId = null;
                        continue;
                    }
                    lastId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("has_more"u8))
                {
                    hasMore = prop.Value.GetBoolean();
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalListFineTuningJobCheckpointsResponse(
                data,
                @object,
                firstId,
                lastId,
                hasMore,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalListFineTuningJobCheckpointsResponse>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalListFineTuningJobCheckpointsResponse>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalListFineTuningJobCheckpointsResponse)} does not support writing '{options.Format}' format.");
            }
        }

        InternalListFineTuningJobCheckpointsResponse IPersistableModel<InternalListFineTuningJobCheckpointsResponse>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalListFineTuningJobCheckpointsResponse PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalListFineTuningJobCheckpointsResponse>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalListFineTuningJobCheckpointsResponse(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalListFineTuningJobCheckpointsResponse)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalListFineTuningJobCheckpointsResponse>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalListFineTuningJobCheckpointsResponse internalListFineTuningJobCheckpointsResponse)
        {
            if (internalListFineTuningJobCheckpointsResponse == null)
            {
                return null;
            }
            return BinaryContent.Create(internalListFineTuningJobCheckpointsResponse, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalListFineTuningJobCheckpointsResponse(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalListFineTuningJobCheckpointsResponse(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
