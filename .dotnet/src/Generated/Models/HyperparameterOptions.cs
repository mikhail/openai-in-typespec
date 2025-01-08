// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    internal partial class HyperparameterOptions
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public HyperparameterOptions()
        {
        }

        internal HyperparameterOptions(FineTuning.HyperparameterCycleCount cycleCount, FineTuning.HyperparameterBatchSize batchSize, FineTuning.HyperparameterLearningRateMultiplier learningRate, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            CycleCount = cycleCount;
            BatchSize = batchSize;
            LearningRate = learningRate;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
