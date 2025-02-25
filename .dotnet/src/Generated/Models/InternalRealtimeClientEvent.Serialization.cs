// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    [PersistableModelProxy(typeof(UnknownRealtimeClientEvent))]
    internal abstract partial class InternalRealtimeClientEvent : IJsonModel<InternalRealtimeClientEvent>
    {
        internal InternalRealtimeClientEvent()
        {
        }

        void IJsonModel<InternalRealtimeClientEvent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeClientEvent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeClientEvent)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Kind.ToString());
            }
            if (Optional.IsDefined(EventId) && _additionalBinaryDataProperties?.ContainsKey("event_id") != true)
            {
                writer.WritePropertyName("event_id"u8);
                writer.WriteStringValue(EventId);
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

        InternalRealtimeClientEvent IJsonModel<InternalRealtimeClientEvent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalRealtimeClientEvent JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeClientEvent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeClientEvent)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeClientEvent(document.RootElement, options);
        }

        internal static InternalRealtimeClientEvent DeserializeInternalRealtimeClientEvent(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("type"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "session.update":
                        return InternalRealtimeClientEventSessionUpdate.DeserializeInternalRealtimeClientEventSessionUpdate(element, options);
                    case "input_audio_buffer.append":
                        return InternalRealtimeClientEventInputAudioBufferAppend.DeserializeInternalRealtimeClientEventInputAudioBufferAppend(element, options);
                    case "input_audio_buffer.commit":
                        return InternalRealtimeClientEventInputAudioBufferCommit.DeserializeInternalRealtimeClientEventInputAudioBufferCommit(element, options);
                    case "input_audio_buffer.clear":
                        return InternalRealtimeClientEventInputAudioBufferClear.DeserializeInternalRealtimeClientEventInputAudioBufferClear(element, options);
                    case "conversation.item.create":
                        return InternalRealtimeClientEventConversationItemCreate.DeserializeInternalRealtimeClientEventConversationItemCreate(element, options);
                    case "conversation.item.truncate":
                        return InternalRealtimeClientEventConversationItemTruncate.DeserializeInternalRealtimeClientEventConversationItemTruncate(element, options);
                    case "conversation.item.delete":
                        return InternalRealtimeClientEventConversationItemDelete.DeserializeInternalRealtimeClientEventConversationItemDelete(element, options);
                    case "response.create":
                        return InternalRealtimeClientEventResponseCreate.DeserializeInternalRealtimeClientEventResponseCreate(element, options);
                    case "response.cancel":
                        return InternalRealtimeClientEventResponseCancel.DeserializeInternalRealtimeClientEventResponseCancel(element, options);
                }
            }
            return UnknownRealtimeClientEvent.DeserializeUnknownRealtimeClientEvent(element, options);
        }

        BinaryData IPersistableModel<InternalRealtimeClientEvent>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeClientEvent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeClientEvent)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeClientEvent IPersistableModel<InternalRealtimeClientEvent>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalRealtimeClientEvent PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeClientEvent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeClientEvent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeClientEvent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeClientEvent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeClientEvent internalRealtimeClientEvent)
        {
            if (internalRealtimeClientEvent == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRealtimeClientEvent, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeClientEvent(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeClientEvent(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
