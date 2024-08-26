namespace OpenAI.FineTuning;

// CUSTOM: Made internal.

[CodeGenModel("FineTuneChatCompletionRequestAssistantMessage")]
internal partial class InternalFineTuneChatCompletionRequestAssistantMessage { }

[CodeGenModel("FinetuneChatRequestInput")]
internal partial class InternalFinetuneChatRequestInput { }

[CodeGenModel("FinetuneCompletionRequestInput")]
internal partial class InternalFinetuneCompletionRequestInput { }

[CodeGenModel("FineTuningIntegration")]
internal partial class InternalFineTuningIntegration { }

[CodeGenModel("FineTuningIntegrationType")]
internal readonly partial struct InternalFineTuningIntegrationType { }

[CodeGenModel("FineTuningIntegrationWandb")]
internal partial class InternalFineTuningIntegrationWandb { }

[CodeGenModel("CreateFineTuningJobRequestWandbIntegrationWandb")]
internal partial class InternalCreateFineTuningJobRequestWandbIntegrationWandb
{
    [CodeGenMember("Project")]
    public string Project { get; set; }
}

[CodeGenModel("FineTuningJobObject")]
internal readonly partial struct InternalFineTuningJobObject { }

[CodeGenModel("FineTuningJobCheckpoint")]
internal partial class InternalFineTuningJobCheckpoint { }

[CodeGenModel("FineTuningJobCheckpointMetrics")]
internal partial class InternalFineTuningJobCheckpointMetrics { }

[CodeGenModel("FineTuningJobCheckpointObject")]
internal readonly partial struct InternalFineTuningJobCheckpointObject { }

[CodeGenModel("ListFineTuningJobCheckpointsResponse")]
internal partial class InternalListFineTuningJobCheckpointsResponse { }

[CodeGenModel("ListFineTuningJobCheckpointsResponseObject")]
internal readonly partial struct InternalListFineTuningJobCheckpointsResponseObject { }

[CodeGenModel("ListPaginatedFineTuningJobsResponse")]
internal partial class InternalListPaginatedFineTuningJobsResponse { }

[CodeGenModel("ListPaginatedFineTuningJobsResponseObject")]
internal readonly partial struct InternalListPaginatedFineTuningJobsResponseObject { }

[CodeGenModel("FineTuningJobHyperparametersBatchSizeChoiceEnum")]
internal readonly partial struct InternalFineTuningJobHyperparametersBatchSizeChoiceEnum { }

[CodeGenModel("FineTuningJobHyperparametersLearningRateMultiplierChoiceEnum")]
internal readonly partial struct InternalFineTuningJobHyperparametersLearningRateChoiceEnum { }

[CodeGenModel("FineTuningJobHyperparametersNEpochsChoiceEnum")]
internal readonly partial struct InternalFineTuningJobHyperparametersNEpochsChoiceEnum { }

[CodeGenModel("FineTuningIntegrationWandbWandb")]
internal partial class InternalFineTuningIntegrationWandbWandb { }

[CodeGenModel("UnknownCreateFineTuningJobRequestIntegration")]
internal partial class InternalUnknownCreateFineTuningJobRequestIntegration { }

[CodeGenModel("UnknownFineTuningIntegration")]
internal partial class InternalUnknownFineTuningIntegration { }
