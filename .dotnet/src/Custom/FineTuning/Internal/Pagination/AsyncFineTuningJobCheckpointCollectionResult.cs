﻿using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.FineTuning;

internal class AsyncFineTuningJobCheckpointCollectionResult : AsyncCollectionResult<FineTuningJobCheckpoint>
{
    private readonly FineTuningClient _fineTuningClient;
    private readonly ClientPipeline _pipeline;
    private readonly RequestOptions? _options;
    private readonly CancellationToken _cancellationToken;

    // Initial values
    private readonly string _jobId;
    private readonly int? _pageSize;
    private readonly string _after;

    public AsyncFineTuningJobCheckpointCollectionResult(FineTuningClient fineTuningClient,
        ClientPipeline pipeline, RequestOptions? options,
        string jobId, string afterCheckpointId, int? pageSize)
    {
        _fineTuningClient = fineTuningClient;
        _pipeline = pipeline;
        _options = options;

        _jobId = jobId;
        _pageSize = pageSize;
        _after = afterCheckpointId;
        _cancellationToken = _options?.CancellationToken ?? default;

    }

    public async override IAsyncEnumerable<ClientResult> GetRawPagesAsync()
    {
        ClientResult page = await GetFirstPageAsync().ConfigureAwait(false);
        yield return page;

        while (HasNextPage(page))
        {
            page = await GetNextPageAsync(page);
            yield return page;
        }
    }

    public override ContinuationToken? GetContinuationToken(ClientResult page)
    {
        Argument.AssertNotNull(page, nameof(page));
        return FineTuningJobCheckpointCollectionPageToken.FromResponse(page, _jobId, _pageSize);
    }

    public async Task<ClientResult> GetFirstPageAsync()
        => await GetJobCheckpointsAsync(_jobId, _after, _pageSize, _options).ConfigureAwait(false);

    public async Task<ClientResult> GetNextPageAsync(ClientResult result)
    {
        Argument.AssertNotNull(result, nameof(result));

        PipelineResponse response = result.GetRawResponse();

        using JsonDocument doc = JsonDocument.Parse(response?.Content);

        JsonElement data = doc.RootElement.GetProperty("data");
        JsonElement lastItem = data.EnumerateArray().LastOrDefault();
        string? lastId = lastItem.TryGetProperty("id", out JsonElement idElement) ?
            idElement.GetString() : null;

        return await GetJobCheckpointsAsync(_jobId, lastId, _pageSize, _options).ConfigureAwait(false);
    }

    public static bool HasNextPage(ClientResult result)
        => FineTuningJobCheckpointCollectionResult.HasNextPage(result);

    internal virtual async Task<ClientResult> GetJobCheckpointsAsync(string jobId, string? afterCheckpointId, int? pageSize, RequestOptions? options)
    {
        Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

        using PipelineMessage message = _fineTuningClient.CreateGetFineTuningJobCheckpointsRequest(jobId, afterCheckpointId, pageSize, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    protected override IAsyncEnumerable<FineTuningJobCheckpoint> GetValuesFromPageAsync(ClientResult page)
    {
        Argument.AssertNotNull(page, nameof(page));

        PipelineResponse response = page.GetRawResponse();
        InternalListFineTuningJobCheckpointsResponse points = ModelReaderWriter.Read<InternalListFineTuningJobCheckpointsResponse>(response.Content)!;

        return points.Data.ToAsyncEnumerable(_cancellationToken);
    }
}