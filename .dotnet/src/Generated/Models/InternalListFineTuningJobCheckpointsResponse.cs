// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.FineTuning
{
    internal partial class InternalListFineTuningJobCheckpointsResponse
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalListFineTuningJobCheckpointsResponse(IEnumerable<FineTuningCheckpoint> data, bool hasMore)
        {
            Data = data.ToList();
            HasMore = hasMore;
        }

        internal InternalListFineTuningJobCheckpointsResponse(IList<FineTuningCheckpoint> data, InternalListFineTuningJobCheckpointsResponseObject @object, string firstId, string lastId, bool hasMore, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Data = data;
            Object = @object;
            FirstId = firstId;
            LastId = lastId;
            HasMore = hasMore;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public IList<FineTuningCheckpoint> Data { get; }

        public InternalListFineTuningJobCheckpointsResponseObject Object { get; } = "list";

        public string FirstId { get; }

        public string LastId { get; }

        public bool HasMore { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
