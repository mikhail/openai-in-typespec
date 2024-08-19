using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparameters")]
public partial class HyperparameterOptions
{
    [CodeGenMember("NEpochs")]
    public BinaryData CycleCount { 
        get { return this._cycleCount; } 
        set { this._cycleCount = new HyperparameterCycleCount(value); }
    }
    private HyperparameterCycleCount _cycleCount;

    [CodeGenMember("BatchSize")]
    public HyperparameterBatchSize BatchSize { get; }

    [CodeGenMember("LearningRateMultiplier")]
    public HyperparameterLearningRate LearningRate { get; }

    public HyperparameterOptions(HyperparameterCycleCount cycleCount = default, HyperparameterBatchSize batchSize = default, HyperparameterLearningRate learningRate = default, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
    {
        _cycleCount = cycleCount;
        BatchSize = batchSize;
        LearningRate = learningRate;
        SerializedAdditionalRawData = serializedAdditionalRawData;
    }

}