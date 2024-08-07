// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using OpenAI.Models;

namespace OpenAI.FineTuning
{
    public partial class FineTuningJob
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal FineTuningJob(string id, DateTimeOffset createdAt, FineTuningJobError error, string fineTunedModel, DateTimeOffset? finishedAt, FineTuningJobHyperparameters hyperparameters, string model, string organizationId, IEnumerable<string> resultFiles, FineTuningJobStatus status, int? trainedTokens, string trainingFile, string validationFile, int seed)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(model, nameof(model));
            Argument.AssertNotNull(organizationId, nameof(organizationId));
            Argument.AssertNotNull(resultFiles, nameof(resultFiles));
            Argument.AssertNotNull(trainingFile, nameof(trainingFile));

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

        internal FineTuningJob(string id, DateTimeOffset createdAt, FineTuningJobError error, string fineTunedModel, DateTimeOffset? finishedAt, FineTuningJobHyperparameters hyperparameters, string model, string @object, string organizationId, IReadOnlyList<string> resultFiles, FineTuningJobStatus status, int? trainedTokens, string trainingFile, string validationFile, IReadOnlyList<InternalFineTuningIntegration> integrations, int seed, DateTimeOffset? estimatedFinish, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            CreatedAt = createdAt;
            Error = error;
            FineTunedModel = fineTunedModel;
            FinishedAt = finishedAt;
            Hyperparameters = hyperparameters;
            Model = model;
            Object = @object;
            OrganizationId = organizationId;
            ResultFiles = resultFiles;
            Status = status;
            TrainedTokens = trainedTokens;
            TrainingFile = trainingFile;
            ValidationFile = validationFile;
            Integrations = integrations;
            Seed = seed;
            EstimatedFinish = estimatedFinish;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal FineTuningJob()
        {
        }

        public string Id { get; }
        public DateTimeOffset CreatedAt { get; }
        public FineTuningJobError Error { get; }
        public string FineTunedModel { get; }
        public DateTimeOffset? FinishedAt { get; }
        public string Model { get; }

        public string OrganizationId { get; }
        public IReadOnlyList<string> ResultFiles { get; }
        public int? TrainedTokens { get; }
        public string TrainingFile { get; }
        public string ValidationFile { get; }
        public int Seed { get; }
        public DateTimeOffset? EstimatedFinish { get; }
    }
}
