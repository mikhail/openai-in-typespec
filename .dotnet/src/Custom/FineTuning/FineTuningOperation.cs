using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.FineTuning;

/// <summary>
/// A long-running operation for creating a new model from a given dataset.
/// </summary>
public partial class FineTuningOperation : OperationResult
{
    public FineTuningOperation Value => FineTuningOperation.FromResponse(GetRawResponse());

    public string JobId => _jobId;

    [CodeGenMember("Id")]
    private readonly string _jobId;

    [CodeGenMember("Model")]
    public string BaseModel { get; }

    [CodeGenMember("EstimatedFinish")]
    public DateTimeOffset? EstimatedFinishAt { get; }

    [CodeGenMember("ValidationFile")]
    public string ValidationFileId { get; }

    [CodeGenMember("TrainingFile")]
    public string TrainingFileId { get; }

    [CodeGenMember("ResultFiles")]
    public IReadOnlyList<string> ResultFileIds { get; }

    [CodeGenMember("Status")]
    public FineTuningOperationStatus Status { get; }

    [CodeGenMember("Object")]
    private string? _object { get; }

    [CodeGenMember("Hyperparameters")]
    public FineTuningJobHyperparameters Hyperparameters { get; } = default;

    [CodeGenMember("Integrations")]
    public IReadOnlyList<FineTuningIntegration> Integrations { get; }

    [CodeGenMember("TrainedTokens")]
    public int? BillableTrainedTokens { get; }

