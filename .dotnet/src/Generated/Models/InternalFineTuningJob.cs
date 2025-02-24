// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using OpenAI;

namespace OpenAI.FineTuning
{
    internal partial class InternalFineTuningJob
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalFineTuningJob(string jobId, string baseModel, string validationFileId, string trainingFileId, IEnumerable<string> resultFileIds, FineTuningStatus status, FineTuningHyperparameters hyperparameters, int? billableTrainedTokenCount, DateTimeOffset createdAt, FineTuningError error, string fineTunedModel, DateTimeOffset? finishedAt, string organizationId, int seed)
        {
            JobId = jobId;
            BaseModel = baseModel;
            ValidationFileId = validationFileId;
            TrainingFileId = trainingFileId;
            ResultFileIds = resultFileIds.ToList();
            Status = status;
            Hyperparameters = hyperparameters;
            Integrations = new ChangeTrackingList<FineTuningIntegration>();
            BillableTrainedTokenCount = billableTrainedTokenCount;
            CreatedAt = createdAt;
            Error = error;
            FineTunedModel = fineTunedModel;
            FinishedAt = finishedAt;
            OrganizationId = organizationId;
            Seed = seed;
        }

        internal InternalFineTuningJob(string jobId, string baseModel, DateTimeOffset? estimatedFinishAt, string validationFileId, string trainingFileId, IReadOnlyList<string> resultFileIds, FineTuningStatus status, string @object, FineTuningHyperparameters hyperparameters, IReadOnlyList<FineTuningIntegration> integrations, int? billableTrainedTokenCount, string userProvidedSuffix, DateTimeOffset createdAt, FineTuningError error, string fineTunedModel, DateTimeOffset? finishedAt, string organizationId, int seed, FineTuningTrainingMethod @method, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            JobId = jobId;
            BaseModel = baseModel;
            EstimatedFinishAt = estimatedFinishAt;
            ValidationFileId = validationFileId;
            TrainingFileId = trainingFileId;
            ResultFileIds = resultFileIds;
            Status = status;
            _object = @object;
            Hyperparameters = hyperparameters;
            Integrations = integrations;
            BillableTrainedTokenCount = billableTrainedTokenCount;
            UserProvidedSuffix = userProvidedSuffix;
            CreatedAt = createdAt;
            Error = error;
            FineTunedModel = fineTunedModel;
            FinishedAt = finishedAt;
            OrganizationId = organizationId;
            Seed = seed;
            Method = @method;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
