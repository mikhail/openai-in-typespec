using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace OpenAI.FineTuning;

[CodeGenModel("FineTuneMethodType")]
internal readonly partial struct InternalFineTuneMethodType { }

[CodeGenModel("FineTuneSupervisedMethod")]
internal partial class InternalFineTuningJobRequestMethodSupervised { }

[CodeGenModel("FineTuningJobRequestMethodSupervisedSupervised")]
internal partial class InternalFineTuningJobRequestMethodSupervisedSupervised { }

[CodeGenModel("FineTuneSupervisedMethodHyperparameters")]
internal partial class InternalFineTuneSupervisedMethodHyperparameters { }

[CodeGenModel("FineTuneDPOMethod")]
internal partial class InternalFineTuningJobRequestMethodDpo { }

[CodeGenModel("FineTuningJobRequestMethodDpoDpo")]
internal partial class InternalFineTuningJobRequestMethodDpoDpo { }

[CodeGenModel("FineTuneDPOMethodHyperparameters")]
internal partial class InternalFineTuningJobRequestMethodDpoDpoHyperparameters { }

[CodeGenModel("UnknownFineTuningJobRequestMethod")]
internal partial class UnknownFineTuningJobRequestMethod { }

[CodeGenModel("FineTuneMethod")]
public partial class FineTuningTrainingMethod
{
    internal InternalFineTuneMethodType? Type { get; set; }

    internal InternalFineTuningJobRequestMethodSupervised Supervised { get; set; }

    internal InternalFineTuningJobRequestMethodDpo Dpo { get; set; }

    public static FineTuningTrainingMethod CreateSupervised(
        HyperparameterBatchSize batchSize = null,
        HyperparameterCycleCount cycleCount = null,
        HyperparameterLearningRate learningRate = null)
    {
        return new FineTuningTrainingMethod()
        {
            Supervised = new InternalFineTuningJobRequestMethodSupervised()
            {
                Hyperparameters = new InternalFineTuneSupervisedMethodHyperparameters()
                {
                    BatchSize = batchSize is not null ? ModelReaderWriter.Write(batchSize) : null,
                    NEpochs = cycleCount is not null ? ModelReaderWriter.Write(cycleCount) : null,
                    LearningRateMultiplier = learningRate is not null ? ModelReaderWriter.Write(learningRate) : null,
                },
            },
        };
    }

    public static FineTuningTrainingMethod CreateDirectPreferenceOptimization(
        HyperparameterBatchSize batchSize = null,
        HyperparameterCycleCount cycleCount = null,
        HyperparameterLearningRate learningRate = null,
        HyperparameterBetaFactor betaFactor = null)
    {
        return new FineTuningTrainingMethod()
        {
            Dpo = new InternalFineTuningJobRequestMethodDpo()
            {
                Hyperparameters = new InternalFineTuningJobRequestMethodDpoDpoHyperparameters()
                {
                    Beta = betaFactor is not null ? ModelReaderWriter.Write(betaFactor) : null,
                    BatchSize = batchSize is not null ? ModelReaderWriter.Write(batchSize) : null,
                    NEpochs = cycleCount is not null ? ModelReaderWriter.Write(cycleCount) : null,
                    LearningRateMultiplier = learningRate is not null ? ModelReaderWriter.Write(learningRate) : null,
                },
            },
        };
    }
}