    internal FineTuningOperation(
            ClientPipeline pipeline,
            Uri endpoint,
            string jobId,
            PipelineResponse response) : base(response)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _jobId = jobId;
        var parsedResponse = ParseAndApplyUpdate(response);
        BaseModel = parsedResponse.BaseModel;
        ValidationFileId = parsedResponse.ValidationFileId;
        TrainingFileId = parsedResponse.TrainingFileId;
        ResultFileIds = parsedResponse.ResultFileIds;
        Integrations = parsedResponse.Integrations;
        RehydrationToken = new FineTuningJobOperationToken(jobId);
    }
    internal FineTuningOperation(string jobId, DateTimeOffset createdAt, JobError error, string fineTunedModel, DateTimeOffset? finishedAt, string baseModel, string organizationId, IEnumerable<string> resultFileIds, FineTuningOperationStatus status, int? billableTrainedTokens, string trainingFileId, string validationFileId, int seed)
    {
        Argument.AssertNotNull(jobId, nameof(jobId));
        Argument.AssertNotNull(baseModel, nameof(baseModel));
        Argument.AssertNotNull(organizationId, nameof(organizationId));
        Argument.AssertNotNull(resultFileIds, nameof(resultFileIds));
        Argument.AssertNotNull(trainingFileId, nameof(trainingFileId));

        _jobId = jobId;
        CreatedAt = createdAt;
        Error = error;
        FineTunedModel = fineTunedModel;
        FinishedAt = finishedAt;
        BaseModel = baseModel;
        OrganizationId = organizationId;
        ResultFileIds = resultFileIds.ToList();
        Status = status;
        BillableTrainedTokens = billableTrainedTokens;
        TrainingFileId = trainingFileId;
        ValidationFileId = validationFileId;
        Integrations = new ChangeTrackingList<FineTuningIntegration>();
        Seed = seed;
    }

    internal FineTuningOperation(string userProvidedSuffix, string jobId, DateTimeOffset createdAt, JobError error, string fineTunedModel, DateTimeOffset? finishedAt, FineTuningJobHyperparameters hyperparameters, string baseModel, string @object, string organizationId, IReadOnlyList<string> resultFileIds, FineTuningOperationStatus status, int? billableTrainedTokens, string trainingFileId, string validationFileId, IReadOnlyList<FineTuningIntegration> integrations, int seed, DateTimeOffset? estimatedFinishAt, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(new FTOPR())
    {
        UserProvidedSuffix = userProvidedSuffix;
        _jobId = jobId;
        CreatedAt = createdAt;
        Error = error;
        FineTunedModel = fineTunedModel;
        FinishedAt = finishedAt;
        Hyperparameters = hyperparameters;
        BaseModel = baseModel;
        _object = @object;
        OrganizationId = organizationId;
        ResultFileIds = resultFileIds;
        Status = status;
        BillableTrainedTokens = billableTrainedTokens;
        TrainingFileId = trainingFileId;
        ValidationFileId = validationFileId;
        Integrations = integrations;
        Seed = seed;
        EstimatedFinishAt = estimatedFinishAt;
        SerializedAdditionalRawData = serializedAdditionalRawData;
    }

    internal FineTuningOperation() : base(new FTOPR())
    {
    }

    public override string ToString()
    {
        return $"FineTuningJob<{JobId}, {Status}, {CreatedAt}>";
    }
    /// <summary>
    /// Updates the status of the operation.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <returns> The freshly fetched <see cref="ClientResult{FineTuningJob}"/> object. </returns>
    public async ValueTask<ClientResult<FineTuningOperation>> UpdateStatusAsync(CancellationToken cancellationToken = default)
    {
        return (ClientResult<FineTuningOperation>)await UpdateStatusAsync(cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }

    /// <summary>
    /// Re-fetches the latest information about the operation.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <returns> The freshly fetched <see cref="ClientResult{FineTuningJob}"/> object. </returns>
    public ClientResult<FineTuningOperation> UpdateStatus(CancellationToken cancellationToken = default)
    {
        return (ClientResult<FineTuningOperation>)UpdateStatus(cancellationToken.ToRequestOptions());
    }

    private static bool GetHasCompleted(FineTuningOperationStatus status)
    {
        return status == FineTuningOperationStatus.Succeeded ||
            status == FineTuningOperationStatus.Failed ||
            status == FineTuningOperationStatus.Cancelled;
    }

    /// <summary>
    /// Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult<FineTuningOperation>> CancelAsync(CancellationToken cancellationToken = default)
    {
        var result = await CancelAsync(cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(FineTuningOperation.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary>
    /// Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult<FineTuningOperation> Cancel(CancellationToken cancellationToken = default)
    {
        var result = Cancel(cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(FineTuningOperation.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary>
    /// Get status updates for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListEventsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual AsyncCollectionResult<FineTuningJobEvent> GetJobEventsAsync(ListEventsOptions options, CancellationToken cancellationToken = default)
    {
        options ??= new ListEventsOptions();
        return (AsyncCollectionResult<FineTuningJobEvent>)GetJobEventsAsync(options.After, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Get status updates for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListEventsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual CollectionResult<FineTuningJobEvent> GetJobEvents(ListEventsOptions options, CancellationToken cancellationToken = default)
    {
        options ??= new ListEventsOptions();
        return (CollectionResult<FineTuningJobEvent>)GetJobEvents(options.After, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListCheckpointsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual AsyncCollectionResult<FineTuningJobCheckpoint> GetJobCheckpointsAsync(ListCheckpointsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new ListCheckpointsOptions();
        return (AsyncCollectionResult<FineTuningJobCheckpoint>)GetJobCheckpointsAsync(options.AfterCheckpointId, options.PageSize, cancellationToken.ToRequestOptions());

    }

    /// <summary>
    /// List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListCheckpointsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual CollectionResult<FineTuningJobCheckpoint> GetJobCheckpoints(ListCheckpointsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new ListCheckpointsOptions();
        return (CollectionResult<FineTuningJobCheckpoint>)GetJobCheckpoints(options.AfterCheckpointId, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Recreates a <see cref="FineTuningOperation"/> from a rehydration token.
    /// </summary>
    /// <param name="client"> The <see cref="FineTuningClient"/> used to obtain the operation status from the service. </param>
    /// <param name="rehydrationToken"> The rehydration token corresponding to the operation to rehydrate. </param>
    /// <param name="cancellationToken"> A token that can be used to cancel the request. </param>
    /// <returns> The rehydrated operation <see cref="FineTuningOperation"/>. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="rehydrationToken"/> is null. </exception>
    public static FineTuningOperation Rehydrate(FineTuningClient client, ContinuationToken rehydrationToken, CancellationToken cancellationToken = default)
    {
        return Rehydrate(client, rehydrationToken, cancellationToken.ToRequestOptions());
    }


    /// <inheritdoc cref="Rehydrate(FineTuningClient, ContinuationToken, CancellationToken)"/>"
    public static async Task<FineTuningOperation> RehydrateAsync(FineTuningClient client, ContinuationToken rehydrationToken, CancellationToken cancellationToken = default)
    {
        return await RehydrateAsync(client, rehydrationToken, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }

    /// <summary>
    /// Recreates a <see cref="FineTuningOperation"/> from a fine tuning job id.
    /// </summary>
    /// <param name="client"> The <see cref="FineTuningClient"/> used to obtain the operation status from the service. </param>
    /// <param name="fineTuningJobId"> The id of the fine tuning job to rehydrate.</param>
    /// <param name="cancellationToken"> A token that can be used to cancel the request. </param>
    /// <returns> The rehydrated operation <see cref="FineTuningOperation"/>. </returns>
    public static FineTuningOperation Rehydrate(FineTuningClient client, string fineTuningJobId, CancellationToken cancellationToken = default)
    {
        return Rehydrate(client, fineTuningJobId, cancellationToken.ToRequestOptions());
    }

    /// <inheritdoc cref="Rehydrate(FineTuningClient, string, CancellationToken)" />
    public static async Task<FineTuningOperation> RehydrateAsync(FineTuningClient client, string fineTuningJobId, CancellationToken cancellationToken = default)
    {
        return await RehydrateAsync(client, fineTuningJobId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }


}

internal class FTOPR : PipelineResponse
{
    public override int Status => throw new NotImplementedException();

    public override string ReasonPhrase => throw new NotImplementedException();

    public override Stream? ContentStream { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override BinaryData Content => throw new NotImplementedException();

    protected override PipelineResponseHeaders HeadersCore => throw new NotImplementedException();

    public override BinaryData BufferContent(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override void Dispose()
    {
        throw new NotImplementedException();
    }
}