﻿using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.FineTuning;

/// <summary>
/// A long-running operation for creating a new model from a given dataset.
/// </summary>
public partial class FineTuningOperation : OperationResult
{
    public string? Value = null;

    public string OperationId { get; private set; } = null!;
    public string BaseModel { get; private set; } = null!;
    public DateTimeOffset? EstimatedFinishAt { get; private set; }
    public string ValidationFileId { get; private set; } = null!;
    public string TrainingFileId { get; private set; } = null!;
    public IReadOnlyList<string> ResultFileIds { get; private set; } = null!;
    public FineTuningStatus Status { get; private set; }

    public FineTuningHyperparameters Hyperparameters { get; private set; } = default;
    public IReadOnlyList<FineTuningIntegration> Integrations { get; private set; } = null!;
    public int? BillableTrainedTokens { get; private set; }
    public string? UserProvidedSuffix { get; private set; }
    public int? Seed { get; private set; }

    /// <summary>
    /// Creates a new <see cref="FineTuningOperation"/> from a <see cref="PipelineResponse"/>.
    /// </summary>
    /// <param name="pipeline"></param>
    /// <param name="endpoint"></param>
    /// <param name="response"></param>
    internal FineTuningOperation(
            ClientPipeline pipeline,
            Uri endpoint,
            PipelineResponse response) : base(response)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        var job = InternalFineTuningJob.FromResponse(response);
        CopyParamsFromJob(job, response);
    }

    /// <summary>
    /// Creates a new <see cref="FineTuningOperation"/> from a <see cref="InternalFineTuningJob"/>.
    /// Pipeline response is saved but not used for inferring job data. Response could be a page of values.
    /// </summary>
    internal FineTuningOperation(
            ClientPipeline pipeline,
            Uri endpoint,
            InternalFineTuningJob job,
            PipelineResponse response) : base(response)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        CopyParamsFromJob(job, response);
    }

    private void CopyParamsFromJob(InternalFineTuningJob job, PipelineResponse response)
    {
        Value = job.FineTunedModel;

        BaseModel = job.BaseModel;
        EstimatedFinishAt = job.EstimatedFinishAt;
        Hyperparameters = job.Hyperparameters;
        Integrations = job.Integrations;
        OperationId = job.JobId;
        RehydrationToken = new FineTuningOperationToken(job.JobId);
        ResultFileIds = job.ResultFileIds;
        Seed = job.Seed;
        Status = job.Status;
        TrainingFileId = job.TrainingFileId;
        UserProvidedSuffix = job.UserProvidedSuffix;
        ValidationFileId = job.ValidationFileId;

        HasCompleted = GetHasCompleted(Status);
        SetRawResponse(response);
    }

    private static bool GetHasCompleted(FineTuningStatus status)
    {
        return status == FineTuningStatus.Succeeded ||
            status == FineTuningStatus.Failed ||
            status == FineTuningStatus.Cancelled;
    }

    /// <summary>
    /// Get status updates for a currently running fine-tuning operation.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListEventsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual AsyncCollectionResult<FineTuningEvent> GetEventsAsync(ListEventsOptions options, CancellationToken cancellationToken = default)
    {
        options ??= new ListEventsOptions();
        return (AsyncCollectionResult<FineTuningEvent>)GetEventsAsync(options.After, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <inheritdoc cref="GetEventsAsync(ListEventsOptions, CancellationToken)"/>
    public virtual CollectionResult<FineTuningEvent> GetEvents(ListEventsOptions options, CancellationToken cancellationToken = default)
    {
        options ??= new ListEventsOptions();
        return (CollectionResult<FineTuningEvent>)GetEvents(options.After, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// List the checkpoints for a fine-tuning operation.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListCheckpointsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual AsyncCollectionResult<FineTuningCheckpoint> GetCheckpointsAsync(ListCheckpointsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new ListCheckpointsOptions();
        return (AsyncCollectionResult<FineTuningCheckpoint>)GetCheckpointsAsync(options.AfterCheckpointId, options.PageSize, cancellationToken.ToRequestOptions());

    }

    
    public virtual CollectionResult<FineTuningCheckpoint> GetCheckpoints(ListCheckpointsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new ListCheckpointsOptions();
        return (CollectionResult<FineTuningCheckpoint>)GetCheckpoints(options.AfterCheckpointId, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Creates a <see cref="FineTuningOperation"/> from a rehydration token.
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
    /// Creates a <see cref="FineTuningOperation" /> from its unique id.
    /// </summary>
    /// <param name="client"> The <see cref="FineTuningClient"/> used to obtain the operation status from the service. </param>
    /// <param name="operationId"> The id of the fine tuning operation to rehydrate.</param>
    /// <param name="cancellationToken"> A token that can be used to cancel the request. </param>
    /// <returns> The rehydrated operation <see cref="FineTuningOperation"/>. </returns>
    public static FineTuningOperation Rehydrate(FineTuningClient client, string operationId, CancellationToken cancellationToken = default)
    {
        return Rehydrate(client, operationId, cancellationToken.ToRequestOptions());
    }

    /// <inheritdoc cref="Rehydrate(FineTuningClient, string, CancellationToken)" />
    public static async Task<FineTuningOperation> RehydrateAsync(FineTuningClient client, string operationId, CancellationToken cancellationToken = default)
    {
        return await RehydrateAsync(client, operationId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async ValueTask<ClientResult> UpdateStatusAsync(CancellationToken cancellationToken = default)
    {
        ClientResult result = await GetJobAsync(cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        var response = result.GetRawResponse();
        CopyParamsFromJob(InternalFineTuningJob.FromResponse(response), response);
        return result;
    }

    /// <inheritdoc/>
    public ClientResult UpdateStatus(CancellationToken cancellationToken = default)
    {
        ClientResult result = GetJob(cancellationToken.ToRequestOptions());
        var response = result.GetRawResponse();
        CopyParamsFromJob(InternalFineTuningJob.FromResponse(response), response);
        return result;
    }

    /// <summary>
    /// [Protocol Method] Immediately cancel a fine-tune job, and update parameters (such as status) of the operation.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult CancelAndUpdate(CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = CancelPipelineMessage(OperationId, cancellationToken.ToRequestOptions());
        PipelineResponse response = _pipeline.ProcessMessage(message, cancellationToken.ToRequestOptions());
        CopyParamsFromJob(InternalFineTuningJob.FromResponse(response), response);
        return ClientResult.FromResponse(response);
    }

    /// <summary>
    /// [Protocol Method] Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult> CancelAndUpdateAsync(CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = CancelPipelineMessage(OperationId, cancellationToken.ToRequestOptions());
        PipelineResponse response = await _pipeline.ProcessMessageAsync(message, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        CopyParamsFromJob(InternalFineTuningJob.FromResponse(response), response);
        return ClientResult.FromResponse(response);
    }

    override public async ValueTask WaitForCompletionAsync(CancellationToken cancellationToken = default)
    {
        while (!HasCompleted)
        {
            var delay = GetDelay();

            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);

            await UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    override public void WaitForCompletion(CancellationToken cancellationToken = default)
    {
        while (!HasCompleted)
        {
            TimeSpan delay = GetDelay();

            if (!cancellationToken.CanBeCanceled)
            {
                Thread.Sleep(delay);
            }
            else if (cancellationToken.WaitHandle.WaitOne(delay))
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            UpdateStatus(cancellationToken);
        }
    }
    private TimeSpan GetDelay()
    {
        if (EstimatedFinishAt.HasValue)
        {
            return EstimatedFinishAt.Value - DateTimeOffset.UtcNow;
        }
        return Status == FineTuningStatus.Running
            ? TimeSpan.FromSeconds(30)
            : TimeSpan.FromSeconds(1);
    }
}