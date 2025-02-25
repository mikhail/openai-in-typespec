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
    public partial class RunCreationOptions : IJsonModel<RunCreationOptions>
    {
        void IJsonModel<RunCreationOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunCreationOptions)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("assistant_id") != true)
            {
                writer.WritePropertyName("assistant_id"u8);
                writer.WriteStringValue(AssistantId);
            }
            if (Optional.IsDefined(Stream) && _additionalBinaryDataProperties?.ContainsKey("stream") != true)
            {
                if (Stream != null)
                {
                    writer.WritePropertyName("stream"u8);
                    writer.WriteBooleanValue(Stream.Value);
                }
                else
                {
                    writer.WriteNull("stream"u8);
                }
            }
            if (Optional.IsDefined(ResponseFormat) && _additionalBinaryDataProperties?.ContainsKey("response_format") != true)
            {
                if (ResponseFormat != null)
                {
                    writer.WritePropertyName("response_format"u8);
                    writer.WriteObjectValue<AssistantResponseFormat>(ResponseFormat, options);
                }
                else
                {
                    writer.WriteNull("responseFormat"u8);
                }
            }
            if (Optional.IsDefined(ModelOverride) && _additionalBinaryDataProperties?.ContainsKey("model") != true)
            {
                if (ModelOverride != null)
                {
                    writer.WritePropertyName("model"u8);
                    writer.WriteStringValue(ModelOverride);
                }
                else
                {
                    writer.WriteNull("model"u8);
                }
            }
            if (Optional.IsDefined(InstructionsOverride) && _additionalBinaryDataProperties?.ContainsKey("instructions") != true)
            {
                if (InstructionsOverride != null)
                {
                    writer.WritePropertyName("instructions"u8);
                    writer.WriteStringValue(InstructionsOverride);
                }
                else
                {
                    writer.WriteNull("instructions"u8);
                }
            }
            if (Optional.IsDefined(AdditionalInstructions) && _additionalBinaryDataProperties?.ContainsKey("additional_instructions") != true)
            {
                if (AdditionalInstructions != null)
                {
                    writer.WritePropertyName("additional_instructions"u8);
                    writer.WriteStringValue(AdditionalInstructions);
                }
                else
                {
                    writer.WriteNull("additionalInstructions"u8);
                }
            }
            if (Optional.IsCollectionDefined(InternalMessages) && _additionalBinaryDataProperties?.ContainsKey("additional_messages") != true)
            {
                if (InternalMessages != null)
                {
                    writer.WritePropertyName("additional_messages"u8);
                    writer.WriteStartArray();
                    foreach (MessageCreationOptions item in InternalMessages)
                    {
                        writer.WriteObjectValue(item, options);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("additionalMessages"u8);
                }
            }
            if (Optional.IsDefined(AllowParallelToolCalls) && _additionalBinaryDataProperties?.ContainsKey("parallel_tool_calls") != true)
            {
                writer.WritePropertyName("parallel_tool_calls"u8);
                writer.WriteBooleanValue(AllowParallelToolCalls.Value);
            }
            if (Optional.IsCollectionDefined(ToolsOverride) && _additionalBinaryDataProperties?.ContainsKey("tools") != true)
            {
                if (ToolsOverride != null)
                {
                    writer.WritePropertyName("tools"u8);
                    writer.WriteStartArray();
                    foreach (ToolDefinition item in ToolsOverride)
                    {
                        writer.WriteObjectValue(item, options);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("tools"u8);
                }
            }
            if (Optional.IsCollectionDefined(Metadata) && _additionalBinaryDataProperties?.ContainsKey("metadata") != true)
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
            if (Optional.IsDefined(Temperature) && _additionalBinaryDataProperties?.ContainsKey("temperature") != true)
            {
                if (Temperature != null)
                {
                    writer.WritePropertyName("temperature"u8);
                    writer.WriteNumberValue(Temperature.Value);
                }
                else
                {
                    writer.WriteNull("temperature"u8);
                }
            }
            if (Optional.IsDefined(NucleusSamplingFactor) && _additionalBinaryDataProperties?.ContainsKey("top_p") != true)
            {
                if (NucleusSamplingFactor != null)
                {
                    writer.WritePropertyName("top_p"u8);
                    writer.WriteNumberValue(NucleusSamplingFactor.Value);
                }
                else
                {
                    writer.WriteNull("topP"u8);
                }
            }
            if (Optional.IsDefined(MaxInputTokenCount) && _additionalBinaryDataProperties?.ContainsKey("max_prompt_tokens") != true)
            {
                if (MaxInputTokenCount != null)
                {
                    writer.WritePropertyName("max_prompt_tokens"u8);
                    writer.WriteNumberValue(MaxInputTokenCount.Value);
                }
                else
                {
                    writer.WriteNull("maxPromptTokens"u8);
                }
            }
            if (Optional.IsDefined(MaxOutputTokenCount) && _additionalBinaryDataProperties?.ContainsKey("max_completion_tokens") != true)
            {
                if (MaxOutputTokenCount != null)
                {
                    writer.WritePropertyName("max_completion_tokens"u8);
                    writer.WriteNumberValue(MaxOutputTokenCount.Value);
                }
                else
                {
                    writer.WriteNull("maxCompletionTokens"u8);
                }
            }
            if (Optional.IsDefined(TruncationStrategy) && _additionalBinaryDataProperties?.ContainsKey("truncation_strategy") != true)
            {
                if (TruncationStrategy != null)
                {
                    writer.WritePropertyName("truncation_strategy"u8);
                    writer.WriteObjectValue<RunTruncationStrategy>(TruncationStrategy, options);
                }
                else
                {
                    writer.WriteNull("truncationStrategy"u8);
                }
            }
            if (Optional.IsDefined(ToolConstraint) && _additionalBinaryDataProperties?.ContainsKey("tool_choice") != true)
            {
                if (ToolConstraint != null)
                {
                    writer.WritePropertyName("tool_choice"u8);
                    this.SerializeToolConstraint(writer, options);
                }
                else
                {
                    writer.WriteNull("toolChoice"u8);
                }
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

        RunCreationOptions IJsonModel<RunCreationOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual RunCreationOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunCreationOptions)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRunCreationOptions(document.RootElement, options);
        }

        internal static RunCreationOptions DeserializeRunCreationOptions(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string assistantId = default;
            bool? stream = default;
            AssistantResponseFormat responseFormat = default;
            string modelOverride = default;
            string instructionsOverride = default;
            string additionalInstructions = default;
            IList<MessageCreationOptions> internalMessages = default;
            bool? allowParallelToolCalls = default;
            IList<ToolDefinition> toolsOverride = default;
            IDictionary<string, string> metadata = default;
            float? temperature = default;
            float? nucleusSamplingFactor = default;
            int? maxInputTokenCount = default;
            int? maxOutputTokenCount = default;
            RunTruncationStrategy truncationStrategy = default;
            ToolConstraint toolConstraint = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("assistant_id"u8))
                {
                    assistantId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("stream"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        stream = null;
                        continue;
                    }
                    stream = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("response_format"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        responseFormat = null;
                        continue;
                    }
                    responseFormat = AssistantResponseFormat.DeserializeAssistantResponseFormat(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("model"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        modelOverride = null;
                        continue;
                    }
                    modelOverride = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("instructions"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        instructionsOverride = null;
                        continue;
                    }
                    instructionsOverride = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("additional_instructions"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        additionalInstructions = null;
                        continue;
                    }
                    additionalInstructions = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("additional_messages"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MessageCreationOptions> array = new List<MessageCreationOptions>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(MessageCreationOptions.DeserializeMessageCreationOptions(item, options));
                    }
                    internalMessages = array;
                    continue;
                }
                if (prop.NameEquals("parallel_tool_calls"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    allowParallelToolCalls = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("tools"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ToolDefinition> array = new List<ToolDefinition>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ToolDefinition.DeserializeToolDefinition(item, options));
                    }
                    toolsOverride = array;
                    continue;
                }
                if (prop.NameEquals("metadata"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
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
                if (prop.NameEquals("temperature"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        temperature = null;
                        continue;
                    }
                    temperature = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("top_p"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        nucleusSamplingFactor = null;
                        continue;
                    }
                    nucleusSamplingFactor = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("max_prompt_tokens"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxInputTokenCount = null;
                        continue;
                    }
                    maxInputTokenCount = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("max_completion_tokens"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxOutputTokenCount = null;
                        continue;
                    }
                    maxOutputTokenCount = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("truncation_strategy"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        truncationStrategy = null;
                        continue;
                    }
                    truncationStrategy = RunTruncationStrategy.DeserializeRunTruncationStrategy(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("tool_choice"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        toolConstraint = null;
                        continue;
                    }
                    toolConstraint = ToolConstraint.DeserializeToolConstraint(prop.Value, options);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new RunCreationOptions(
                assistantId,
                stream,
                responseFormat,
                modelOverride,
                instructionsOverride,
                additionalInstructions,
                internalMessages ?? new ChangeTrackingList<MessageCreationOptions>(),
                allowParallelToolCalls,
                toolsOverride ?? new ChangeTrackingList<ToolDefinition>(),
                metadata ?? new ChangeTrackingDictionary<string, string>(),
                temperature,
                nucleusSamplingFactor,
                maxInputTokenCount,
                maxOutputTokenCount,
                truncationStrategy,
                toolConstraint,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<RunCreationOptions>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RunCreationOptions)} does not support writing '{options.Format}' format.");
            }
        }

        RunCreationOptions IPersistableModel<RunCreationOptions>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual RunCreationOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeRunCreationOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RunCreationOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RunCreationOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(RunCreationOptions runCreationOptions)
        {
            if (runCreationOptions == null)
            {
                return null;
            }
            return BinaryContent.Create(runCreationOptions, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator RunCreationOptions(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeRunCreationOptions(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
