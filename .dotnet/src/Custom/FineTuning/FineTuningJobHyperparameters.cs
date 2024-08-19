﻿using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning;


[CodeGenModel("FineTuningJobHyperparameters")]
public readonly partial struct FineTuningJobHyperparameters
{
    private static readonly BinaryData Auto = new("\"auto\"");

    [CodeGenMember("NEpochs")]
    internal BinaryData CycleCount { get; }    
    internal BinaryData BatchSize { get; }

    internal BinaryData LearningRateMultiplier { get; }

    public IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }

    private float HandleDefaults(BinaryData data)
    {
        if (data is null)
        {
            throw new ArgumentNullException("This hyperparameter is not set. Values for BatchSize and LearningRateMultiplier are not available in responses.");
        }

        if (data.ToString() == Auto.ToString())
        {
            return 0;
        }

        try
        {
            return float.Parse(data.ToString());
        }
        catch (FormatException)
        {
            throw new FormatException($"Hyperparameter expected a number or \"auto\" string. Got {data}");
        }
    }

    public int GetCycleCount() => (int) HandleDefaults(BinaryData.FromString(CycleCount.ToString()));
    public int GetBatchSize() => (int) HandleDefaults(BatchSize);
    public float GetLearningRateMultiplier() => HandleDefaults(LearningRateMultiplier);
}
