// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI;

/// <summary>
/// A helper class to standardize custom protocol message creation across various Azure OpenAI scenario clients.
/// </summary>
internal class AzureOpenAIPipelineMessageBuilder
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    private readonly string _deploymentName;
    private string[] _pathComponents;
    private readonly List<KeyValuePair<string, string>> _queryStringParameters = [];
    private string _method;
    private BinaryContent _content;
    private readonly Dictionary<string, string> _headers = [];
    private  PipelineMessageClassifier _classifier;
    private RequestOptions _options;
    private bool? _bufferResponse;

    /// <summary>
    /// Creates a new instance of <see cref="AzureOpenAIPipelineMessageBuilder"/>.
    /// </summary>
    /// <param name="pipeline"></param>
    /// <param name="endpoint"></param>
    /// <param name="deploymentName"></param>
    /// 
    public AzureOpenAIPipelineMessageBuilder(ClientPipeline pipeline, Uri endpoint, string deploymentName = null)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _deploymentName = deploymentName;
    }

    public AzureOpenAIPipelineMessageBuilder WithPath(params string[] pathComponents)
    {
        _pathComponents = pathComponents;
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithOptionalQueryParameter(string name, string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            _queryStringParameters.Add(new(name, value));
        }
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithOptionalQueryParameter<T>(string name, T? value)
        where T : struct, IConvertible
            => WithOptionalQueryParameter(name, value.HasValue ? Convert.ChangeType(value.Value, typeof(string)).ToString() : null);

    public AzureOpenAIPipelineMessageBuilder WithCommonListParameters(int? limit, string order, string after, string before)
        => WithOptionalQueryParameter("limit", limit)
        .WithOptionalQueryParameter("order", order)
        .WithOptionalQueryParameter("after", after)
        .WithOptionalQueryParameter("before", before);

    public AzureOpenAIPipelineMessageBuilder WithMethod(string requestMethod)
    {
        _method = requestMethod;
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithContent(BinaryContent content, string contentType)
    {
        _content = content;
        _headers["Content-Type"] = contentType;
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithHeader(string name, string value)
    {
        _headers[name] = value;
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithAssistantsHeader()
    {
        _headers[s_OpenAIBetaFeatureHeader] = s_OpenAIBetaAssistantsV2HeaderValue;
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithAccept(string acceptHeaderValue)
        => WithHeader("Accept", acceptHeaderValue);

    public AzureOpenAIPipelineMessageBuilder WithOptions(RequestOptions requestOptions)
    {
        _options = requestOptions;
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithResponseContentBuffering(bool? shouldBufferContent)
    {
        _bufferResponse = shouldBufferContent;
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithClassifier(PipelineMessageClassifier classifier)
    {
        _classifier = classifier;
        return this;
    }

    public PipelineMessage Build()
    {
        Argument.AssertNotNullOrWhiteSpace(_method, nameof(_method));

        PipelineMessage message = _pipeline.CreateMessage();
        message.ResponseClassifier = _classifier ?? AzureOpenAIClient.PipelineMessageClassifier;
        if (_bufferResponse.HasValue)
        {
            message.BufferResponse = _bufferResponse.Value;
        }
        PipelineRequest request = message.Request;
        request.Method = _method;
        SetUri(request);
        foreach (KeyValuePair<string, string> pair in _headers)
        {
            request.Headers.Set(pair.Key, pair.Value);
        }
        request.Content = _content;
        if (_options is not null)
        {
            message.Apply(_options);
        }
        return message;
    }

    private void SetUri(PipelineRequest request)
    {
        ClientUriBuilder uriBuilder = new();
        uriBuilder.Reset(_endpoint);

        //bool hasTrailingSlash = _endpoint.AbsoluteUri.EndsWith("/");
        //uriBuilder.AppendPath($"{(hasTrailingSlash ? "" : "/")}openai", escape: false);

        if (!string.IsNullOrEmpty(_deploymentName))
        {
            uriBuilder.AppendPath($"/deployments/", escape: false);
            uriBuilder.AppendPath(_deploymentName, escape: true);
        }

        foreach (string pathComponent in _pathComponents ?? [])
        {
            uriBuilder.AppendPath("/", escape: false);
            uriBuilder.AppendPath(pathComponent, escape: true);
        }

        foreach (KeyValuePair<string, string> queryStringPair in _queryStringParameters)
        {
            uriBuilder.AppendQuery(queryStringPair.Key, queryStringPair.Value, escape: true);
        }

        request.Uri = uriBuilder.ToUri();
    }

    private static readonly string s_OpenAIBetaFeatureHeader = "OpenAI-Beta";
    private static readonly string s_OpenAIBetaAssistantsV2HeaderValue = "assistants=v2";
}
