// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.FineTuning
{
    [PersistableModelProxy(typeof(UnknownFineTuningJobRequestMethod))]
    public abstract partial class FineTuningTrainingMethod : IJsonModel<FineTuningTrainingMethod>
    {
        internal FineTuningTrainingMethod()
        {
        }

        void IJsonModel<FineTuningTrainingMethod>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FineTuningTrainingMethod>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTuningTrainingMethod)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type.ToString());
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

        FineTuningTrainingMethod IJsonModel<FineTuningTrainingMethod>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual FineTuningTrainingMethod JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FineTuningTrainingMethod>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTuningTrainingMethod)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFineTuningTrainingMethod(document.RootElement, options);
        }

        internal static FineTuningTrainingMethod DeserializeFineTuningTrainingMethod(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("type"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "supervised":
                        return InternalFineTuningJobRequestMethodSupervised.DeserializeInternalFineTuningJobRequestMethodSupervised(element, options);
                    case "dpo":
                        return InternalFineTuningJobRequestMethodDpo.DeserializeInternalFineTuningJobRequestMethodDpo(element, options);
                    case "reinforcement":
                        return InternalFineTuningJobRequestMethodReinforcement.DeserializeInternalFineTuningJobRequestMethodReinforcement(element, options);
                }
            }
            return UnknownFineTuningJobRequestMethod.DeserializeUnknownFineTuningJobRequestMethod(element, options);
        }

        BinaryData IPersistableModel<FineTuningTrainingMethod>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FineTuningTrainingMethod>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FineTuningTrainingMethod)} does not support writing '{options.Format}' format.");
            }
        }

        FineTuningTrainingMethod IPersistableModel<FineTuningTrainingMethod>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual FineTuningTrainingMethod PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FineTuningTrainingMethod>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeFineTuningTrainingMethod(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FineTuningTrainingMethod)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FineTuningTrainingMethod>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(FineTuningTrainingMethod fineTuningTrainingMethod)
        {
            if (fineTuningTrainingMethod == null)
            {
                return null;
            }
            return BinaryContent.Create(fineTuningTrainingMethod, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator FineTuningTrainingMethod(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeFineTuningTrainingMethod(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
