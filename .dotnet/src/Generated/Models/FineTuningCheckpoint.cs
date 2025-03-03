// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    public partial class FineTuningCheckpoint
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal FineTuningCheckpoint(string checkpointId, DateTimeOffset createdAt, string fineTunedModelCheckpointId, int stepNumber, FineTuningCheckpointMetrics metrics, string jobId)
        {
            CheckpointId = checkpointId;
            CreatedAt = createdAt;
            FineTunedModelCheckpointId = fineTunedModelCheckpointId;
            StepNumber = stepNumber;
            Metrics = metrics;
            JobId = jobId;
        }

        internal FineTuningCheckpoint(string checkpointId, DateTimeOffset createdAt, string fineTunedModelCheckpointId, int stepNumber, FineTuningCheckpointMetrics metrics, string jobId, string @object, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            CheckpointId = checkpointId;
            CreatedAt = createdAt;
            FineTunedModelCheckpointId = fineTunedModelCheckpointId;
            StepNumber = stepNumber;
            Metrics = metrics;
            JobId = jobId;
            _object = @object;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
