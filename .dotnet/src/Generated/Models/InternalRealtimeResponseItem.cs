// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal abstract partial class InternalRealtimeResponseItem
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        private protected InternalRealtimeResponseItem(InternalRealtimeItemType @type, string id)
        {
            Type = @type;
            Id = id;
        }

        internal InternalRealtimeResponseItem(InternalRealtimeResponseItemObject @object, InternalRealtimeItemType @type, string id, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Object = @object;
            Type = @type;
            Id = id;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public InternalRealtimeResponseItemObject Object { get; } = "realtime.item";

        internal InternalRealtimeItemType Type { get; set; }

        public string Id { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
