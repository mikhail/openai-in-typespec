// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    public partial class FineTuningCheckpoint
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal FineTuningCheckpoint(string id, DateTimeOffset createdAt, string fineTunedModelCheckpointId, int stepNumber, FineTuningCheckpointMetrics metrics, string jobId)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(fineTunedModelCheckpointId, nameof(fineTunedModelCheckpointId));
            Argument.AssertNotNull(metrics, nameof(metrics));
            Argument.AssertNotNull(jobId, nameof(jobId));

            Id = id;
            CreatedAt = createdAt;
            FineTunedModelCheckpointId = fineTunedModelCheckpointId;
            StepNumber = stepNumber;
            Metrics = metrics;
            OperationId = jobId;
        }

        internal FineTuningCheckpoint(string id, DateTimeOffset createdAt, string fineTunedModelCheckpointId, int stepNumber, FineTuningCheckpointMetrics metrics, string jobId, string @object, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            CreatedAt = createdAt;
            FineTunedModelCheckpointId = fineTunedModelCheckpointId;
            StepNumber = stepNumber;
            Metrics = metrics;
            OperationId = jobId;
            _object = @object;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal FineTuningCheckpoint()
        {
        }
    }
}
