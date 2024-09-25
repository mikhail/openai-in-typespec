using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.FineTuning;

// CUSTOM:
// - Renamed.
// - Suppressed constructor that takes endpoint parameter; endpoint is now a property in the options class.
// - Suppressed convenience methods for now.
/// <summary> The service client for OpenAI fine-tuning operations. </summary>
[Experimental("OPENAI001")]
[CodeGenClient("FineTuning")]
[CodeGenSuppress("FineTuningClient", typeof(ClientPipeline), typeof(ApiKeyCredential), typeof(Uri))]
[CodeGenSuppress("CreateFineTuningJobAsync", typeof(FineTuningOptions))]
[CodeGenSuppress("CreateFineTuningJob", typeof(FineTuningOptions))]
[CodeGenSuppress("GetPaginatedFineTuningJobsAsync", typeof(string), typeof(int?))]
[CodeGenSuppress("GetPaginatedFineTuningJobs", typeof(string), typeof(int?))]
[CodeGenSuppress("RetrieveFineTuningJobAsync", typeof(string))]
[CodeGenSuppress("RetrieveFineTuningJob", typeof(string))]
[CodeGenSuppress("CancelFineTuningJobAsync", typeof(string))]
[CodeGenSuppress("CancelFineTuningJob", typeof(string))]
[CodeGenSuppress("GetFineTuningEventsAsync", typeof(string), typeof(string), typeof(int?))]
[CodeGenSuppress("GetFineTuningEvents", typeof(string), typeof(string), typeof(int?))]
[CodeGenSuppress("GetFineTuningJobCheckpointsAsync", typeof(string), typeof(string), typeof(int?))]
[CodeGenSuppress("GetFineTuningJobCheckpoints", typeof(string), typeof(string), typeof(int?))]
public partial class FineTuningClient
{
    // CUSTOM: Added as a convenience.
    /// <summary> Initializes a new instance of <see cref="FineTuningClient">. </summary>
    /// <param name="apiKey"> The API key to authenticate with the service. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="apiKey"/> is null. </exception>
    public FineTuningClient(string apiKey) : this(new ApiKeyCredential(apiKey), new OpenAIClientOptions())
    {
    }

    // CUSTOM: Added as a convenience.
    /// <summary> Initializes a new instance of <see cref="FineTuningClient">. </summary>
    /// <param name="apiKey"> The API key to authenticate with the service. </param>
    /// <param name="options"> The options to configure the client. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="apiKey"/> is null. </exception>
    public FineTuningClient(string apiKey, OpenAIClientOptions options) : this(new ApiKeyCredential(apiKey), options)
    {
    }

    // CUSTOM:
    // - Used a custom pipeline.
    // - Demoted the endpoint parameter to be a property in the options class.
    /// <summary> Initializes a new instance of <see cref="FineTuningClient">. </summary>
    /// <param name="credential"> The API key to authenticate with the service. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
    public FineTuningClient(ApiKeyCredential credential) : this(credential, new OpenAIClientOptions())
    {
    }

    // Customization: documented constructors, apply protected visibility    
    // CUSTOM:
    // - Used a custom pipeline.
    // - Demoted the endpoint parameter to be a property in the options class.
    /// <summary> Initializes a new instance of <see cref="FineTuningClient">. </summary>
    /// <param name="credential"> The API key to authenticate with the service. </param>
    /// <param name="options"> The options to configure the client. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
    public FineTuningClient(ApiKeyCredential credential, OpenAIClientOptions options)
    {
        Argument.AssertNotNull(credential, nameof(credential));
        options ??= new OpenAIClientOptions();

        _pipeline = OpenAIClient.CreatePipeline(credential, options);
        _endpoint = OpenAIClient.GetEndpoint(options);
    }

    // CUSTOM:
    // - Used a custom pipeline.
    // - Demoted the endpoint parameter to be a property in the options class.
    // - Made protected.
    /// <summary> Initializes a new instance of <see cref="FineTuningClient">. </summary>
    /// <param name="pipeline"> The HTTP pipeline to send and receive REST requests and responses. </param>
    /// <param name="options"> The options to configure the client. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> is null. </exception>
    protected internal FineTuningClient(ClientPipeline pipeline, OpenAIClientOptions options)
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        options ??= new OpenAIClientOptions();

