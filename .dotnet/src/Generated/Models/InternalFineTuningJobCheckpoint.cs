// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    internal partial class InternalFineTuningJobCheckpoint
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal InternalFineTuningJobCheckpoint(string id, DateTimeOffset createdAt, string fineTunedModelCheckpoint, int stepNumber, InternalFineTuningJobCheckpointMetrics metrics, string fineTuningJobId)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(fineTunedModelCheckpoint, nameof(fineTunedModelCheckpoint));
            Argument.AssertNotNull(metrics, nameof(metrics));
            Argument.AssertNotNull(fineTuningJobId, nameof(fineTuningJobId));

            Id = id;
            CreatedAt = createdAt;
            FineTunedModelCheckpoint = fineTunedModelCheckpoint;
            StepNumber = stepNumber;
            Metrics = metrics;
            FineTuningJobId = fineTuningJobId;
        }

        internal InternalFineTuningJobCheckpoint(string id, DateTimeOffset createdAt, string fineTunedModelCheckpoint, int stepNumber, InternalFineTuningJobCheckpointMetrics metrics, string fineTuningJobId, InternalFineTuningJobCheckpointObject @object, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            CreatedAt = createdAt;
            FineTunedModelCheckpoint = fineTunedModelCheckpoint;
            StepNumber = stepNumber;
            Metrics = metrics;
            FineTuningJobId = fineTuningJobId;
            Object = @object;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal InternalFineTuningJobCheckpoint()
        {
        }

        public string Id { get; }
        public DateTimeOffset CreatedAt { get; }
        public string FineTunedModelCheckpoint { get; }
        public int StepNumber { get; }
        public InternalFineTuningJobCheckpointMetrics Metrics { get; }
        public string FineTuningJobId { get; }
        public InternalFineTuningJobCheckpointObject Object { get; } = InternalFineTuningJobCheckpointObject.FineTuningJobCheckpoint;
    }
}
