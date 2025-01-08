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
    internal partial class HyperparameterOptions : IJsonModel<HyperparameterOptions>
    {
        void IJsonModel<HyperparameterOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<HyperparameterOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HyperparameterOptions)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(CycleCount) && _additionalBinaryDataProperties?.ContainsKey("n_epochs") != true)
            {
                writer.WritePropertyName("n_epochs"u8);
                writer.WriteObjectValue<FineTuning.HyperparameterCycleCount>(CycleCount, options);
            }
            if (Optional.IsDefined(BatchSize) && _additionalBinaryDataProperties?.ContainsKey("batch_size") != true)
            {
                writer.WritePropertyName("batch_size"u8);
                writer.WriteObjectValue<FineTuning.HyperparameterBatchSize>(BatchSize, options);
            }
            if (Optional.IsDefined(LearningRate) && _additionalBinaryDataProperties?.ContainsKey("learning_rate_multiplier") != true)
            {
                writer.WritePropertyName("learning_rate_multiplier"u8);
                writer.WriteObjectValue<FineTuning.HyperparameterLearningRate>(LearningRate, options);
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

        HyperparameterOptions IJsonModel<HyperparameterOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual HyperparameterOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<HyperparameterOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HyperparameterOptions)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeHyperparameterOptions(document.RootElement, options);
        }

        internal static HyperparameterOptions DeserializeHyperparameterOptions(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            FineTuning.HyperparameterCycleCount cycleCount = default;
            FineTuning.HyperparameterBatchSize batchSize = default;
            FineTuning.HyperparameterLearningRate learningRate = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("n_epochs"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cycleCount = FineTuning.HyperparameterCycleCount.DeserializeHyperparameterCycleCount(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("batch_size"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    batchSize = FineTuning.HyperparameterBatchSize.DeserializeHyperparameterBatchSize(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("learning_rate_multiplier"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    learningRate = FineTuning.HyperparameterLearningRate.DeserializeHyperparameterLearningRate(prop.Value, options);
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new HyperparameterOptions(cycleCount, batchSize, learningRate, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<HyperparameterOptions>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<HyperparameterOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(HyperparameterOptions)} does not support writing '{options.Format}' format.");
            }
        }

        HyperparameterOptions IPersistableModel<HyperparameterOptions>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual HyperparameterOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<HyperparameterOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeHyperparameterOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(HyperparameterOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<HyperparameterOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(HyperparameterOptions hyperparameterOptions)
        {
            if (hyperparameterOptions == null)
            {
                return null;
            }
            return BinaryContent.Create(hyperparameterOptions, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator HyperparameterOptions(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeHyperparameterOptions(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
