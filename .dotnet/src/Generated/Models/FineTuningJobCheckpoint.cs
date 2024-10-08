// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    public partial class FineTuningJobCheckpoint
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal FineTuningJobCheckpoint(string id, DateTimeOffset createdAt, string fineTunedModelCheckpointId, int stepNumber, CheckpointMetrics metrics, string jobId)
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
            JobId = jobId;
        }

        internal FineTuningJobCheckpoint(string id, DateTimeOffset createdAt, string fineTunedModelCheckpointId, int stepNumber, CheckpointMetrics metrics, string jobId, string @object, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            CreatedAt = createdAt;
            FineTunedModelCheckpointId = fineTunedModelCheckpointId;
            StepNumber = stepNumber;
            Metrics = metrics;
            JobId = jobId;
            _object = @object;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal FineTuningJobCheckpoint()
        {
        }
    }
}
