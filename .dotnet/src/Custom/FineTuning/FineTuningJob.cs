using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJob")]
public partial class FineTuningJob
{
    public FineTuningJob(string id, DateTimeOffset createdAt, FineTuningJobError error, string fineTunedModel, DateTimeOffset? finishedAt, FineTuningJobHyperparameters hyperparameters, string model, string organizationId, IEnumerable<string> resultFiles, FineTuningJobStatus status, int? trainedTokens, string trainingFile, string validationFile, int seed)
    {
        Id = id;
        CreatedAt = createdAt;
        Error = error;
        FineTunedModel = fineTunedModel;
        FinishedAt = finishedAt;
        Hyperparameters = hyperparameters;
        Model = model;
        OrganizationId = organizationId;
        ResultFiles = resultFiles.ToList();
        Status = status;
        TrainedTokens = trainedTokens;
        TrainingFile = trainingFile;
        ValidationFile = validationFile;
        Integrations = new ChangeTrackingList<InternalFineTuningIntegration>();
        Seed = seed;
    }
    internal static FineTuningJob FromResponse(PipelineResponse pipelineResponse)
    {
        using var document = JsonDocument.Parse(pipelineResponse.Content);
        return DeserializeFineTuningJob(document.RootElement);
    }
    public FineTuningJobStatus Status { get; }
    internal string Object { get; }  // make hidden 
    public FineTuningJobHyperparameters Hyperparameters { get; set; } = default;
    internal IReadOnlyList<InternalFineTuningIntegration> Integrations { get; }

    public string GetPlaygroundURL() {
        return $"https://platform.openai.com/playground/chat?models={Model}&models={FineTunedModel}";
    }
}