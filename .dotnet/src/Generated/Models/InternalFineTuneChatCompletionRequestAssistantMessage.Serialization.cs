// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;
using OpenAI.Chat;

namespace OpenAI.FineTuning
{
    internal partial class InternalFineTuneChatCompletionRequestAssistantMessage : IJsonModel<InternalFineTuneChatCompletionRequestAssistantMessage>
    {
        void IJsonModel<InternalFineTuneChatCompletionRequestAssistantMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalFineTuneChatCompletionRequestAssistantMessage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalFineTuneChatCompletionRequestAssistantMessage)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
        }

        InternalFineTuneChatCompletionRequestAssistantMessage IJsonModel<InternalFineTuneChatCompletionRequestAssistantMessage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalFineTuneChatCompletionRequestAssistantMessage)JsonModelCreateCore(ref reader, options);

        protected override ChatMessage JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalFineTuneChatCompletionRequestAssistantMessage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalFineTuneChatCompletionRequestAssistantMessage)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalFineTuneChatCompletionRequestAssistantMessage(document.RootElement, options);
        }

        internal static InternalFineTuneChatCompletionRequestAssistantMessage DeserializeInternalFineTuneChatCompletionRequestAssistantMessage(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ChatMessageContent content = default;
            ChatMessageRole role = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            string refusal = default;
            string participantName = default;
            IList<ChatToolCall> toolCalls = default;
            ChatFunctionCall functionCall = default;
            ChatOutputAudioReference outputAudioReference = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("content"u8))
                {
                    DeserializeContentValue(prop, ref content);
                    continue;
                }
                if (prop.NameEquals("role"u8))
                {
                    role = prop.Value.GetString().ToChatMessageRole();
                    continue;
                }
                if (prop.NameEquals("refusal"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        refusal = null;
                        continue;
                    }
                    refusal = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    participantName = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("tool_calls"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ChatToolCall> array = new List<ChatToolCall>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ChatToolCall.DeserializeChatToolCall(item, options));
                    }
                    toolCalls = array;
                    continue;
                }
                if (prop.NameEquals("function_call"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        functionCall = null;
                        continue;
                    }
                    functionCall = ChatFunctionCall.DeserializeChatFunctionCall(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("audio"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        outputAudioReference = null;
                        continue;
                    }
                    outputAudioReference = ChatOutputAudioReference.DeserializeChatOutputAudioReference(prop.Value, options);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalFineTuneChatCompletionRequestAssistantMessage(
                content,
                role,
                additionalBinaryDataProperties,
                refusal,
                participantName,
                toolCalls ?? new ChangeTrackingList<ChatToolCall>(),
                functionCall,
                outputAudioReference);
        }

        BinaryData IPersistableModel<InternalFineTuneChatCompletionRequestAssistantMessage>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalFineTuneChatCompletionRequestAssistantMessage>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalFineTuneChatCompletionRequestAssistantMessage)} does not support writing '{options.Format}' format.");
            }
        }

        InternalFineTuneChatCompletionRequestAssistantMessage IPersistableModel<InternalFineTuneChatCompletionRequestAssistantMessage>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalFineTuneChatCompletionRequestAssistantMessage)PersistableModelCreateCore(data, options);

        protected override ChatMessage PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalFineTuneChatCompletionRequestAssistantMessage>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalFineTuneChatCompletionRequestAssistantMessage(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalFineTuneChatCompletionRequestAssistantMessage)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalFineTuneChatCompletionRequestAssistantMessage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalFineTuneChatCompletionRequestAssistantMessage internalFineTuneChatCompletionRequestAssistantMessage)
        {
            if (internalFineTuneChatCompletionRequestAssistantMessage == null)
            {
                return null;
            }
            return BinaryContent.Create(internalFineTuneChatCompletionRequestAssistantMessage, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalFineTuneChatCompletionRequestAssistantMessage(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalFineTuneChatCompletionRequestAssistantMessage(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
