// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI.Chat
{
    public partial class ChatMessageContext : IJsonModel<ChatMessageContext>
    {
        void IJsonModel<ChatMessageContext>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatMessageContext>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatMessageContext)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("intent") != true && Optional.IsDefined(Intent))
            {
                writer.WritePropertyName("intent"u8);
                writer.WriteStringValue(Intent);
            }
            if (SerializedAdditionalRawData?.ContainsKey("citations") != true && Optional.IsCollectionDefined(Citations))
            {
                writer.WritePropertyName("citations"u8);
                writer.WriteStartArray();
                foreach (var item in Citations)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData?.ContainsKey("all_retrieved_documents") != true && Optional.IsDefined(RetrievedDocuments))
            {
                writer.WritePropertyName("all_retrieved_documents"u8);
                writer.WriteObjectValue<ChatRetrievedDocument>(RetrievedDocuments, options);
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

        ChatMessageContext IJsonModel<ChatMessageContext>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatMessageContext>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatMessageContext)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeChatMessageContext(document.RootElement, options);
        }

        internal static ChatMessageContext DeserializeChatMessageContext(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string intent = default;
            IReadOnlyList<ChatCitation> citations = default;
            ChatRetrievedDocument allRetrievedDocuments = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("intent"u8))
                {
                    intent = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("citations"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ChatCitation> array = new List<ChatCitation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ChatCitation.DeserializeChatCitation(item, options));
                    }
                    citations = array;
                    continue;
                }
                if (property.NameEquals("all_retrieved_documents"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    allRetrievedDocuments = ChatRetrievedDocument.DeserializeChatRetrievedDocument(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ChatMessageContext(intent, citations ?? new ChangeTrackingList<ChatCitation>(), allRetrievedDocuments, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ChatMessageContext>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatMessageContext>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ChatMessageContext)} does not support writing '{options.Format}' format.");
            }
        }

        ChatMessageContext IPersistableModel<ChatMessageContext>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatMessageContext>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeChatMessageContext(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ChatMessageContext)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ChatMessageContext>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static ChatMessageContext FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeChatMessageContext(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}