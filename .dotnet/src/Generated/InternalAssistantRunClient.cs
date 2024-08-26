// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace OpenAI.Assistants
{
    // Data plane generated sub-client.
    internal partial class InternalAssistantRunClient
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        public virtual ClientPipeline Pipeline => _pipeline;

        protected InternalAssistantRunClient()
        {
        }

        public virtual async Task<ClientResult> GetRunsAsync(string threadId, int? limit, string order, string after, string before, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

            using PipelineMessage message = CreateGetRunsRequest(threadId, limit, order, after, before, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        public virtual ClientResult GetRuns(string threadId, int? limit, string order, string after, string before, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

            using PipelineMessage message = CreateGetRunsRequest(threadId, limit, order, after, before, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        public virtual async Task<ClientResult> GetRunStepsAsync(string threadId, string runId, int? limit, string order, string after, string before, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNullOrEmpty(runId, nameof(runId));

            using PipelineMessage message = CreateGetRunStepsRequest(threadId, runId, limit, order, after, before, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        public virtual ClientResult GetRunSteps(string threadId, string runId, int? limit, string order, string after, string before, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNullOrEmpty(runId, nameof(runId));

            using PipelineMessage message = CreateGetRunStepsRequest(threadId, runId, limit, order, after, before, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        internal PipelineMessage CreateCreateThreadAndRunRequest(BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/v1/threads/runs", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateCreateRunRequest(string threadId, BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/v1/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateGetRunsRequest(string threadId, int? limit, string order, string after, string before, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/v1/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs", false);
            if (limit != null)
            {
                uri.AppendQuery("limit", limit.Value, true);
            }
            if (order != null)
            {
                uri.AppendQuery("order", order, true);
            }
            if (after != null)
            {
                uri.AppendQuery("after", after, true);
            }
            if (before != null)
            {
                uri.AppendQuery("before", before, true);
            }
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateGetRunRequest(string threadId, string runId, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/v1/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs/", false);
            uri.AppendPath(runId, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateModifyRunRequest(string threadId, string runId, BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/v1/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs/", false);
            uri.AppendPath(runId, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateCancelRunRequest(string threadId, string runId, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/v1/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs/", false);
            uri.AppendPath(runId, true);
            uri.AppendPath("/cancel", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateSubmitToolOutputsToRunRequest(string threadId, string runId, BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/v1/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs/", false);
            uri.AppendPath(runId, true);
            uri.AppendPath("/submit_tool_outputs", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateGetRunStepsRequest(string threadId, string runId, int? limit, string order, string after, string before, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/v1/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs/", false);
            uri.AppendPath(runId, true);
            uri.AppendPath("/steps", false);
            if (limit != null)
            {
                uri.AppendQuery("limit", limit.Value, true);
            }
            if (order != null)
            {
                uri.AppendQuery("order", order, true);
            }
            if (after != null)
            {
                uri.AppendQuery("after", after, true);
            }
            if (before != null)
            {
                uri.AppendQuery("before", before, true);
            }
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateGetRunStepRequest(string threadId, string runId, string stepId, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/v1/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs/", false);
            uri.AppendPath(runId, true);
            uri.AppendPath("/steps/", false);
            uri.AppendPath(stepId, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        private static PipelineMessageClassifier _pipelineMessageClassifier200;
        private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
    }
}
