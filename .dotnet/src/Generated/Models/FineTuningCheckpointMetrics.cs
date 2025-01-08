// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    public partial class FineTuningCheckpointMetrics
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal FineTuningCheckpointMetrics()
        {
        }

        internal FineTuningCheckpointMetrics(float? trainLoss, float? trainMeanTokenAccuracy, float? validLoss, float? validMeanTokenAccuracy, float? fullValidLoss, float? fullValidMeanTokenAccuracy, int stepNumber, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            TrainLoss = trainLoss;
            TrainMeanTokenAccuracy = trainMeanTokenAccuracy;
            ValidLoss = validLoss;
            ValidMeanTokenAccuracy = validMeanTokenAccuracy;
            FullValidLoss = fullValidLoss;
            FullValidMeanTokenAccuracy = fullValidMeanTokenAccuracy;
            StepNumber = stepNumber;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public float? TrainLoss { get; }

        public float? TrainMeanTokenAccuracy { get; }

        public float? ValidLoss { get; }

        public float? ValidMeanTokenAccuracy { get; }

        public float? FullValidLoss { get; }

        public float? FullValidMeanTokenAccuracy { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
