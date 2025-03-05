// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeServerVadTurnDetection : ConversationTurnDetectionOptions
    {
        public InternalRealtimeServerVadTurnDetection() : base(ConversationTurnDetectionKind.ServerVoiceActivityDetection)
        {
        }

        internal InternalRealtimeServerVadTurnDetection(ConversationTurnDetectionKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties, float? threshold, TimeSpan? prefixPaddingMs, TimeSpan? silenceDurationMs, bool? createResponse) : base(kind, additionalBinaryDataProperties)
        {
            Threshold = threshold;
            PrefixPaddingMs = prefixPaddingMs;
            SilenceDurationMs = silenceDurationMs;
            CreateResponse = createResponse;
        }

        public float? Threshold { get; set; }

        public TimeSpan? PrefixPaddingMs { get; set; }

        public TimeSpan? SilenceDurationMs { get; set; }

        public bool? CreateResponse { get; set; }
    }
}