        _pipeline = pipeline;
        _endpoint = OpenAIClient.GetEndpoint(options);
    }

    /// <summary> Creates a job with a training file and base model. </summary>
    /// <param name="baseModel"> The original model to use as a starting base to fine-tune. String such as "gpt-3.5-turbo" </param>
    /// <param name="trainingFileId"> The training file Id that is already uploaded. String should match pattern '^file-[a-zA-Z0-9]{24}$'. </param>
    /// <param name="options"> Additional options (<see cref="FineTuningOptions"/>) to customize the request. </param>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <returns>A <see cref="ClientResult{FineTuningJob}"/> containing the newly started fine-tuning job.</returns>
    public virtual ClientResult<FineTuningJob> CreateJob(
        string baseModel,
        string trainingFileId,
        FineTuningOptions options = default,
        CancellationToken cancellationToken = default
        )
    {
        options ??= new FineTuningOptions();
        options.Model = baseModel;
        options.TrainingFile = trainingFileId;

        ClientResult result = CreateJob(options.ToBinaryContent(), cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <inheritdoc cref="CreateJob(string, string, FineTuningOptions, CancellationToken)"/>
    public virtual async Task<ClientResult<FineTuningJob>> CreateJobAsync(
        string baseModel,
        string trainingFileId,
        FineTuningOptions options = default,
        CancellationToken cancellationToken = default
        )
    {

        options ??= new FineTuningOptions();
        options.Model = baseModel;
        options.TrainingFile = trainingFileId;

        ClientResult result = await CreateJobAsync(options.ToBinaryContent(), cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary>
    /// Cancels a fine-tuning job with the specified job ID.
    /// </summary>
    /// <param name="jobId">The ID of the job to cancel.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="ClientResult{FineTuningJob}"/> containing the canceled fine-tuning job.</returns>
    public virtual ClientResult<FineTuningJob> CancelJob(string jobId, CancellationToken cancellationToken = default)
    {
        ClientResult result = CancelJob(jobId, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <inheritdoc cref="CancelJob(string, CancellationToken)"/>
    public virtual async Task<ClientResult<FineTuningJob>> CancelJobAsync(string jobId, CancellationToken cancellationToken = default)
    {
        ClientResult result = await CancelJobAsync(jobId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary>
    /// Retrieves a fine-tuning job with the specified job ID.
    /// </summary>
    /// <param name="jobId">The ID of the job to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns> A <see cref="ClientResult{FineTuningJob}"/> containing the fine-tuning job. </returns>
    public virtual ClientResult<FineTuningJob> GetJob(string jobId, CancellationToken cancellationToken = default)
    {
        ClientResult result = GetJob(jobId, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <inheritdoc cref="GetJob(string, CancellationToken)"/>
    public virtual async Task<ClientResult<FineTuningJob>> GetJobAsync(string jobId, CancellationToken cancellationToken = default)
    {
        ClientResult result = await GetJobAsync(jobId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    public virtual async Task<FineTuningJob> WaitUntilCompleted(FineTuningJob job)
    {
        while (job.Status.InProgress)
        {
            var estimate = job.EstimatedFinishAt;

            if (estimate.HasValue)
            {
                // Console.WriteLine($"Waiting for {estimate.Value - DateTimeOffset.UtcNow}");
                await Task.Delay(estimate.Value - DateTimeOffset.UtcNow).ConfigureAwait(false);
            }
            else
            {
                // Console.WriteLine("Waiting for 30 seconds");
                await Task.Delay(30 * 1000).ConfigureAwait(false);
            }

            job = await GetJobAsync(job.JobId).ConfigureAwait(false);
        }
        return job;
    }


    /// <summary>
    /// Retrieves a list of fine-tuning jobs.
    /// </summary>
    /// <param name="options"> Additional options: <see cref="ListJobsOptions"/> to customize the request. </param>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <returns> A <see cref="CollectionResult{FineTuningJob}"/> containing the list of fine-tuning jobs. </returns>
    public virtual CollectionResult<FineTuningJob> GetJobs(ListJobsOptions options = default, CancellationToken cancellationToken = default)
    {
        options ??= new ListJobsOptions();
        return GetJobs(options.AfterJobId, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <inheritdoc cref="GetJobs(ListJobsOptions, CancellationToken)"/>
    /// <returns> A <see cref="AsyncCollectionResult{FineTuningJob}"/> containing the list of fine-tuning jobs. </returns>
    public virtual AsyncCollectionResult<FineTuningJob> GetJobsAsync(ListJobsOptions options = default, CancellationToken cancellationToken = default)
    {
        options ??= new ListJobsOptions();
        return GetJobsAsync(options.AfterJobId, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Gets a list of events for a fine-tuning job.
    /// </summary>
    /// <param name="jobId"> The ID of the job to retrieve events for. </param>
    /// <param name="options"> Additional options: <see cref="ListEventsOptions"/> to customize the request. </param>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <returns> A <see cref="CollectionResult{FineTuningJobEvent}"/> containing the list of events for the job. </returns>
    public virtual CollectionResult<FineTuningJobEvent> GetJobEvents(string jobId, ListEventsOptions options = default, CancellationToken cancellationToken = default)
    {
        options ??= new ListEventsOptions();
        return GetJobEvents(jobId, options.After, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <inheritdoc cref="GetJobEvents(string, ListEventsOptions, CancellationToken)"/>
    /// <returns> A <see cref="AsyncCollectionResult{FineTuningJobEvent}"/> containing the list of events for the job. </returns>
    public virtual AsyncCollectionResult<FineTuningJobEvent> GetJobEventsAsync(string jobId, ListEventsOptions options = default, CancellationToken cancellationToken = default)
    {
        options ??= new ListEventsOptions();
        return GetJobEventsAsync(jobId, options.After, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Gets a list of checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="jobId"> The ID of the job to retrieve checkpoints for. </param>
    /// <param name="options"> Additional options: <see cref="ListCheckpointsOptions"/> to customize the request. </param>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <returns> A <see cref="CollectionResult{FineTuningJobCheckpoint}"/> containing the list of checkpoints for the job. </returns>
    public virtual CollectionResult<FineTuningJobCheckpoint> GetJobCheckpoints(string jobId, ListCheckpointsOptions options = default, CancellationToken cancellationToken = default)
    {
        options ??= new ListCheckpointsOptions();
        return GetJobCheckpoints(jobId, options.AfterCheckpointId, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <inheritdoc cref="GetJobCheckpoints(string, ListCheckpointsOptions, CancellationToken)"/>
    /// <returns> A <see cref="AsyncCollectionResult{FineTuningJobCheckpoint}"/> containing the list of checkpoints for the job. </returns>
    public virtual AsyncCollectionResult<FineTuningJobCheckpoint> GetJobCheckpointsAsync(string jobId, ListCheckpointsOptions options = default, CancellationToken cancellationToken = default)
    {
        options ??= new ListCheckpointsOptions() { };

        return GetJobCheckpointsAsync(jobId, options.AfterCheckpointId, options.PageSize, cancellationToken.ToRequestOptions());
    }

}
