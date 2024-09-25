// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Moderations
{
    internal partial class InternalModerationCategoryScores : IJsonModel<InternalModerationCategoryScores>
    {
        void IJsonModel<InternalModerationCategoryScores>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalModerationCategoryScores>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalModerationCategoryScores)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("hate") != true)
            {
                writer.WritePropertyName("hate"u8);
                writer.WriteNumberValue(Hate);
            }
            if (SerializedAdditionalRawData?.ContainsKey("hate/threatening") != true)
            {
                writer.WritePropertyName("hate/threatening"u8);
                writer.WriteNumberValue(HateThreatening);
            }
            if (SerializedAdditionalRawData?.ContainsKey("harassment") != true)
            {
                writer.WritePropertyName("harassment"u8);
                writer.WriteNumberValue(Harassment);
            }
            if (SerializedAdditionalRawData?.ContainsKey("harassment/threatening") != true)
            {
                writer.WritePropertyName("harassment/threatening"u8);
                writer.WriteNumberValue(HarassmentThreatening);
            }
            if (SerializedAdditionalRawData?.ContainsKey("self-harm") != true)
            {
                writer.WritePropertyName("self-harm"u8);
                writer.WriteNumberValue(SelfHarm);
            }
            if (SerializedAdditionalRawData?.ContainsKey("self-harm/intent") != true)
            {
                writer.WritePropertyName("self-harm/intent"u8);
                writer.WriteNumberValue(SelfHarmIntent);
            }
            if (SerializedAdditionalRawData?.ContainsKey("self-harm/instructions") != true)
            {
                writer.WritePropertyName("self-harm/instructions"u8);
                writer.WriteNumberValue(SelfHarmInstructions);
            }
            if (SerializedAdditionalRawData?.ContainsKey("sexual") != true)
            {
                writer.WritePropertyName("sexual"u8);
                writer.WriteNumberValue(Sexual);
            }
            if (SerializedAdditionalRawData?.ContainsKey("sexual/minors") != true)
            {
                writer.WritePropertyName("sexual/minors"u8);
                writer.WriteNumberValue(SexualMinors);
            }
            if (SerializedAdditionalRawData?.ContainsKey("violence") != true)
            {
                writer.WritePropertyName("violence"u8);
                writer.WriteNumberValue(Violence);
            }
            if (SerializedAdditionalRawData?.ContainsKey("violence/graphic") != true)
            {
                writer.WritePropertyName("violence/graphic"u8);
                writer.WriteNumberValue(ViolenceGraphic);
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

        InternalModerationCategoryScores IJsonModel<InternalModerationCategoryScores>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalModerationCategoryScores>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalModerationCategoryScores)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalModerationCategoryScores(document.RootElement, options);
        }

        internal static InternalModerationCategoryScores DeserializeInternalModerationCategoryScores(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            float hate = default;
            float hateThreatening = default;
            float harassment = default;
            float harassmentThreatening = default;
            float selfHarm = default;
            float selfHarmIntent = default;
            float selfHarmInstructions = default;
            float sexual = default;
            float sexualMinors = default;
            float violence = default;
            float violenceGraphic = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("hate"u8))
                {
                    hate = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("hate/threatening"u8))
                {
                    hateThreatening = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("harassment"u8))
                {
                    harassment = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("harassment/threatening"u8))
                {
                    harassmentThreatening = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("self-harm"u8))
                {
                    selfHarm = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("self-harm/intent"u8))
                {
                    selfHarmIntent = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("self-harm/instructions"u8))
                {
                    selfHarmInstructions = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("sexual"u8))
                {
                    sexual = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("sexual/minors"u8))
                {
                    sexualMinors = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("violence"u8))
                {
                    violence = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("violence/graphic"u8))
                {
                    violenceGraphic = property.Value.GetSingle();
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalModerationCategoryScores(
                hate,
                hateThreatening,
                harassment,
                harassmentThreatening,
                selfHarm,
                selfHarmIntent,
                selfHarmInstructions,
                sexual,
                sexualMinors,
                violence,
                violenceGraphic,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalModerationCategoryScores>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalModerationCategoryScores>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalModerationCategoryScores)} does not support writing '{options.Format}' format.");
            }
        }

        InternalModerationCategoryScores IPersistableModel<InternalModerationCategoryScores>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalModerationCategoryScores>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalModerationCategoryScores(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalModerationCategoryScores)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalModerationCategoryScores>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalModerationCategoryScores FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalModerationCategoryScores(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}