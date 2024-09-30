using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.FineTuning;

/// <summary>
/// A long-running operation for creating a new model from a given dataset.
/// </summary>
public partial class FineTuningJobOperation : OperationResult
{
    public FineTuningJob? Value = null;
    public bool HasValue => Value != null;

    /// <summary>
    /// Updates the status of the operation.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <returns> The updated operation. </returns>
    public async ValueTask<ClientResult<FineTuningJob>> UpdateStatusAsync(CancellationToken cancellationToken = default)
    {
        ClientResult result = await GetJobAsync(cancellationToken.ToRequestOptions()).ConfigureAwait(false);

        ApplyUpdate(result);

        return (ClientResult<FineTuningJob>)result;
    }

    /// <summary>
    /// Updates the status of the operation.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <returns> The updated operation. </returns>
    public ClientResult<FineTuningJob> UpdateStatus(CancellationToken cancellationToken = default)
    {
        ClientResult result = GetJob(cancellationToken.ToRequestOptions());

        ApplyUpdate(result);

        return (ClientResult<FineTuningJob>)result;
    }


    private static bool GetHasCompleted(FineTuningJobStatus status)
    {
        return status == FineTuningJobStatus.Succeeded ||
            status == FineTuningJobStatus.Failed ||
            status == FineTuningJobStatus.Cancelled;
    }

    /// <summary>
    /// Get info about a fine-tuning job.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult<FineTuningJob> GetJob(CancellationToken cancellationToken = default) => CreateRequestAndUpdate(CreateRetrieveFineTuningJobRequest, cancellationToken);

    /// <inheritdoc cref="GetJob(CancellationToken)"/>
    public virtual async Task<ClientResult<FineTuningJob>> GetJobAsync(CancellationToken cancellationToken = default) => await CreateRequestAndUpdateAsync(CreateRetrieveFineTuningJobRequest, cancellationToken).ConfigureAwait(false);


    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult<FineTuningJob> Cancel(CancellationToken cancellationToken = default) => CreateRequestAndUpdate(CreateCancelFineTuningJobRequest, cancellationToken);

    /// <inheritdoc cref="Cancel(CancellationToken)"/>
    public virtual async Task<ClientResult<FineTuningJob>> CancelAsync(CancellationToken cancellationToken = default) => await CreateRequestAndUpdateAsync(CreateCancelFineTuningJobRequest, cancellationToken).ConfigureAwait(false);

    private ClientResult<FineTuningJob> CreateRequestAndUpdate(Func<string, RequestOptions?, PipelineMessage> method, CancellationToken cancellationToken)
    {
        using PipelineMessage message = method(_jobId, cancellationToken.ToRequestOptions());
        var rawResponse = _pipeline.ProcessMessage(message, cancellationToken.ToRequestOptions());
        Value = FineTuningJob.FromResponse(rawResponse);
        return ClientResult.FromValue(Value, rawResponse);
    }

    private async Task<ClientResult<FineTuningJob>> CreateRequestAndUpdateAsync(Func<string, RequestOptions?, PipelineMessage> method, CancellationToken cancellationToken)
    {
        using PipelineMessage message = method(_jobId, cancellationToken.ToRequestOptions());
        var rawResponse = await _pipeline.ProcessMessageAsync(message, cancellationToken.ToRequestOptions());
        Value = FineTuningJob.FromResponse(rawResponse);
        return ClientResult.FromValue(Value, rawResponse);
    }

    
    

    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] Get status updates for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListEventsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual CollectionResult<FineTuningJobEvent> GetJobEvents(ListEventsOptions options, CancellationToken cancellationToken = default)
    {
        return new FineTuningJobEventCollectionResult(this, cancellationToken.ToRequestOptions(), options.PageSize, options.After);
    }

    /// <inheritdoc cref="GetJobEvents(ListEventsOptions, CancellationToken)"/>
    public virtual AsyncCollectionResult<FineTuningJobEvent> GetJobEventsAsync(ListEventsOptions options, CancellationToken cancellationToken = default)
    {
        return new AsyncFineTuningJobEventCollectionResult(this, cancellationToken.ToRequestOptions(), options.PageSize, options.After);
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListCheckpointsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual CollectionResult<FineTuningJobCheckpoint> GetJobCheckpoints(ListCheckpointsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new ListCheckpointsOptions();
        return new FineTuningJobCheckpointCollectionResult(this, cancellationToken.ToRequestOptions(), options.PageSize, options.AfterCheckpointId);
    }

    /// <inheritdoc cref="GetJobCheckpoints(ListCheckpointsOptions, CancellationToken)"/>
    public virtual AsyncCollectionResult<FineTuningJobCheckpoint> GetJobCheckpointsAsync(ListCheckpointsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new ListCheckpointsOptions();
        return new AsyncFineTuningJobCheckpointCollectionResult(this, cancellationToken.ToRequestOptions(), options.PageSize, options.AfterCheckpointId);
    }
}