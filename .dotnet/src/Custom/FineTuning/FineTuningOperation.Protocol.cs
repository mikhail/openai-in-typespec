﻿using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.FineTuning;

/// <summary>
/// A long-running operation for creating a new model from a given dataset.
/// </summary>
[Experimental("OPENAI001")]
[CodeGenModel("FineTuningJob")]
public partial class FineTuningOperation : OperationResult
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;

    /// <inheritdoc/>
    public override ContinuationToken? RehydrationToken { get; protected set; }

    /// <summary>
    /// Recreates a <see cref="FineTuningOperation"/> from a rehydration token.
    /// </summary>
    /// <param name="client"> The <see cref="FineTuningClient"/> used to obtain the operation status from the service. </param>
    /// <param name="rehydrationToken"> The rehydration token corresponding to the operation to rehydrate. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <returns> The rehydrated operation <see cref="FineTuningOperation"/>. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="rehydrationToken"/> is null. </exception>
    public static FineTuningOperation Rehydrate(FineTuningClient client, ContinuationToken rehydrationToken, RequestOptions options)
    {
        Argument.AssertNotNull(client, nameof(client));
        Argument.AssertNotNull(rehydrationToken, nameof(rehydrationToken));

        FineTuningJobOperationToken token = FineTuningJobOperationToken.FromToken(rehydrationToken);

        ClientResult result = client.GetJob(token.JobId, options);
        PipelineResponse response = result.GetRawResponse();

        return client.CreateCreateJobOperation(token.JobId, response);
    }

    /// <inheritdoc cref="Rehydrate(FineTuningClient, ContinuationToken, RequestOptions)"/>
    public static async Task<FineTuningOperation> RehydrateAsync(FineTuningClient client, ContinuationToken rehydrationToken, RequestOptions options)
    {
        Argument.AssertNotNull(client, nameof(client));
        Argument.AssertNotNull(rehydrationToken, nameof(rehydrationToken));

        FineTuningJobOperationToken token = FineTuningJobOperationToken.FromToken(rehydrationToken);

        ClientResult result = await client.GetJobAsync(token.JobId, options).ConfigureAwait(false);
        PipelineResponse response = result.GetRawResponse();

        return client.CreateCreateJobOperation(token.JobId, response);
    }

    /// <summary>
    /// Recreates a <see cref="FineTuningOperation"/> from a fine tuning job id.
    /// </summary>
    /// <param name="client"> The <see cref="FineTuningClient"/> used to obtain the operation status from the service. </param>
    /// <param name="fineTuningJobId"> The id of the fine tuning job to rehydrate.</param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <returns> The rehydrated operation <see cref="FineTuningOperation"/>. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="fineTuningJobId"/> is null. </exception>
    public static FineTuningOperation Rehydrate(FineTuningClient client, string fineTuningJobId, RequestOptions options)
    {
        Argument.AssertNotNull(client, nameof(client));
        Argument.AssertNotNull(fineTuningJobId, nameof(fineTuningJobId));

        ClientResult result = client.GetJob(fineTuningJobId, options);
        PipelineResponse response = result.GetRawResponse();

        return client.CreateCreateJobOperation(fineTuningJobId, response);
    }

    /// <inheritdoc cref="Rehydrate(FineTuningClient, string, RequestOptions)"/>/>
    public static async Task<FineTuningOperation> RehydrateAsync(FineTuningClient client, string fineTuningJobId, RequestOptions options)
    {
        Argument.AssertNotNull(client, nameof(client));
        Argument.AssertNotNull(fineTuningJobId, nameof(fineTuningJobId));

        ClientResult result = await client.GetJobAsync(fineTuningJobId, options).ConfigureAwait(false);
        PipelineResponse response = result.GetRawResponse();

        return client.CreateCreateJobOperation(fineTuningJobId, response);
    }



    /// <inheritdoc/>
    public override async ValueTask<ClientResult> UpdateStatusAsync(RequestOptions? options = null)
    {
        ClientResult result = await GetJobAsync(options).ConfigureAwait(false);
        ParseAndApplyUpdate(result.GetRawResponse());
        return result;
    }

    /// <inheritdoc/>
    public override ClientResult UpdateStatus(RequestOptions? options = null)
    {
        ClientResult result = GetJob(options);
        ParseAndApplyUpdate(result.GetRawResponse());
        return result;
    }

    private FineTuningOperation ParseAndApplyUpdate(PipelineResponse response)
    {
        SetRawResponse(response);
        var parsedResponse = FineTuningOperation.FromResponse(response);
        HasCompleted = GetHasCompleted(parsedResponse.Status);
        return parsedResponse;
    }

    internal async Task<FineTuningOperation> WaitUntilAsync(bool waitUntilCompleted, RequestOptions? options)
    {
        if (!waitUntilCompleted) return this;
        await WaitForCompletionAsync(options?.CancellationToken ?? default).ConfigureAwait(false);
        return this;
    }

    internal FineTuningOperation WaitUntil(bool waitUntilCompleted, RequestOptions? options)
    {
        if (!waitUntilCompleted) return this;
        WaitForCompletion(options?.CancellationToken ?? default);
        return this;
    }

    // Generated protocol methods

    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] Get info about a fine-tuning job.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal virtual async Task<ClientResult> GetJobAsync(RequestOptions? options)
    {
        using PipelineMessage message = CreateRetrieveFineTuningJobRequest(_jobId, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] Get info about a fine-tuning job.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal virtual ClientResult GetJob(RequestOptions? options)
    {
        using PipelineMessage message = CreateRetrieveFineTuningJobRequest(_jobId, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult> CancelAsync(RequestOptions? options)
    {
        using PipelineMessage message = CreateCancelFineTuningJobRequest(_jobId, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult Cancel(RequestOptions? options)
    {
        using PipelineMessage message = CreateCancelFineTuningJobRequest(_jobId, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] Get status updates for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last event from the previous pagination request. </param>
    /// <param name="limit"> Number of events to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual AsyncCollectionResult GetJobEventsAsync(string? after, int? limit, RequestOptions options)
    {
        return new AsyncFineTuningJobEventCollectionResult(this, options, limit, after);
    }

    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] Get status updates for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last event from the previous pagination request. </param>
    /// <param name="limit"> Number of events to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual CollectionResult GetJobEvents(string? after, int? limit, RequestOptions options)
    {
        return new FineTuningJobEventCollectionResult(this, options, limit, after);
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual AsyncCollectionResult GetJobCheckpointsAsync(string? after, int? limit, RequestOptions? options)
    {
        return new AsyncFineTuningJobCheckpointCollectionResult(this, options, limit, after);
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual CollectionResult GetJobCheckpoints(string? after, int? limit, RequestOptions? options)
    {
        return new FineTuningJobCheckpointCollectionResult(this, options, limit, after);
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal virtual async Task<ClientResult> GetJobCheckpointsPageAsync(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = CreateGetFineTuningJobCheckpointsRequest(_jobId, after, limit, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal virtual ClientResult GetJobPageCheckpoints(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = CreateGetFineTuningJobCheckpointsRequest(_jobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal virtual ClientResult GetJobCheckpointsPage(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = CreateGetFineTuningJobCheckpointsRequest(_jobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal virtual async Task<ClientResult> GetJobEventsPageAsync(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = CreateGetFineTuningEventsRequest(_jobId, after, limit, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal virtual ClientResult GetJobEventsPage(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = CreateGetFineTuningEventsRequest(_jobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal virtual PipelineMessage CreateRetrieveFineTuningJobRequest(string fineTuningJobId, RequestOptions? options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "GET";
        var uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/fine_tuning/jobs/", false);
        uri.AppendPath(fineTuningJobId, true);
        request.Uri = uri.ToUri();
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }

    internal virtual PipelineMessage CreateCancelFineTuningJobRequest(string fineTuningJobId, RequestOptions? options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "POST";
        var uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/fine_tuning/jobs/", false);
        uri.AppendPath(fineTuningJobId, true);
        uri.AppendPath("/cancel", false);
        request.Uri = uri.ToUri();
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }

    internal virtual PipelineMessage CreateGetFineTuningJobCheckpointsRequest(string fineTuningJobId, string? after, int? limit, RequestOptions? options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "GET";
        var uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/fine_tuning/jobs/", false);
        uri.AppendPath(fineTuningJobId, true);
        uri.AppendPath("/checkpoints", false);
        if (after != null)
        {
            uri.AppendQuery("after", after, true);
        }
        if (limit != null)
        {
            uri.AppendQuery("limit", limit.Value, true);
        }
        request.Uri = uri.ToUri();
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }

    internal virtual PipelineMessage CreateGetFineTuningEventsRequest(string jobId, string? after, int? limit, RequestOptions? options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "GET";
        var uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/fine_tuning/jobs/", false);
        uri.AppendPath(jobId, true);
        uri.AppendPath("/events", false);
        if (after != null)
        {
            uri.AppendQuery("after", after, true);
        }
        if (limit != null)
        {
            uri.AppendQuery("limit", limit.Value, true);
        }
        request.Uri = uri.ToUri();
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }

    override public async ValueTask WaitForCompletionAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        while (!HasCompleted)
        {
            var delay = GetDelay();

            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);

            await UpdateStatusAsync(cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        }
    }

    override public void WaitForCompletion(CancellationToken cancellationToken = default)
    {
        while (!HasCompleted)
        {
            // status
            TimeSpan delay = GetDelay();
            if (!cancellationToken.CanBeCanceled)
            {
                Thread.Sleep(delay);
            }
            else if (cancellationToken.WaitHandle.WaitOne(delay))
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            UpdateStatus(cancellationToken.ToRequestOptions());
        }
    }

    private TimeSpan GetDelay()
    {
        using JsonDocument doc = JsonDocument.Parse(GetRawResponse().Content);

        try
        {
            // estimated_finish will be null until fine tuning begins.
            var estimatedFinish = doc.RootElement.GetProperty("estimated_finish"u8).GetDateTimeOffset();
            return estimatedFinish - DateTimeOffset.UtcNow;
        }
        catch (InvalidOperationException)
        {
            return doc.RootElement.GetProperty("status"u8).GetString() switch
            {
                "succeeded" or "failed" or "cancelled" => TimeSpan.Zero,
                "queued" or "validating_files" => TimeSpan.FromSeconds(1),
                "running" => TimeSpan.FromSeconds(30),
                _ => TimeSpan.FromSeconds(1),
            };
        }
    }

    private static PipelineMessageClassifier? _pipelineMessageClassifier200;
    private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
}
