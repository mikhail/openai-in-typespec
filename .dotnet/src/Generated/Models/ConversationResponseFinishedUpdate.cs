// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationResponseFinishedUpdate : ConversationUpdate
    {
        internal ConversationResponseFinishedUpdate(string eventId, InternalRealtimeResponse internalResponse) : base(eventId)
        {
            Argument.AssertNotNull(internalResponse, nameof(internalResponse));

            Kind = ConversationUpdateKind.ResponseFinished;
            _internalResponse = internalResponse;
        }

        internal ConversationResponseFinishedUpdate(ConversationUpdateKind kind, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalRealtimeResponse internalResponse) : base(kind, eventId, serializedAdditionalRawData)
        {
            _internalResponse = internalResponse;
        }

        internal ConversationResponseFinishedUpdate()
        {
        }
    }
}
