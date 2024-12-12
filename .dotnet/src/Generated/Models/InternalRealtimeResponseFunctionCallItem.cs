// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeResponseFunctionCallItem : InternalRealtimeResponseItem
    {
        internal InternalRealtimeResponseFunctionCallItem(string id, string name, string callId, string arguments, ConversationItemStatus status) : base(InternalRealtimeItemType.FunctionCall, id)
        {
            Name = name;
            CallId = callId;
            Arguments = arguments;
            Status = status;
        }

        internal InternalRealtimeResponseFunctionCallItem(InternalRealtimeResponseItemObject @object, InternalRealtimeItemType @type, string id, IDictionary<string, BinaryData> additionalBinaryDataProperties, string name, string callId, string arguments, ConversationItemStatus status) : base(@object, @type, id, additionalBinaryDataProperties)
        {
            Name = name;
            CallId = callId;
            Arguments = arguments;
            Status = status;
        }

        public string Name { get; }

        public string CallId { get; }

        public string Arguments { get; }

        public ConversationItemStatus Status { get; }
    }
}
