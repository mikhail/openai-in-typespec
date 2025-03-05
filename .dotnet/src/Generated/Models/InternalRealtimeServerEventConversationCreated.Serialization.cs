// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeServerEventConversationCreated : IJsonModel<InternalRealtimeServerEventConversationCreated>
    {
        internal InternalRealtimeServerEventConversationCreated()
        {
        }

        void IJsonModel<InternalRealtimeServerEventConversationCreated>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerEventConversationCreated>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeServerEventConversationCreated)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("conversation") != true)
            {
                writer.WritePropertyName("conversation"u8);
                writer.WriteObjectValue(Conversation, options);
            }
        }

        InternalRealtimeServerEventConversationCreated IJsonModel<InternalRealtimeServerEventConversationCreated>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeServerEventConversationCreated)JsonModelCreateCore(ref reader, options);

        protected override ConversationUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerEventConversationCreated>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeServerEventConversationCreated)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeServerEventConversationCreated(document.RootElement, options);
        }

        internal static InternalRealtimeServerEventConversationCreated DeserializeInternalRealtimeServerEventConversationCreated(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string eventId = default;
            ConversationUpdateKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            InternalRealtimeServerEventConversationCreatedConversation conversation = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("event_id"u8))
                {
                    eventId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    kind = prop.Value.GetString().ToConversationUpdateKind();
                    continue;
                }
                if (prop.NameEquals("conversation"u8))
                {
                    conversation = InternalRealtimeServerEventConversationCreatedConversation.DeserializeInternalRealtimeServerEventConversationCreatedConversation(prop.Value, options);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalRealtimeServerEventConversationCreated(eventId, kind, additionalBinaryDataProperties, conversation);
        }

        BinaryData IPersistableModel<InternalRealtimeServerEventConversationCreated>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerEventConversationCreated>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeServerEventConversationCreated)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeServerEventConversationCreated IPersistableModel<InternalRealtimeServerEventConversationCreated>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeServerEventConversationCreated)PersistableModelCreateCore(data, options);

        protected override ConversationUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerEventConversationCreated>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeServerEventConversationCreated(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeServerEventConversationCreated)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeServerEventConversationCreated>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeServerEventConversationCreated internalRealtimeServerEventConversationCreated)
        {
            if (internalRealtimeServerEventConversationCreated == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRealtimeServerEventConversationCreated, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeServerEventConversationCreated(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeServerEventConversationCreated(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
