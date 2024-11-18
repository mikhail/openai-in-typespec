using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace OpenAI.FineTuning;

[CodeGenSuppress("CreateFineTuningJobAsync", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("CreateFineTuningJob", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("GetPaginatedFineTuningJobsAsync", typeof(string), typeof(int?), typeof(RequestOptions))]
[CodeGenSuppress("GetPaginatedFineTuningJobs", typeof(string), typeof(int?), typeof(RequestOptions))]
[CodeGenSuppress("RetrieveFineTuningJobAsync", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("RetrieveFineTuningJob", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("CancelFineTuningJobAsync", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("CancelFineTuningJob", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetFineTuningEventsAsync", typeof(string), typeof(string), typeof(int?), typeof(RequestOptions))]
[CodeGenSuppress("GetFineTuningEvents", typeof(string), typeof(string), typeof(int?), typeof(RequestOptions))]
[CodeGenSuppress("GetFineTuningJobCheckpointsAsync", typeof(string), typeof(string), typeof(int?), typeof(RequestOptions))]
[CodeGenSuppress("GetFineTuningJobCheckpoints", typeof(string), typeof(string), typeof(int?), typeof(RequestOptions))]
public partial class FineTuningClient
{
    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] Creates a fine-tuning operation which begins the process of creating a new model from a given dataset.
    ///
    /// Response includes details of the enqueued operation including operation status and the name of the fine-tuned models once complete.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="waitUntilCompleted"> Value indicating whether the method
    /// should return after the operation has been started and is still running
    /// on the service, or wait until the operation has completed to return.
    /// </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> A <see cref="FineTuningOperation"/> that can be used to wait for 
    /// the operation to complete, get information about the fine tuning operation, or 
    /// cancel the operation. </returns>
    public virtual async Task<FineTuningOperation> FineTuneAsync(
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions options)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = PostJobPipelineMessage(content, options);
        PipelineResponse response = await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);

        FineTuningOperation operation = this.CreateOperationFromResponse(response);
        return await operation.WaitUntilAsync(waitUntilCompleted, options).ConfigureAwait(false);
    }

    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] Creates a fine-tuning operation which begins the process of creating a new model from a given dataset.
    ///
    /// Response includes details of the enqueued operation including operation status and the name of the fine-tuned models once complete.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="waitUntilCompleted"> Value indicating whether the method
    /// should return after the operation has been started and is still running
    /// on the service, or wait until the operation has completed to return.
    /// </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> A <see cref="FineTuningOperation"/> that can be used to wait for 
    /// the operation to complete, get information about the fine tuning operation, or 
    /// cancel the operation. </returns>
    public virtual FineTuningOperation FineTune(
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions options)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = PostJobPipelineMessage(content, options);
        PipelineResponse response = _pipeline.ProcessMessage(message, options);

        FineTuningOperation operation = this.CreateOperationFromResponse(response);
        return operation.WaitUntil(waitUntilCompleted, options);
    }

    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] List all of your organization's fine-tuning operations
    /// </summary>
    /// <param name="afterOperationId"> Identifier for the last operation from the previous pagination request. </param>
    /// <param name="pageSize"> Number of fine-tuning operations to retrieve at a time. Collection will iterate until _all_ operations are fetched. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    private AsyncCollectionResult ListOperationsAsync(string afterOperationId, int? pageSize, RequestOptions options)
    {
        return new AsyncFineTuningOperationCollectionResult(this, _pipeline, options, pageSize, afterOperationId);
    }


    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] List all of your your organization's fine-tuning operations
    /// </summary>
    /// <param name="after"> Identifier for the last operation from the previous pagination request. </param>
    /// <param name="pageSize"> Number of fine-tuning operations to retrieve at a time. Collection will iterate until _all_ operations are fetched. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    private CollectionResult ListOperations(string after, int? pageSize, RequestOptions options)
    {
        return new FineTuningOperationCollectionResult(this, _pipeline, options, pageSize, after);
    }

    /// <summary>
    /// [Protocol Method] Get info about a fine-tuning operation.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="operationId"> The ID of the fine-tuning operation. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal async Task<ClientResult> GetOperationAsync(string operationId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

        using PipelineMessage message = GetJobPipelineMessage(_pipeline, _endpoint, operationId, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal ClientResult GetOperation(string operationId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

        using PipelineMessage message = GetJobPipelineMessage(_pipeline, _endpoint, operationId, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal virtual FineTuningOperation CreateOperationFromResponse(PipelineResponse response)
    {
        return new FineTuningOperation(_pipeline, _endpoint, response);
    }

    internal virtual IEnumerable<FineTuningOperation> CreateOperationsFromPageResponse(PipelineResponse response)
    {
        InternalListPaginatedFineTuningJobsResponse jobs = ModelReaderWriter.Read<InternalListPaginatedFineTuningJobsResponse>(response.Content)!;
        return jobs.Data.Select(job => new FineTuningOperation(_pipeline, _endpoint, job, response));
    }

    internal virtual PipelineMessage PostJobPipelineMessage(BinaryContent content, RequestOptions options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "POST";
        var uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/fine_tuning/jobs", false);
        request.Uri = uri.ToUri();
        request.Headers.Set("Accept", "application/json");
        request.Headers.Set("Content-Type", "application/json");
        request.Content = content;
        message.Apply(options);
        return message;
    }

    internal virtual PipelineMessage GetJobsPipelineMessage(string after, int? limit, RequestOptions options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "GET";
        var uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/fine_tuning/jobs", false);
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

    internal static PipelineMessage GetJobPipelineMessage(ClientPipeline clientPipeline, Uri endpoint, string operationId, RequestOptions options)
    {
        // This is referenced by client.GetOperationAsync and client.GetOperation, and operation.GetOperationAsync and operation.GetOperation.
        // It is static so that FineTuningOperation can use it as well.
        var message = clientPipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "GET";
        var uri = new ClientUriBuilder();
        uri.Reset(endpoint);
        uri.AppendPath("/fine_tuning/jobs/", false);
        uri.AppendPath(operationId, true);
        request.Uri = uri.ToUri();
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }
}
