// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using OpenAI;

namespace OpenAI.Assistants
{
    internal partial class InternalAssistantMessageClient
    {
        private readonly Uri _endpoint;
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";

        protected InternalAssistantMessageClient()
        {
        }

        public ClientPipeline Pipeline { get; }

        public virtual ClientResult ListMessages(string threadId, int? limit = null, string order = null, string after = null, string before = null, RequestOptions options = null)
        {
            Argument.AssertNotNull(threadId, nameof(threadId));

            using PipelineMessage message = CreateListMessagesRequest(threadId, limit, order, after, before, options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }

        public virtual async Task<ClientResult> ListMessagesAsync(string threadId, int? limit = null, string order = null, string after = null, string before = null, RequestOptions options = null)
        {
            Argument.AssertNotNull(threadId, nameof(threadId));

            using PipelineMessage message = CreateListMessagesRequest(threadId, limit, order, after, before, options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }
    }
}
