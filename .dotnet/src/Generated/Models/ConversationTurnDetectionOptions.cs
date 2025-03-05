// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationTurnDetectionOptions
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        private protected ConversationTurnDetectionOptions(ConversationTurnDetectionKind kind)
        {
            Kind = kind;
        }

        internal ConversationTurnDetectionOptions(ConversationTurnDetectionKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Kind = kind;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
