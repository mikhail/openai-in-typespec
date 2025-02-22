// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    public readonly partial struct FineTuningHyperparameters
    {
        private readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal FineTuningHyperparameters(BinaryData cycleCount, BinaryData batchSize, BinaryData learningRateMultiplier)
        {
            _CycleCount = cycleCount;
            _BatchSize = batchSize;
            _LearningRateMultiplier = learningRateMultiplier;
        }

        internal FineTuningHyperparameters(BinaryData cycleCount, BinaryData batchSize, BinaryData learningRateMultiplier, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            _CycleCount = cycleCount;
            _BatchSize = batchSize;
            _LearningRateMultiplier = learningRateMultiplier;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData => _additionalBinaryDataProperties;
    }
}
