// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Chat
{
    internal partial class InternalChatCompletionResponseMessage
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalChatCompletionResponseMessage(string refusal, ChatMessageContent content)
        {
            Refusal = refusal;
            ToolCalls = new ChangeTrackingList<ChatToolCall>();
            Content = content;
        }

        internal InternalChatCompletionResponseMessage(string refusal, IReadOnlyList<ChatToolCall> toolCalls, Chat.ChatMessageRole role, ChatMessageContent content, ChatFunctionCall functionCall, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Refusal = refusal;
            ToolCalls = toolCalls;
            Role = role;
            Content = content;
            FunctionCall = functionCall;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Refusal { get; }

        public IReadOnlyList<ChatToolCall> ToolCalls { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
