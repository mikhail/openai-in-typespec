// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    public partial class ChatTokenUsage
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal ChatTokenUsage(int outputTokenCount, int inputTokenCount, int totalTokenCount)
        {
            OutputTokenCount = outputTokenCount;
            InputTokenCount = inputTokenCount;
            TotalTokenCount = totalTokenCount;
        }

        internal ChatTokenUsage(int outputTokenCount, int inputTokenCount, int totalTokenCount, ChatOutputTokenUsageDetails outputTokenDetails, ChatInputTokenUsageDetails inputTokenDetails, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            OutputTokenCount = outputTokenCount;
            InputTokenCount = inputTokenCount;
            TotalTokenCount = totalTokenCount;
            OutputTokenDetails = outputTokenDetails;
            InputTokenDetails = inputTokenDetails;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
