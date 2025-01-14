﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.FineTuning;

/// <summary>
/// The scenario client used for fine-tuning operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureFineTuningClient : FineTuningClient
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureFineTuningClient(ClientPipeline pipeline, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        options ??= new();

        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureFineTuningClient()
    { }

    internal override FineTuningJob CreateJobFromResponse(PipelineResponse response)
    {
        return new AzureFineTuningJob(Pipeline, _endpoint, response, _apiVersion);
    }

    /**
     * Impl note: this is where the Azure-specific bound subclient thingamajigs are actually created
     */
    internal override IEnumerable<FineTuningJob> CreateJobsFromPageResponse(PipelineResponse response)
    {
        InternalListPaginatedFineTuningJobsResponse jobs = ModelReaderWriter.Read<InternalListPaginatedFineTuningJobsResponse>(response.Content)!;
        return jobs.Data.Select(job => new AzureFineTuningJob(Pipeline, _endpoint, _apiVersion, job, response));
    }
}

#endif