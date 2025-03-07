// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    public partial class AssistantChatMessage : ChatMessage
    {
        internal AssistantChatMessage(ChatMessageContent content, ChatMessageRole role, IDictionary<string, BinaryData> additionalBinaryDataProperties, string refusal, string participantName, IList<ChatToolCall> toolCalls, ChatFunctionCall functionCall, ChatOutputAudioReference outputAudioReference) : base(content, role, additionalBinaryDataProperties)
        {
            Refusal = refusal;
            ParticipantName = participantName;
            ToolCalls = toolCalls;
            FunctionCall = functionCall;
            OutputAudioReference = outputAudioReference;
        }

        public string Refusal { get; set; }
    }
}
