// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

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
    internal AzureFineTuningClient(ClientPipeline pipeline, Uri endpoint)
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    { }

    protected AzureFineTuningClient()
    { }

    internal override FineTuningJob CreateJobFromResponse(PipelineResponse response)
    {
        return new AzureFineTuningJob(Pipeline, _endpoint, response);
    }

}

#endif