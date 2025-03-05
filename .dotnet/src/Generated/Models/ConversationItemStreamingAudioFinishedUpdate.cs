// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationItemStreamingAudioFinishedUpdate : ConversationUpdate
    {
        internal ConversationItemStreamingAudioFinishedUpdate(string eventId, string responseId, string itemId, int outputIndex, int contentIndex) : base(eventId, ConversationUpdateKind.ItemStreamingPartAudioFinished)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
        }

        internal ConversationItemStreamingAudioFinishedUpdate(string eventId, ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties, string responseId, string itemId, int outputIndex, int contentIndex) : base(eventId, kind, additionalBinaryDataProperties)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
        }

        public string ResponseId { get; }

        public string ItemId { get; }

        public int OutputIndex { get; }

        public int ContentIndex { get; }
    }
}
