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
    internal partial class InternalFineTuningJobRequestMethodSupervised : IJsonModel<InternalFineTuningJobRequestMethodSupervised>
    {
        void IJsonModel<InternalFineTuningJobRequestMethodSupervised>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalFineTuningJobRequestMethodSupervised>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalFineTuningJobRequestMethodSupervised)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Hyperparameters) && _additionalBinaryDataProperties?.ContainsKey("hyperparameters") != true)
            {
                writer.WritePropertyName("hyperparameters"u8);
                writer.WriteObjectValue(Hyperparameters, options);
            }
            if (true && _additionalBinaryDataProperties != null)
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

        InternalFineTuningJobRequestMethodSupervised IJsonModel<InternalFineTuningJobRequestMethodSupervised>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalFineTuningJobRequestMethodSupervised JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalFineTuningJobRequestMethodSupervised>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalFineTuningJobRequestMethodSupervised)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalFineTuningJobRequestMethodSupervised(document.RootElement, options);
        }

        internal static InternalFineTuningJobRequestMethodSupervised DeserializeInternalFineTuningJobRequestMethodSupervised(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            HyperparametersForSupervised hyperparameters = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("hyperparameters"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hyperparameters = HyperparametersForSupervised.DeserializeHyperparametersForSupervised(prop.Value, options);
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalFineTuningJobRequestMethodSupervised(hyperparameters, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalFineTuningJobRequestMethodSupervised>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalFineTuningJobRequestMethodSupervised>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalFineTuningJobRequestMethodSupervised)} does not support writing '{options.Format}' format.");
            }
        }

        InternalFineTuningJobRequestMethodSupervised IPersistableModel<InternalFineTuningJobRequestMethodSupervised>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalFineTuningJobRequestMethodSupervised PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalFineTuningJobRequestMethodSupervised>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalFineTuningJobRequestMethodSupervised(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalFineTuningJobRequestMethodSupervised)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalFineTuningJobRequestMethodSupervised>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalFineTuningJobRequestMethodSupervised internalFineTuningJobRequestMethodSupervised)
        {
            if (internalFineTuningJobRequestMethodSupervised == null)
            {
                return null;
            }
            return BinaryContent.Create(internalFineTuningJobRequestMethodSupervised, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalFineTuningJobRequestMethodSupervised(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalFineTuningJobRequestMethodSupervised(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
