// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationInputTranscriptionFailedUpdate : ConversationUpdate
    {
        internal ConversationInputTranscriptionFailedUpdate(string eventId, string itemId, int contentIndex, InternalRealtimeServerEventConversationItemInputAudioTranscriptionFailedError error) : base(eventId)
        {
            Argument.AssertNotNull(eventId, nameof(eventId));
            Argument.AssertNotNull(itemId, nameof(itemId));
            Argument.AssertNotNull(error, nameof(error));

            Kind = ConversationUpdateKind.InputTranscriptionFailed;
            ItemId = itemId;
            ContentIndex = contentIndex;
            _error = error;
        }

        internal ConversationInputTranscriptionFailedUpdate(ConversationUpdateKind kind, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData, string itemId, int contentIndex, InternalRealtimeServerEventConversationItemInputAudioTranscriptionFailedError error) : base(kind, eventId, serializedAdditionalRawData)
        {
            ItemId = itemId;
            ContentIndex = contentIndex;
            _error = error;
        }

        internal ConversationInputTranscriptionFailedUpdate()
        {
        }

        public string ItemId { get; }
        public int ContentIndex { get; }
    }
}
