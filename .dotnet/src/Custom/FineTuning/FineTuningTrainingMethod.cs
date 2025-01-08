using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestMethodType")]
internal readonly partial struct InternalCreateFineTuningJobRequestMethodType { }

[CodeGenModel("FineTuningJobRequestMethodSupervised")]
internal partial class InternalFineTuningJobRequestMethodSupervised { }

[CodeGenModel("FineTuningJobRequestMethodSupervisedSupervised")]
internal partial class InternalFineTuningJobRequestMethodSupervisedSupervised { }

[CodeGenModel("FineTuningJobRequestMethodSupervisedSupervisedHyperparameters")]
internal partial class InternalFineTuningJobRequestMethodSupervisedSupervisedHyperparameters { }

[CodeGenModel("FineTuningJobRequestMethodDpo")]
internal partial class InternalFineTuningJobRequestMethodDpo { }

[CodeGenModel("FineTuningJobRequestMethodDpoDpo")]
internal partial class InternalFineTuningJobRequestMethodDpoDpo { }

[CodeGenModel("FineTuningJobRequestMethodDpoDpoHyperparameters")]
internal partial class InternalFineTuningJobRequestMethodDpoDpoHyperparameters { }

[CodeGenModel("FineTuningJobRequestMethodReinforcement")]
internal partial class InternalFineTuningJobRequestMethodReinforcement { }

[CodeGenModel("FineTuningJobRequestMethodReinforcementReinforcement")]
internal partial class InternalFineTuningJobRequestMethodReinforcementReinforcement { }

[CodeGenModel("FineTuningJobRequestMethodReinforcementReinforcementHyperparameters")]
internal partial class InternalFineTuningJobRequestMethodReinforcementReinforcementHyperparameters { }

[CodeGenModel("UnknownFineTuningJobRequestMethod")]
internal partial class UnknownFineTuningJobRequestMethod { }

[CodeGenModel("FineTuningJobRequestMethod")]
public partial class FineTuningTrainingMethod
{
    public static FineTuningTrainingMethod CreateSupervised(
        HyperparameterBatchSize batchSize = null,
        HyperparameterCycleCount cycleCount = null,
        HyperparameterLearningRate learningRate = null)
    {
        var hyperparameters = new InternalFineTuningJobRequestMethodSupervisedSupervisedHyperparameters
        {
            BatchSize = batchSize,
            CycleCount = cycleCount,
            LearningRate = learningRate
        };
        return new InternalFineTuningJobRequestMethodSupervised
        {
            Hyperparameters = hyperparameters
        };
    }

    public static FineTuningTrainingMethod CreateDirectPreferenceOptimization(
        HyperparameterBatchSize batchSize = null,
        HyperparameterCycleCount cycleCount = null,
        HyperparameterLearningRate learningRate = null,
        HyperparameterBetaFactor betaFactor = null)
    {
        var hyperparameters = new InternalFineTuningJobRequestMethodDpoDpoHyperparameters
        {
            BatchSize = batchSize,
            CycleCount = cycleCount,
            LearningRate = learningRate,
            BetaFactor = betaFactor
        };
        return new InternalFineTuningJobRequestMethodDpo
        {
            Hyperparameters = hyperparameters
        };
    }

    public static FineTuningTrainingMethod CreateReinforcement(
        HyperparameterBatchSize batchSize = null,
        HyperparameterCycleCount cycleCount = null,
        HyperparameterLearningRate learningRate = null)
    {
        var hyperparameters = new InternalFineTuningJobRequestMethodReinforcementReinforcementHyperparameters
        {
            BatchSize = batchSize,
            CycleCount = cycleCount,
            LearningRate = learningRate
        };
        return new InternalFineTuningJobRequestMethodReinforcement
        {
            Hyperparameters = hyperparameters
        };
    }
}