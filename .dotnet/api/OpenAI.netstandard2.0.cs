namespace OpenAI {
    public readonly partial struct ListOrder : IEquatable<ListOrder> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListOrder(string value);
        public static ListOrder NewestFirst { get; }
        public static ListOrder OldestFirst { get; }
        public readonly bool Equals(ListOrder other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(ListOrder left, ListOrder right);
        public static implicit operator ListOrder(string value);
        public static bool operator !=(ListOrder left, ListOrder right);
        public override readonly string ToString();
    }
    public class OpenAIClient {
        protected OpenAIClient();
        public OpenAIClient(ApiKeyCredential credential, OpenAIClientOptions options);
        public OpenAIClient(ApiKeyCredential credential);
        protected internal OpenAIClient(ClientPipeline pipeline, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        public virtual AssistantClient GetAssistantClient();
        public virtual AudioClient GetAudioClient(string model);
        public virtual BatchClient GetBatchClient();
        public virtual ChatClient GetChatClient(string model);
        public virtual EmbeddingClient GetEmbeddingClient(string model);
        public virtual FileClient GetFileClient();
        public virtual FineTuningClient GetFineTuningClient();
        public virtual ImageClient GetImageClient(string model);
        public virtual ModelClient GetModelClient();
        public virtual ModerationClient GetModerationClient(string model);
        public virtual VectorStoreClient GetVectorStoreClient();
    }
    public class OpenAIClientOptions {
        public OpenAIClientOptions();
        public string ApplicationId { get; set; }
        public Uri Endpoint { get; set; }
        public string OrganizationId { get; set; }
        public string ProjectId { get; set; }
    }
}
namespace OpenAI.Assistants {
    public class Assistant {
        public DateTimeOffset CreatedAt { get; }
        public string Description { get; }
        public string Id { get; }
        public string Instructions { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public string Model { get; }
        public string Name { get; }
        public float? NucleusSamplingFactor { get; }
        public AssistantResponseFormat ResponseFormat { get; }
        public float? Temperature { get; }
        public ToolResources ToolResources { get; }
        public IReadOnlyList<ToolDefinition> Tools { get; }
    }
    public class AssistantClient {
        protected AssistantClient();
        public AssistantClient(ApiKeyCredential credential, OpenAIClientOptions options);
        public AssistantClient(ApiKeyCredential credential);
        protected internal AssistantClient(ClientPipeline pipeline, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<ThreadRun> CancelRun(ThreadRun run);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult CancelRun(string threadId, string runId, RequestOptions options);
        public virtual ClientResult<ThreadRun> CancelRun(string threadId, string runId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<ThreadRun>> CancelRunAsync(ThreadRun run);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> CancelRunAsync(string threadId, string runId, RequestOptions options);
        public virtual Task<ClientResult<ThreadRun>> CancelRunAsync(string threadId, string runId, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult CreateAssistant(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<Assistant> CreateAssistant(string model, AssistantCreationOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> CreateAssistantAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<Assistant>> CreateAssistantAsync(string model, AssistantCreationOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<ThreadMessage> CreateMessage(AssistantThread thread, MessageRole role, IEnumerable<MessageContent> content, MessageCreationOptions options = null);
        public virtual ClientResult<ThreadMessage> CreateMessage(string threadId, MessageRole role, IEnumerable<MessageContent> content, MessageCreationOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult CreateMessage(string threadId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ThreadMessage>> CreateMessageAsync(AssistantThread thread, MessageRole role, IEnumerable<MessageContent> content, MessageCreationOptions options = null);
        public virtual Task<ClientResult<ThreadMessage>> CreateMessageAsync(string threadId, MessageRole role, IEnumerable<MessageContent> content, MessageCreationOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> CreateMessageAsync(string threadId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadRun> CreateRun(AssistantThread thread, Assistant assistant, RunCreationOptions options = null);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult CreateRun(string threadId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadRun> CreateRun(string threadId, string assistantId, RunCreationOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<ThreadRun>> CreateRunAsync(AssistantThread thread, Assistant assistant, RunCreationOptions options = null);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> CreateRunAsync(string threadId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ThreadRun>> CreateRunAsync(string threadId, string assistantId, RunCreationOptions options = null, CancellationToken cancellationToken = default);
        public virtual CollectionResult<StreamingUpdate> CreateRunStreaming(AssistantThread thread, Assistant assistant, RunCreationOptions options = null);
        public virtual CollectionResult<StreamingUpdate> CreateRunStreaming(string threadId, string assistantId, RunCreationOptions options = null, CancellationToken cancellationToken = default);
        public virtual AsyncCollectionResult<StreamingUpdate> CreateRunStreamingAsync(AssistantThread thread, Assistant assistant, RunCreationOptions options = null);
        public virtual AsyncCollectionResult<StreamingUpdate> CreateRunStreamingAsync(string threadId, string assistantId, RunCreationOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<AssistantThread> CreateThread(ThreadCreationOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult CreateThread(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadRun> CreateThreadAndRun(Assistant assistant, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult CreateThreadAndRun(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadRun> CreateThreadAndRun(string assistantId, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<ThreadRun>> CreateThreadAndRunAsync(Assistant assistant, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> CreateThreadAndRunAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ThreadRun>> CreateThreadAndRunAsync(string assistantId, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null, CancellationToken cancellationToken = default);
        public virtual CollectionResult<StreamingUpdate> CreateThreadAndRunStreaming(Assistant assistant, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null);
        public virtual CollectionResult<StreamingUpdate> CreateThreadAndRunStreaming(string assistantId, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null, CancellationToken cancellationToken = default);
        public virtual AsyncCollectionResult<StreamingUpdate> CreateThreadAndRunStreamingAsync(Assistant assistant, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null);
        public virtual AsyncCollectionResult<StreamingUpdate> CreateThreadAndRunStreamingAsync(string assistantId, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<AssistantThread>> CreateThreadAsync(ThreadCreationOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> CreateThreadAsync(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<bool> DeleteAssistant(Assistant assistant);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult DeleteAssistant(string assistantId, RequestOptions options);
        public virtual ClientResult<bool> DeleteAssistant(string assistantId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<bool>> DeleteAssistantAsync(Assistant assistant);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> DeleteAssistantAsync(string assistantId, RequestOptions options);
        public virtual Task<ClientResult<bool>> DeleteAssistantAsync(string assistantId, CancellationToken cancellationToken = default);
        public virtual ClientResult<bool> DeleteMessage(ThreadMessage message);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult DeleteMessage(string threadId, string messageId, RequestOptions options);
        public virtual ClientResult<bool> DeleteMessage(string threadId, string messageId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<bool>> DeleteMessageAsync(ThreadMessage message);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> DeleteMessageAsync(string threadId, string messageId, RequestOptions options);
        public virtual Task<ClientResult<bool>> DeleteMessageAsync(string threadId, string messageId, CancellationToken cancellationToken = default);
        public virtual ClientResult<bool> DeleteThread(AssistantThread thread);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult DeleteThread(string threadId, RequestOptions options);
        public virtual ClientResult<bool> DeleteThread(string threadId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<bool>> DeleteThreadAsync(AssistantThread thread);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> DeleteThreadAsync(string threadId, RequestOptions options);
        public virtual Task<ClientResult<bool>> DeleteThreadAsync(string threadId, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GetAssistant(string assistantId, RequestOptions options);
        public virtual ClientResult<Assistant> GetAssistant(string assistantId, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GetAssistantAsync(string assistantId, RequestOptions options);
        public virtual Task<ClientResult<Assistant>> GetAssistantAsync(string assistantId, CancellationToken cancellationToken = default);
        public virtual PageCollection<Assistant> GetAssistants(AssistantCollectionOptions options = null, CancellationToken cancellationToken = default);
        public virtual PageCollection<Assistant> GetAssistants(ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IEnumerable<ClientResult> GetAssistants(int? limit, string order, string after, string before, RequestOptions options);
        public virtual AsyncPageCollection<Assistant> GetAssistantsAsync(AssistantCollectionOptions options = null, CancellationToken cancellationToken = default);
        public virtual AsyncPageCollection<Assistant> GetAssistantsAsync(ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IAsyncEnumerable<ClientResult> GetAssistantsAsync(int? limit, string order, string after, string before, RequestOptions options);
        public virtual ClientResult<ThreadMessage> GetMessage(ThreadMessage message);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GetMessage(string threadId, string messageId, RequestOptions options);
        public virtual ClientResult<ThreadMessage> GetMessage(string threadId, string messageId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<ThreadMessage>> GetMessageAsync(ThreadMessage message);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GetMessageAsync(string threadId, string messageId, RequestOptions options);
        public virtual Task<ClientResult<ThreadMessage>> GetMessageAsync(string threadId, string messageId, CancellationToken cancellationToken = default);
        public virtual PageCollection<ThreadMessage> GetMessages(AssistantThread thread, MessageCollectionOptions options = null);
        public virtual PageCollection<ThreadMessage> GetMessages(ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        public virtual PageCollection<ThreadMessage> GetMessages(string threadId, MessageCollectionOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IEnumerable<ClientResult> GetMessages(string threadId, int? limit, string order, string after, string before, RequestOptions options);
        public virtual AsyncPageCollection<ThreadMessage> GetMessagesAsync(AssistantThread thread, MessageCollectionOptions options = null);
        public virtual AsyncPageCollection<ThreadMessage> GetMessagesAsync(ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        public virtual AsyncPageCollection<ThreadMessage> GetMessagesAsync(string threadId, MessageCollectionOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IAsyncEnumerable<ClientResult> GetMessagesAsync(string threadId, int? limit, string order, string after, string before, RequestOptions options);
        public virtual ClientResult<ThreadRun> GetRun(ThreadRun run);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GetRun(string threadId, string runId, RequestOptions options);
        public virtual ClientResult<ThreadRun> GetRun(string threadId, string runId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<ThreadRun>> GetRunAsync(ThreadRun run);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GetRunAsync(string threadId, string runId, RequestOptions options);
        public virtual Task<ClientResult<ThreadRun>> GetRunAsync(string threadId, string runId, CancellationToken cancellationToken = default);
        public virtual PageCollection<ThreadRun> GetRuns(AssistantThread thread, RunCollectionOptions options = null);
        public virtual PageCollection<ThreadRun> GetRuns(ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        public virtual PageCollection<ThreadRun> GetRuns(string threadId, RunCollectionOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IEnumerable<ClientResult> GetRuns(string threadId, int? limit, string order, string after, string before, RequestOptions options);
        public virtual AsyncPageCollection<ThreadRun> GetRunsAsync(AssistantThread thread, RunCollectionOptions options = null);
        public virtual AsyncPageCollection<ThreadRun> GetRunsAsync(ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        public virtual AsyncPageCollection<ThreadRun> GetRunsAsync(string threadId, RunCollectionOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IAsyncEnumerable<ClientResult> GetRunsAsync(string threadId, int? limit, string order, string after, string before, RequestOptions options);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GetRunStep(string threadId, string runId, string stepId, RequestOptions options);
        public virtual ClientResult<RunStep> GetRunStep(string threadId, string runId, string stepId, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GetRunStepAsync(string threadId, string runId, string stepId, RequestOptions options);
        public virtual Task<ClientResult<RunStep>> GetRunStepAsync(string threadId, string runId, string stepId, CancellationToken cancellationToken = default);
        public virtual PageCollection<RunStep> GetRunSteps(ThreadRun run, RunStepCollectionOptions options = null);
        public virtual PageCollection<RunStep> GetRunSteps(ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        public virtual PageCollection<RunStep> GetRunSteps(string threadId, string runId, RunStepCollectionOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IEnumerable<ClientResult> GetRunSteps(string threadId, string runId, int? limit, string order, string after, string before, RequestOptions options);
        public virtual AsyncPageCollection<RunStep> GetRunStepsAsync(ThreadRun run, RunStepCollectionOptions options = null);
        public virtual AsyncPageCollection<RunStep> GetRunStepsAsync(ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        public virtual AsyncPageCollection<RunStep> GetRunStepsAsync(string threadId, string runId, RunStepCollectionOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IAsyncEnumerable<ClientResult> GetRunStepsAsync(string threadId, string runId, int? limit, string order, string after, string before, RequestOptions options);
        public virtual ClientResult<AssistantThread> GetThread(AssistantThread thread);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GetThread(string threadId, RequestOptions options);
        public virtual ClientResult<AssistantThread> GetThread(string threadId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<AssistantThread>> GetThreadAsync(AssistantThread thread);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GetThreadAsync(string threadId, RequestOptions options);
        public virtual Task<ClientResult<AssistantThread>> GetThreadAsync(string threadId, CancellationToken cancellationToken = default);
        public virtual ClientResult<Assistant> ModifyAssistant(Assistant assistant, AssistantModificationOptions options);
        public virtual ClientResult<Assistant> ModifyAssistant(string assistantId, AssistantModificationOptions options, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult ModifyAssistant(string assistantId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<Assistant>> ModifyAssistantAsync(Assistant assistant, AssistantModificationOptions options);
        public virtual Task<ClientResult<Assistant>> ModifyAssistantAsync(string assistantId, AssistantModificationOptions options, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> ModifyAssistantAsync(string assistantId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadMessage> ModifyMessage(ThreadMessage message, MessageModificationOptions options);
        public virtual ClientResult<ThreadMessage> ModifyMessage(string threadId, string messageId, MessageModificationOptions options, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult ModifyMessage(string threadId, string messageId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ThreadMessage>> ModifyMessageAsync(ThreadMessage message, MessageModificationOptions options);
        public virtual Task<ClientResult<ThreadMessage>> ModifyMessageAsync(string threadId, string messageId, MessageModificationOptions options, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> ModifyMessageAsync(string threadId, string messageId, BinaryContent content, RequestOptions options = null);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult ModifyRun(string threadId, string runId, BinaryContent content, RequestOptions options = null);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> ModifyRunAsync(string threadId, string runId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<AssistantThread> ModifyThread(AssistantThread thread, ThreadModificationOptions options);
        public virtual ClientResult<AssistantThread> ModifyThread(string threadId, ThreadModificationOptions options, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult ModifyThread(string threadId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<AssistantThread>> ModifyThreadAsync(AssistantThread thread, ThreadModificationOptions options);
        public virtual Task<ClientResult<AssistantThread>> ModifyThreadAsync(string threadId, ThreadModificationOptions options, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> ModifyThreadAsync(string threadId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadRun> SubmitToolOutputsToRun(ThreadRun run, IEnumerable<ToolOutput> toolOutputs);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult SubmitToolOutputsToRun(string threadId, string runId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadRun> SubmitToolOutputsToRun(string threadId, string runId, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<ThreadRun>> SubmitToolOutputsToRunAsync(ThreadRun run, IEnumerable<ToolOutput> toolOutputs);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> SubmitToolOutputsToRunAsync(string threadId, string runId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ThreadRun>> SubmitToolOutputsToRunAsync(string threadId, string runId, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default);
        public virtual CollectionResult<StreamingUpdate> SubmitToolOutputsToRunStreaming(ThreadRun run, IEnumerable<ToolOutput> toolOutputs);
        public virtual CollectionResult<StreamingUpdate> SubmitToolOutputsToRunStreaming(string threadId, string runId, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default);
        public virtual AsyncCollectionResult<StreamingUpdate> SubmitToolOutputsToRunStreamingAsync(ThreadRun run, IEnumerable<ToolOutput> toolOutputs);
        public virtual AsyncCollectionResult<StreamingUpdate> SubmitToolOutputsToRunStreamingAsync(string threadId, string runId, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default);
    }
    public class AssistantCollectionOptions {
        public string AfterId { get; set; }
        public string BeforeId { get; set; }
        public ListOrder? Order { get; set; }
        public int? PageSize { get; set; }
    }
    public class AssistantCreationOptions {
        public string Description { get; set; }
        public string Instructions { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
        public string Name { get; set; }
        public float? NucleusSamplingFactor { get; set; }
        public AssistantResponseFormat ResponseFormat { get; set; }
        public float? Temperature { get; set; }
        public ToolResources ToolResources { get; set; }
        public IList<ToolDefinition> Tools { get; }
    }
    public class AssistantModificationOptions {
        public IList<ToolDefinition> DefaultTools { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public float? NucleusSamplingFactor { get; set; }
        public AssistantResponseFormat ResponseFormat { get; set; }
        public float? Temperature { get; set; }
        public ToolResources ToolResources { get; set; }
    }
    public abstract class AssistantResponseFormat : IEquatable<AssistantResponseFormat>, IEquatable<string> {
        public static AssistantResponseFormat Auto { get; }
        public static AssistantResponseFormat JsonObject { get; }
        public static AssistantResponseFormat Text { get; }
        public static AssistantResponseFormat CreateAutoFormat();
        public static AssistantResponseFormat CreateJsonObjectFormat();
        public static AssistantResponseFormat CreateJsonSchemaFormat(string name, BinaryData jsonSchema, string description = null, bool? strictSchemaEnabled = null);
        public static AssistantResponseFormat CreateTextFormat();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(AssistantResponseFormat first, AssistantResponseFormat second);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator AssistantResponseFormat(string plainTextFormat);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(AssistantResponseFormat first, AssistantResponseFormat second);
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IEquatable<AssistantResponseFormat>.Equals(AssistantResponseFormat other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IEquatable<string>.Equals(string other);
        public override string ToString();
    }
    public class AssistantThread {
        public DateTimeOffset CreatedAt { get; }
        public string Id { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public ToolResources ToolResources { get; }
    }
    public class CodeInterpreterToolDefinition : ToolDefinition {
    }
    public class CodeInterpreterToolResources {
        public IList<string> FileIds { get; set; }
    }
    public class FileSearchToolDefinition : ToolDefinition {
        public int? MaxResults { get; set; }
    }
    public class FileSearchToolResources {
        public IList<VectorStoreCreationHelper> NewVectorStores { get; }
        public IList<string> VectorStoreIds { get; set; }
    }
    public class FunctionToolDefinition : ToolDefinition {
        public FunctionToolDefinition();
        public FunctionToolDefinition(string name);
        public string Description { get; set; }
        public required string FunctionName { get; set; }
        public BinaryData Parameters { get; set; }
        public bool? StrictParameterSchemaEnabled { get; set; }
    }
    public class MessageCollectionOptions {
        public string AfterId { get; set; }
        public string BeforeId { get; set; }
        public ListOrder? Order { get; set; }
        public int? PageSize { get; set; }
    }
    public abstract class MessageContent {
        public MessageImageDetail? ImageDetail { get; }
        public string ImageFileId { get; }
        public Uri ImageUrl { get; }
        public string Refusal { get; }
        public string Text { get; }
        public IReadOnlyList<TextAnnotation> TextAnnotations { get; }
        public static MessageContent FromImageFileId(string imageFileId, MessageImageDetail? detail = null);
        public static MessageContent FromImageUrl(Uri imageUri, MessageImageDetail? detail = null);
        public static MessageContent FromText(string text);
        public static implicit operator MessageContent(string value);
    }
    public class MessageContentUpdate : StreamingUpdate {
        public MessageImageDetail? ImageDetail { get; }
        public string ImageFileId { get; }
        public string MessageId { get; }
        public int MessageIndex { get; }
        public string RefusalUpdate { get; }
        public MessageRole? Role { get; }
        public string Text { get; }
        public TextAnnotationUpdate TextAnnotation { get; }
    }
    public class MessageCreationAttachment {
        public MessageCreationAttachment(string fileId, IEnumerable<ToolDefinition> tools);
        public string FileId { get; }
        public IReadOnlyList<ToolDefinition> Tools { get; }
    }
    public class MessageCreationOptions {
        public IList<MessageCreationAttachment> Attachments { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
    }
    public class MessageFailureDetails {
        public MessageFailureReason Reason { get; }
    }
    public readonly partial struct MessageFailureReason : IEquatable<MessageFailureReason> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageFailureReason(string value);
        public static MessageFailureReason ContentFilter { get; }
        public static MessageFailureReason MaxTokens { get; }
        public static MessageFailureReason RunCancelled { get; }
        public static MessageFailureReason RunExpired { get; }
        public static MessageFailureReason RunFailed { get; }
        public readonly bool Equals(MessageFailureReason other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(MessageFailureReason left, MessageFailureReason right);
        public static implicit operator MessageFailureReason(string value);
        public static bool operator !=(MessageFailureReason left, MessageFailureReason right);
        public override readonly string ToString();
    }
    public enum MessageImageDetail {
        Auto = 0,
        Low = 1,
        High = 2
    }
    public class MessageModificationOptions {
        public IDictionary<string, string> Metadata { get; set; }
    }
    public enum MessageRole {
        User = 0,
        Assistant = 1
    }
    public readonly partial struct MessageStatus : IEquatable<MessageStatus> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStatus(string value);
        public static MessageStatus Completed { get; }
        public static MessageStatus Incomplete { get; }
        public static MessageStatus InProgress { get; }
        public readonly bool Equals(MessageStatus other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(MessageStatus left, MessageStatus right);
        public static implicit operator MessageStatus(string value);
        public static bool operator !=(MessageStatus left, MessageStatus right);
        public override readonly string ToString();
    }
    public class MessageStatusUpdate : StreamingUpdate<ThreadMessage> {
    }
    public abstract class RequiredAction {
        public string FunctionArguments { get; }
        public string FunctionName { get; }
        public string ToolCallId { get; }
    }
    public class RequiredActionUpdate : RunUpdate {
        public string FunctionArguments { get; }
        public string FunctionName { get; }
        public string ToolCallId { get; }
        public ThreadRun GetThreadRun();
    }
    public class RunCollectionOptions {
        public string AfterId { get; set; }
        public string BeforeId { get; set; }
        public ListOrder? Order { get; set; }
        public int? PageSize { get; set; }
    }
    public class RunCreationOptions {
        public string AdditionalInstructions { get; set; }
        public IList<ThreadInitializationMessage> AdditionalMessages { get; }
        public string InstructionsOverride { get; set; }
        public int? MaxCompletionTokens { get; set; }
        public int? MaxPromptTokens { get; set; }
        public IDictionary<string, string> Metadata { get; }
        public string ModelOverride { get; set; }
        public float? NucleusSamplingFactor { get; set; }
        public bool? ParallelToolCallsEnabled { get; set; }
        public AssistantResponseFormat ResponseFormat { get; set; }
        public float? Temperature { get; set; }
        public ToolConstraint ToolConstraint { get; set; }
        public IList<ToolDefinition> ToolsOverride { get; }
        public RunTruncationStrategy TruncationStrategy { get; set; }
    }
    public class RunError {
        public RunErrorCode Code { get; }
        public string Message { get; }
    }
    public readonly partial struct RunErrorCode : IEquatable<RunErrorCode> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunErrorCode(string value);
        public static RunErrorCode InvalidPrompt { get; }
        public static RunErrorCode RateLimitExceeded { get; }
        public static RunErrorCode ServerError { get; }
        public readonly bool Equals(RunErrorCode other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(RunErrorCode left, RunErrorCode right);
        public static implicit operator RunErrorCode(string value);
        public static bool operator !=(RunErrorCode left, RunErrorCode right);
        public override readonly string ToString();
    }
    public class RunIncompleteDetails {
        public RunIncompleteReason? Reason { get; }
    }
    public readonly partial struct RunIncompleteReason : IEquatable<RunIncompleteReason> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunIncompleteReason(string value);
        public static RunIncompleteReason MaxCompletionTokens { get; }
        public static RunIncompleteReason MaxPromptTokens { get; }
        public readonly bool Equals(RunIncompleteReason other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(RunIncompleteReason left, RunIncompleteReason right);
        public static implicit operator RunIncompleteReason(string value);
        public static bool operator !=(RunIncompleteReason left, RunIncompleteReason right);
        public override readonly string ToString();
    }
    public class RunModificationOptions {
        public IDictionary<string, string> Metadata { get; set; }
    }
    public readonly partial struct RunStatus : IEquatable<RunStatus> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStatus(string value);
        public static RunStatus Cancelled { get; }
        public static RunStatus Cancelling { get; }
        public static RunStatus Completed { get; }
        public static RunStatus Expired { get; }
        public static RunStatus Failed { get; }
        public static RunStatus Incomplete { get; }
        public static RunStatus InProgress { get; }
        public bool IsTerminal { get; }
        public static RunStatus Queued { get; }
        public static RunStatus RequiresAction { get; }
        public readonly bool Equals(RunStatus other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(RunStatus left, RunStatus right);
        public static implicit operator RunStatus(string value);
        public static bool operator !=(RunStatus left, RunStatus right);
        public override readonly string ToString();
    }
    public class RunStep {
        public string AssistantId { get; }
        public DateTimeOffset? CancelledAt { get; }
        public DateTimeOffset? CompletedAt { get; }
        public DateTimeOffset CreatedAt { get; }
        public RunStepDetails Details { get; }
        public DateTimeOffset? ExpiredAt { get; }
        public DateTimeOffset? FailedAt { get; }
        public string Id { get; }
        public RunStepError LastError { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public string RunId { get; }
        public RunStepStatus Status { get; }
        public string ThreadId { get; }
        public RunStepType Type { get; }
        public RunStepTokenUsage Usage { get; }
    }
    public abstract class RunStepCodeInterpreterOutput {
        public string ImageFileId { get; }
        public string Logs { get; }
    }
    public class RunStepCollectionOptions {
        public string AfterId { get; set; }
        public string BeforeId { get; set; }
        public ListOrder? Order { get; set; }
        public int? PageSize { get; set; }
    }
    public abstract class RunStepDetails {
        public string CreatedMessageId { get; }
        public IReadOnlyList<RunStepToolCall> ToolCalls { get; }
    }
    public class RunStepDetailsUpdate : StreamingUpdate {
        public string CodeInterpreterInput { get; }
        public IReadOnlyList<RunStepUpdateCodeInterpreterOutput> CodeInterpreterOutputs { get; }
        public string CreatedMessageId { get; }
        public string FunctionArguments { get; }
        public string FunctionName { get; }
        public string FunctionOutput { get; }
        public string StepId { get; }
        public string ToolCallId { get; }
        public int? ToolCallIndex { get; }
    }
    public class RunStepError {
        public RunStepErrorCode Code { get; }
        public string Message { get; }
    }
    public readonly partial struct RunStepErrorCode : IEquatable<RunStepErrorCode> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepErrorCode(string value);
        public static RunStepErrorCode RateLimitExceeded { get; }
        public static RunStepErrorCode ServerError { get; }
        public readonly bool Equals(RunStepErrorCode other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(RunStepErrorCode left, RunStepErrorCode right);
        public static implicit operator RunStepErrorCode(string value);
        public static bool operator !=(RunStepErrorCode left, RunStepErrorCode right);
        public override readonly string ToString();
    }
    public readonly partial struct RunStepStatus : IEquatable<RunStepStatus> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStatus(string value);
        public static RunStepStatus Cancelled { get; }
        public static RunStepStatus Completed { get; }
        public static RunStepStatus Expired { get; }
        public static RunStepStatus Failed { get; }
        public static RunStepStatus InProgress { get; }
        public readonly bool Equals(RunStepStatus other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(RunStepStatus left, RunStepStatus right);
        public static implicit operator RunStepStatus(string value);
        public static bool operator !=(RunStepStatus left, RunStepStatus right);
        public override readonly string ToString();
    }
    public class RunStepTokenUsage {
        public int CompletionTokens { get; }
        public int PromptTokens { get; }
        public int TotalTokens { get; }
    }
    public abstract class RunStepToolCall {
        public string CodeInterpreterInput { get; }
        public IReadOnlyList<RunStepCodeInterpreterOutput> CodeInterpreterOutputs { get; }
        public string FunctionArguments { get; }
        public string FunctionName { get; }
        public string FunctionOutput { get; }
        public string ToolCallId { get; }
        public RunStepToolCallKind ToolKind { get; }
    }
    public enum RunStepToolCallKind {
        Unknown = 0,
        CodeInterpreter = 1,
        FileSearch = 2,
        Function = 3
    }
    public readonly partial struct RunStepType : IEquatable<RunStepType> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepType(string value);
        public static RunStepType MessageCreation { get; }
        public static RunStepType ToolCalls { get; }
        public readonly bool Equals(RunStepType other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(RunStepType left, RunStepType right);
        public static implicit operator RunStepType(string value);
        public static bool operator !=(RunStepType left, RunStepType right);
        public override readonly string ToString();
    }
    public class RunStepUpdate : StreamingUpdate<RunStep> {
    }
    public abstract class RunStepUpdateCodeInterpreterOutput {
        public string ImageFileId { get; }
        public string Logs { get; }
        public int OutputIndex { get; }
    }
    public class RunTokenUsage {
        public int CompletionTokens { get; }
        public int PromptTokens { get; }
        public int TotalTokens { get; }
    }
    public class RunTruncationStrategy {
        public static RunTruncationStrategy Auto { get; }
        public int? LastMessages { get; }
        public static RunTruncationStrategy CreateLastMessagesStrategy(int lastMessageCount);
    }
    public class RunUpdate : StreamingUpdate<ThreadRun> {
    }
    public abstract class StreamingUpdate {
        public StreamingUpdateReason UpdateKind { get; }
    }
    public enum StreamingUpdateReason {
        Unknown = 0,
        ThreadCreated = 1,
        RunCreated = 2,
        RunQueued = 3,
        RunInProgress = 4,
        RunRequiresAction = 5,
        RunCompleted = 6,
        RunIncomplete = 7,
        RunFailed = 8,
        RunCancelling = 9,
        RunCancelled = 10,
        RunExpired = 11,
        RunStepCreated = 12,
        RunStepInProgress = 13,
        RunStepUpdated = 14,
        RunStepCompleted = 15,
        RunStepFailed = 16,
        RunStepCancelled = 17,
        RunStepExpired = 18,
        MessageCreated = 19,
        MessageInProgress = 20,
        MessageUpdated = 21,
        MessageCompleted = 22,
        MessageFailed = 23,
        Error = 24,
        Done = 25
    }
    public class StreamingUpdate<T> : StreamingUpdate where T : class {
        public T Value { get; }
        public static implicit operator T(StreamingUpdate<T> update);
    }
    public class TextAnnotation {
        public int EndIndex { get; }
        public string InputFileId { get; }
        public string OutputFileId { get; }
        public int StartIndex { get; }
        public string TextToReplace { get; }
    }
    public class TextAnnotationUpdate {
        public int ContentIndex { get; }
        public int? EndIndex { get; }
        public string InputFileId { get; }
        public string OutputFileId { get; }
        public int? StartIndex { get; }
        public string TextToReplace { get; }
    }
    public class ThreadCreationOptions {
        public IList<ThreadInitializationMessage> InitialMessages { get; }
        public IDictionary<string, string> Metadata { get; set; }
        public ToolResources ToolResources { get; set; }
    }
    public class ThreadInitializationMessage : MessageCreationOptions {
        public ThreadInitializationMessage(MessageRole role, IEnumerable<MessageContent> content);
        public static implicit operator ThreadInitializationMessage(string initializationMessage);
    }
    public class ThreadMessage {
        public string AssistantId { get; }
        public IReadOnlyList<MessageCreationAttachment> Attachments { get; }
        public DateTimeOffset? CompletedAt { get; }
        public IReadOnlyList<MessageContent> Content { get; }
        public DateTimeOffset CreatedAt { get; }
        public string Id { get; }
        public DateTimeOffset? IncompleteAt { get; }
        public MessageFailureDetails IncompleteDetails { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public MessageRole Role { get; }
        public string RunId { get; }
        public MessageStatus Status { get; }
        public string ThreadId { get; }
    }
    public class ThreadModificationOptions {
        public IDictionary<string, string> Metadata { get; set; }
        public ToolResources ToolResources { get; set; }
    }
    public class ThreadRun {
        public string AssistantId { get; }
        public DateTimeOffset? CancelledAt { get; }
        public DateTimeOffset? CompletedAt { get; }
        public DateTimeOffset CreatedAt { get; }
        public DateTimeOffset? ExpiresAt { get; }
        public DateTimeOffset? FailedAt { get; }
        public string Id { get; }
        public RunIncompleteDetails IncompleteDetails { get; }
        public string Instructions { get; }
        public RunError LastError { get; }
        public int? MaxCompletionTokens { get; }
        public int? MaxPromptTokens { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public string Model { get; }
        public float? NucleusSamplingFactor { get; }
        public bool? ParallelToolCallsEnabled { get; }
        public IReadOnlyList<RequiredAction> RequiredActions { get; }
        public AssistantResponseFormat ResponseFormat { get; }
        public DateTimeOffset? StartedAt { get; }
        public RunStatus Status { get; }
        public float? Temperature { get; }
        public string ThreadId { get; }
        public ToolConstraint ToolConstraint { get; }
        public IReadOnlyList<ToolDefinition> Tools { get; }
        public RunTruncationStrategy TruncationStrategy { get; }
        public RunTokenUsage Usage { get; }
    }
    public class ThreadUpdate : StreamingUpdate<AssistantThread> {
        public DateTimeOffset CreatedAt { get; }
        public string Id { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public ToolResources ToolResources { get; }
    }
    public class ToolConstraint {
        public ToolConstraint(ToolDefinition toolDefinition);
        public static ToolConstraint Auto { get; }
        public static ToolConstraint None { get; }
        public static ToolConstraint Required { get; }
    }
    public abstract class ToolDefinition {
        protected ToolDefinition();
        protected ToolDefinition(string type);
        public static CodeInterpreterToolDefinition CreateCodeInterpreter();
        public static FileSearchToolDefinition CreateFileSearch(int? maxResults = null);
        public static FunctionToolDefinition CreateFunction(string name, string description = null, BinaryData parameters = null, bool? strictParameterSchemaEnabled = null);
    }
    public class ToolOutput {
        public ToolOutput();
        public ToolOutput(string toolCallId, string output);
        public string Output { get; set; }
        public string ToolCallId { get; set; }
    }
    public class ToolResources {
        public CodeInterpreterToolResources CodeInterpreter { get; set; }
        public FileSearchToolResources FileSearch { get; set; }
    }
    public class VectorStoreCreationHelper {
        public VectorStoreCreationHelper();
        public VectorStoreCreationHelper(IEnumerable<OpenAIFileInfo> files, IDictionary<string, string> metadata = null);
        public VectorStoreCreationHelper(IEnumerable<string> fileIds, IDictionary<string, string> metadata = null);
        public FileChunkingStrategy ChunkingStrategy { get; set; }
        public IList<string> FileIds { get; }
        public IDictionary<string, string> Metadata { get; }
    }
}
namespace OpenAI.Audio {
    public class AudioClient {
        protected AudioClient();
        protected internal AudioClient(ClientPipeline pipeline, string model, OpenAIClientOptions options);
        public AudioClient(string model, ApiKeyCredential credential, OpenAIClientOptions options);
        public AudioClient(string model, ApiKeyCredential credential);
        public virtual ClientPipeline Pipeline { get; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GenerateSpeech(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<BinaryData> GenerateSpeech(string text, GeneratedSpeechVoice voice, SpeechGenerationOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GenerateSpeechAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<BinaryData>> GenerateSpeechAsync(string text, GeneratedSpeechVoice voice, SpeechGenerationOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult TranscribeAudio(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual ClientResult<AudioTranscription> TranscribeAudio(Stream audio, string audioFilename, AudioTranscriptionOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<AudioTranscription> TranscribeAudio(string audioFilePath, AudioTranscriptionOptions options = null);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> TranscribeAudioAsync(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual Task<ClientResult<AudioTranscription>> TranscribeAudioAsync(Stream audio, string audioFilename, AudioTranscriptionOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<AudioTranscription>> TranscribeAudioAsync(string audioFilePath, AudioTranscriptionOptions options = null);
        public virtual ClientResult TranslateAudio(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual ClientResult<AudioTranslation> TranslateAudio(Stream audio, string audioFilename, AudioTranslationOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<AudioTranslation> TranslateAudio(string audioFilePath, AudioTranslationOptions options = null);
        public virtual Task<ClientResult> TranslateAudioAsync(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual Task<ClientResult<AudioTranslation>> TranslateAudioAsync(Stream audio, string audioFilename, AudioTranslationOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<AudioTranslation>> TranslateAudioAsync(string audioFilePath, AudioTranslationOptions options = null);
    }
    [Flags]
    public enum AudioTimestampGranularities {
        Default = 0,
        Word = 1,
        Segment = 2
    }
    public class AudioTranscription {
        public TimeSpan? Duration { get; }
        public string Language { get; }
        public IReadOnlyList<TranscribedSegment> Segments { get; }
        public string Text { get; }
        public IReadOnlyList<TranscribedWord> Words { get; }
    }
    public enum AudioTranscriptionFormat {
        Text = 0,
        Simple = 1,
        Verbose = 2,
        Srt = 3,
        Vtt = 4
    }
    public class AudioTranscriptionOptions {
        public AudioTimestampGranularities Granularities { get; set; }
        public string Language { get; set; }
        public string Prompt { get; set; }
        public AudioTranscriptionFormat? ResponseFormat { get; set; }
        public float? Temperature { get; set; }
    }
    public class AudioTranslation {
        public TimeSpan? Duration { get; }
        public string Language { get; }
        public IReadOnlyList<TranscribedSegment> Segments { get; }
        public string Text { get; }
    }
    public enum AudioTranslationFormat {
        Text = 0,
        Simple = 1,
        Verbose = 2,
        Srt = 3,
        Vtt = 4
    }
    public class AudioTranslationOptions {
        public string Prompt { get; set; }
        public AudioTranslationFormat? ResponseFormat { get; set; }
        public float? Temperature { get; set; }
    }
    public readonly partial struct GeneratedSpeechFormat : IEquatable<GeneratedSpeechFormat> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeneratedSpeechFormat(string value);
        public static GeneratedSpeechFormat Aac { get; }
        public static GeneratedSpeechFormat Flac { get; }
        public static GeneratedSpeechFormat Mp3 { get; }
        public static GeneratedSpeechFormat Opus { get; }
        public static GeneratedSpeechFormat Pcm { get; }
        public static GeneratedSpeechFormat Wav { get; }
        public readonly bool Equals(GeneratedSpeechFormat other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(GeneratedSpeechFormat left, GeneratedSpeechFormat right);
        public static implicit operator GeneratedSpeechFormat(string value);
        public static bool operator !=(GeneratedSpeechFormat left, GeneratedSpeechFormat right);
        public override readonly string ToString();
    }
    public readonly partial struct GeneratedSpeechVoice : IEquatable<GeneratedSpeechVoice> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeneratedSpeechVoice(string value);
        public static GeneratedSpeechVoice Alloy { get; }
        public static GeneratedSpeechVoice Echo { get; }
        public static GeneratedSpeechVoice Fable { get; }
        public static GeneratedSpeechVoice Nova { get; }
        public static GeneratedSpeechVoice Onyx { get; }
        public static GeneratedSpeechVoice Shimmer { get; }
        public readonly bool Equals(GeneratedSpeechVoice other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(GeneratedSpeechVoice left, GeneratedSpeechVoice right);
        public static implicit operator GeneratedSpeechVoice(string value);
        public static bool operator !=(GeneratedSpeechVoice left, GeneratedSpeechVoice right);
        public override readonly string ToString();
    }
    public static class OpenAIAudioModelFactory {
        public static AudioTranscription AudioTranscription(string language = null, TimeSpan? duration = null, string text = null, IEnumerable<TranscribedWord> words = null, IEnumerable<TranscribedSegment> segments = null);
        public static AudioTranslation AudioTranslation(string language = null, TimeSpan? duration = null, string text = null, IEnumerable<TranscribedSegment> segments = null);
        public static TranscribedSegment TranscribedSegment(int id = 0, long seekOffset = 0, TimeSpan start = default, TimeSpan end = default, string text = null, IEnumerable<long> tokenIds = null, float temperature = 0, double averageLogProbability = 0, float compressionRatio = 0, double noSpeechProbability = 0);
        public static TranscribedWord TranscribedWord(string word = null, TimeSpan start = default, TimeSpan end = default);
    }
    public class SpeechGenerationOptions {
        public GeneratedSpeechFormat? ResponseFormat { get; set; }
        public float? SpeedRatio { get; set; }
    }
    public readonly partial struct TranscribedSegment {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public double AverageLogProbability { get; }
        public float CompressionRatio { get; }
        public TimeSpan End { get; }
        public int Id { get; }
        public double NoSpeechProbability { get; }
        public long SeekOffset { get; }
        public TimeSpan Start { get; }
        public float Temperature { get; }
        public string Text { get; }
        public IReadOnlyList<long> TokenIds { get; }
    }
    public readonly partial struct TranscribedWord {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeSpan End { get; }
        public TimeSpan Start { get; }
        public string Word { get; }
    }
}
namespace OpenAI.Batch {
    public class BatchClient {
        protected BatchClient();
        public BatchClient(ApiKeyCredential credential, OpenAIClientOptions options);
        public BatchClient(ApiKeyCredential credential);
        protected internal BatchClient(ClientPipeline pipeline, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult CancelBatch(string batchId, RequestOptions options);
        public virtual Task<ClientResult> CancelBatchAsync(string batchId, RequestOptions options);
        public virtual ClientResult CreateBatch(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult> CreateBatchAsync(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult GetBatch(string batchId, RequestOptions options);
        public virtual Task<ClientResult> GetBatchAsync(string batchId, RequestOptions options);
        public virtual IEnumerable<ClientResult> GetBatches(string after, int? limit, RequestOptions options);
        public virtual IAsyncEnumerable<ClientResult> GetBatchesAsync(string after, int? limit, RequestOptions options);
    }
}
namespace OpenAI.Chat {
    public class AssistantChatMessage : ChatMessage {
        public AssistantChatMessage(ChatCompletion chatCompletion);
        public AssistantChatMessage(ChatFunctionCall functionCall, string content = null);
        public AssistantChatMessage(params ChatMessageContentPart[] contentParts);
        public AssistantChatMessage(IEnumerable<ChatMessageContentPart> contentParts);
        public AssistantChatMessage(IEnumerable<ChatToolCall> toolCalls, string content = null);
        public AssistantChatMessage(string content);
        public ChatFunctionCall FunctionCall { get; set; }
        public string ParticipantName { get; set; }
        public string Refusal { get; set; }
        public IList<ChatToolCall> ToolCalls { get; }
    }
    public class ChatClient {
        protected ChatClient();
        protected internal ChatClient(ClientPipeline pipeline, string model, OpenAIClientOptions options);
        public ChatClient(string model, ApiKeyCredential credential, OpenAIClientOptions options);
        public ChatClient(string model, ApiKeyCredential credential);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<ChatCompletion> CompleteChat(params ChatMessage[] messages);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult CompleteChat(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ChatCompletion> CompleteChat(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<ChatCompletion>> CompleteChatAsync(params ChatMessage[] messages);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> CompleteChatAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ChatCompletion>> CompleteChatAsync(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default);
        public virtual CollectionResult<StreamingChatCompletionUpdate> CompleteChatStreaming(params ChatMessage[] messages);
        public virtual CollectionResult<StreamingChatCompletionUpdate> CompleteChatStreaming(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default);
        public virtual AsyncCollectionResult<StreamingChatCompletionUpdate> CompleteChatStreamingAsync(params ChatMessage[] messages);
        public virtual AsyncCollectionResult<StreamingChatCompletionUpdate> CompleteChatStreamingAsync(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default);
    }
    public class ChatCompletion {
        public IReadOnlyList<ChatMessageContentPart> Content { get; }
        public IReadOnlyList<ChatTokenLogProbabilityInfo> ContentTokenLogProbabilities { get; }
        public DateTimeOffset CreatedAt { get; }
        public ChatFinishReason FinishReason { get; }
        public ChatFunctionCall FunctionCall { get; }
        public string Id { get; }
        public string Model { get; }
        public string Refusal { get; }
        public IReadOnlyList<ChatTokenLogProbabilityInfo> RefusalTokenLogProbabilities { get; }
        public ChatMessageRole Role { get; }
        public string SystemFingerprint { get; }
        public IReadOnlyList<ChatToolCall> ToolCalls { get; }
        public ChatTokenUsage Usage { get; }
        public override string ToString();
    }
    public class ChatCompletionOptions {
        public string EndUserId { get; set; }
        public float? FrequencyPenalty { get; set; }
        public ChatFunctionChoice FunctionChoice { get; set; }
        public IList<ChatFunction> Functions { get; }
        public bool? IncludeLogProbabilities { get; set; }
        public IDictionary<int, int> LogitBiases { get; }
        public int? MaxTokens { get; set; }
        public bool? ParallelToolCallsEnabled { get; set; }
        public float? PresencePenalty { get; set; }
        public ChatResponseFormat ResponseFormat { get; set; }
        public long? Seed { get; set; }
        public IList<string> StopSequences { get; }
        public float? Temperature { get; set; }
        public ChatToolChoice ToolChoice { get; set; }
        public IList<ChatTool> Tools { get; }
        public int? TopLogProbabilityCount { get; set; }
        public float? TopP { get; set; }
    }
    public enum ChatFinishReason {
        Stop = 0,
        Length = 1,
        ContentFilter = 2,
        ToolCalls = 3,
        FunctionCall = 4
    }
    [Obsolete("This field is marked as deprecated.")]
    public class ChatFunction {
        public ChatFunction(string functionName, string functionDescription = null, BinaryData functionParameters = null);
        public string FunctionDescription { get; set; }
        public string FunctionName { get; }
        public BinaryData FunctionParameters { get; set; }
    }
    public class ChatFunctionCall {
        public ChatFunctionCall(string functionName, string functionArguments);
        public string FunctionArguments { get; }
        public string FunctionName { get; }
    }
    public class ChatFunctionChoice {
        public ChatFunctionChoice(ChatFunction chatFunction);
        public static ChatFunctionChoice Auto { get; }
        public static ChatFunctionChoice None { get; }
    }
    public readonly partial struct ChatImageDetailLevel : IEquatable<ChatImageDetailLevel> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatImageDetailLevel(string value);
        public static ChatImageDetailLevel Auto { get; }
        public static ChatImageDetailLevel High { get; }
        public static ChatImageDetailLevel Low { get; }
        public readonly bool Equals(ChatImageDetailLevel other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(ChatImageDetailLevel left, ChatImageDetailLevel right);
        public static implicit operator ChatImageDetailLevel(string value);
        public static bool operator !=(ChatImageDetailLevel left, ChatImageDetailLevel right);
        public override readonly string ToString();
    }
    public abstract class ChatMessage {
        protected ChatMessage();
        protected internal ChatMessage(ChatMessageRole role, IEnumerable<ChatMessageContentPart> contentParts);
        protected internal ChatMessage(ChatMessageRole role, string content);
        public IList<ChatMessageContentPart> Content { get; }
        public static AssistantChatMessage CreateAssistantMessage(ChatCompletion chatCompletion);
        public static AssistantChatMessage CreateAssistantMessage(ChatFunctionCall functionCall, string content = null);
        public static AssistantChatMessage CreateAssistantMessage(params ChatMessageContentPart[] contentParts);
        public static AssistantChatMessage CreateAssistantMessage(IEnumerable<ChatMessageContentPart> contentParts);
        public static AssistantChatMessage CreateAssistantMessage(IEnumerable<ChatToolCall> toolCalls, string content = null);
        public static AssistantChatMessage CreateAssistantMessage(string content);
        public static FunctionChatMessage CreateFunctionMessage(string functionName, string content);
        public static SystemChatMessage CreateSystemMessage(params ChatMessageContentPart[] contentParts);
        public static SystemChatMessage CreateSystemMessage(IEnumerable<ChatMessageContentPart> contentParts);
        public static SystemChatMessage CreateSystemMessage(string content);
        public static ToolChatMessage CreateToolChatMessage(string toolCallId, params ChatMessageContentPart[] contentParts);
        public static ToolChatMessage CreateToolChatMessage(string toolCallId, IEnumerable<ChatMessageContentPart> contentParts);
        public static ToolChatMessage CreateToolChatMessage(string toolCallId, string content);
        public static UserChatMessage CreateUserMessage(params ChatMessageContentPart[] contentParts);
        public static UserChatMessage CreateUserMessage(IEnumerable<ChatMessageContentPart> contentParts);
        public static UserChatMessage CreateUserMessage(string content);
        public static implicit operator ChatMessage(string userMessage);
    }
    public class ChatMessageContentPart {
        public BinaryData ImageBytes { get; }
        public string ImageBytesMediaType { get; }
        public ChatImageDetailLevel? ImageDetailLevel { get; }
        public Uri ImageUri { get; }
        public ChatMessageContentPartKind Kind { get; }
        public string Refusal { get; }
        public string Text { get; }
        public static ChatMessageContentPart CreateImagePart(BinaryData imageBytes, string imageBytesMediaType, ChatImageDetailLevel? imageDetailLevel = null);
        public static ChatMessageContentPart CreateImagePart(Uri imageUri, ChatImageDetailLevel? imageDetailLevel = null);
        public static ChatMessageContentPart CreateRefusalPart(string refusal);
        public static ChatMessageContentPart CreateTextPart(string text);
        public static implicit operator ChatMessageContentPart(string text);
    }
    public readonly partial struct ChatMessageContentPartKind : IEquatable<ChatMessageContentPartKind> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatMessageContentPartKind(string value);
        public static ChatMessageContentPartKind Image { get; }
        public static ChatMessageContentPartKind Refusal { get; }
        public static ChatMessageContentPartKind Text { get; }
        public readonly bool Equals(ChatMessageContentPartKind other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(ChatMessageContentPartKind left, ChatMessageContentPartKind right);
        public static implicit operator ChatMessageContentPartKind(string value);
        public static bool operator !=(ChatMessageContentPartKind left, ChatMessageContentPartKind right);
        public override readonly string ToString();
    }
    public enum ChatMessageRole {
        System = 0,
        User = 1,
        Assistant = 2,
        Tool = 3,
        Function = 4
    }
    public abstract class ChatResponseFormat : IEquatable<ChatResponseFormat> {
        public static ChatResponseFormat JsonObject { get; }
        public static ChatResponseFormat Text { get; }
        public static ChatResponseFormat CreateJsonObjectFormat();
        public static ChatResponseFormat CreateJsonSchemaFormat(string name, BinaryData jsonSchema, string description = null, bool? strictSchemaEnabled = null);
        public static ChatResponseFormat CreateTextFormat();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(ChatResponseFormat first, ChatResponseFormat second);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(ChatResponseFormat first, ChatResponseFormat second);
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IEquatable<ChatResponseFormat>.Equals(ChatResponseFormat other);
        public override string ToString();
    }
    public class ChatTokenLogProbabilityInfo {
        public float LogProbability { get; }
        public string Token { get; }
        public IReadOnlyList<ChatTokenTopLogProbabilityInfo> TopLogProbabilities { get; }
        public IReadOnlyList<int> Utf8ByteValues { get; }
    }
    public class ChatTokenTopLogProbabilityInfo {
        public float LogProbability { get; }
        public string Token { get; }
        public IReadOnlyList<int> Utf8ByteValues { get; }
    }
    public class ChatTokenUsage {
        public int InputTokens { get; }
        public int OutputTokens { get; }
        public int TotalTokens { get; }
    }
    public class ChatTool {
        public string FunctionDescription { get; }
        public string FunctionName { get; }
        public BinaryData FunctionParameters { get; }
        public ChatToolKind Kind { get; }
        public bool? StrictParameterSchemaEnabled { get; }
        public static ChatTool CreateFunctionTool(string functionName, string functionDescription = null, BinaryData functionParameters = null, bool? strictParameterSchemaEnabled = null);
    }
    public class ChatToolCall {
        public string FunctionArguments { get; }
        public string FunctionName { get; }
        public string Id { get; set; }
        public ChatToolCallKind Kind { get; }
        public static ChatToolCall CreateFunctionToolCall(string toolCallId, string functionName, string functionArguments);
    }
    public readonly partial struct ChatToolCallKind : IEquatable<ChatToolCallKind> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatToolCallKind(string value);
        public static ChatToolCallKind Function { get; }
        public readonly bool Equals(ChatToolCallKind other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(ChatToolCallKind left, ChatToolCallKind right);
        public static implicit operator ChatToolCallKind(string value);
        public static bool operator !=(ChatToolCallKind left, ChatToolCallKind right);
        public override readonly string ToString();
    }
    public class ChatToolChoice {
        public ChatToolChoice(ChatTool tool);
        public static ChatToolChoice Auto { get; }
        public static ChatToolChoice None { get; }
        public static ChatToolChoice Required { get; }
    }
    public readonly partial struct ChatToolKind : IEquatable<ChatToolKind> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatToolKind(string value);
        public static ChatToolKind Function { get; }
        public readonly bool Equals(ChatToolKind other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(ChatToolKind left, ChatToolKind right);
        public static implicit operator ChatToolKind(string value);
        public static bool operator !=(ChatToolKind left, ChatToolKind right);
        public override readonly string ToString();
    }
    [Obsolete("This field is marked as deprecated.")]
    public class FunctionChatMessage : ChatMessage {
        public FunctionChatMessage(string functionName, string content = null);
        public string FunctionName { get; }
    }
    public static class OpenAIChatModelFactory {
        public static ChatCompletion ChatCompletion(string id = null, ChatFinishReason finishReason = ChatFinishReason.Stop, IEnumerable<ChatMessageContentPart> content = null, string refusal = null, IEnumerable<ChatToolCall> toolCalls = null, ChatMessageRole role = ChatMessageRole.System, ChatFunctionCall functionCall = null, IEnumerable<ChatTokenLogProbabilityInfo> contentTokenLogProbabilities = null, IEnumerable<ChatTokenLogProbabilityInfo> refusalTokenLogProbabilities = null, DateTimeOffset createdAt = default, string model = null, string systemFingerprint = null, ChatTokenUsage usage = null);
        public static ChatTokenLogProbabilityInfo ChatTokenLogProbabilityInfo(string token = null, float logProbability = 0, IEnumerable<int> utf8ByteValues = null, IEnumerable<ChatTokenTopLogProbabilityInfo> topLogProbabilities = null);
        public static ChatTokenTopLogProbabilityInfo ChatTokenTopLogProbabilityInfo(string token = null, float logProbability = 0, IEnumerable<int> utf8ByteValues = null);
        public static ChatTokenUsage ChatTokenUsage(int outputTokens = 0, int inputTokens = 0, int totalTokens = 0);
        public static StreamingChatCompletionUpdate StreamingChatCompletionUpdate(string id = null, IEnumerable<ChatMessageContentPart> contentUpdate = null, StreamingChatFunctionCallUpdate functionCallUpdate = null, IEnumerable<StreamingChatToolCallUpdate> toolCallUpdates = null, ChatMessageRole? role = null, string refusalUpdate = null, IEnumerable<ChatTokenLogProbabilityInfo> contentTokenLogProbabilities = null, IEnumerable<ChatTokenLogProbabilityInfo> refusalTokenLogProbabilities = null, ChatFinishReason? finishReason = null, DateTimeOffset createdAt = default, string model = null, string systemFingerprint = null, ChatTokenUsage usage = null);
        public static StreamingChatFunctionCallUpdate StreamingChatFunctionCallUpdate(string functionArgumentsUpdate = null, string functionName = null);
        public static StreamingChatToolCallUpdate StreamingChatToolCallUpdate(int index = 0, string id = null, ChatToolCallKind kind = default, string functionName = null, string functionArgumentsUpdate = null);
    }
    public class StreamingChatCompletionUpdate {
        public IReadOnlyList<ChatTokenLogProbabilityInfo> ContentTokenLogProbabilities { get; }
        public IReadOnlyList<ChatMessageContentPart> ContentUpdate { get; }
        public DateTimeOffset CreatedAt { get; }
        public ChatFinishReason? FinishReason { get; }
        public StreamingChatFunctionCallUpdate FunctionCallUpdate { get; }
        public string Id { get; }
        public string Model { get; }
        public IReadOnlyList<ChatTokenLogProbabilityInfo> RefusalTokenLogProbabilities { get; }
        public string RefusalUpdate { get; }
        public ChatMessageRole? Role { get; }
        public string SystemFingerprint { get; }
        public IReadOnlyList<StreamingChatToolCallUpdate> ToolCallUpdates { get; }
        public ChatTokenUsage Usage { get; }
    }
    public class StreamingChatFunctionCallUpdate {
        public string FunctionArgumentsUpdate { get; }
        public string FunctionName { get; }
    }
    public class StreamingChatToolCallUpdate {
        public string FunctionArgumentsUpdate { get; }
        public string FunctionName { get; }
        public string Id { get; }
        public int Index { get; }
        public ChatToolCallKind Kind { get; }
    }
    public class SystemChatMessage : ChatMessage {
        public SystemChatMessage(params ChatMessageContentPart[] contentParts);
        public SystemChatMessage(IEnumerable<ChatMessageContentPart> contentParts);
        public SystemChatMessage(string content);
        public string ParticipantName { get; set; }
    }
    public class ToolChatMessage : ChatMessage {
        public ToolChatMessage(string toolCallId, params ChatMessageContentPart[] contentParts);
        public ToolChatMessage(string toolCallId, IEnumerable<ChatMessageContentPart> contentParts);
        public ToolChatMessage(string toolCallId, string content);
        public string ToolCallId { get; }
    }
    public class UserChatMessage : ChatMessage {
        public UserChatMessage(params ChatMessageContentPart[] content);
        public UserChatMessage(IEnumerable<ChatMessageContentPart> content);
        public UserChatMessage(string content);
        public string ParticipantName { get; set; }
    }
}
namespace OpenAI.Embeddings {
    public class Embedding {
        public int Index { get; }
        public ReadOnlyMemory<float> Vector { get; }
    }
    public class EmbeddingClient {
        protected EmbeddingClient();
        protected internal EmbeddingClient(ClientPipeline pipeline, string model, OpenAIClientOptions options);
        public EmbeddingClient(string model, ApiKeyCredential credential, OpenAIClientOptions options);
        public EmbeddingClient(string model, ApiKeyCredential credential);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<Embedding> GenerateEmbedding(string input, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<Embedding>> GenerateEmbeddingAsync(string input, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GenerateEmbeddings(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<EmbeddingCollection> GenerateEmbeddings(IEnumerable<IEnumerable<int>> inputs, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<EmbeddingCollection> GenerateEmbeddings(IEnumerable<string> inputs, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GenerateEmbeddingsAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<EmbeddingCollection>> GenerateEmbeddingsAsync(IEnumerable<IEnumerable<int>> inputs, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<EmbeddingCollection>> GenerateEmbeddingsAsync(IEnumerable<string> inputs, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = default);
    }
    public class EmbeddingCollection : ObjectModel.ReadOnlyCollection<Embedding> {
        public string Model { get; }
        public EmbeddingTokenUsage Usage { get; }
    }
    public class EmbeddingGenerationOptions {
        public int? Dimensions { get; set; }
        public string EndUserId { get; set; }
    }
    public class EmbeddingTokenUsage {
        public int InputTokens { get; }
        public int TotalTokens { get; }
    }
    public static class OpenAIEmbeddingsModelFactory {
        public static Embedding Embedding(int index = 0, IEnumerable<float> vector = null);
        public static EmbeddingCollection EmbeddingCollection(IEnumerable<Embedding> items = null, string model = null, EmbeddingTokenUsage usage = null);
        public static EmbeddingTokenUsage EmbeddingTokenUsage(int inputTokens = 0, int totalTokens = 0);
    }
}
namespace OpenAI.Files {
    public class FileClient {
        protected FileClient();
        public FileClient(ApiKeyCredential credential, OpenAIClientOptions options);
        public FileClient(ApiKeyCredential credential);
        protected internal FileClient(ClientPipeline pipeline, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult DeleteFile(string fileId, RequestOptions options);
        public virtual ClientResult<bool> DeleteFile(string fileId, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> DeleteFileAsync(string fileId, RequestOptions options);
        public virtual Task<ClientResult<bool>> DeleteFileAsync(string fileId, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult DownloadFile(string fileId, RequestOptions options);
        public virtual ClientResult<BinaryData> DownloadFile(string fileId, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> DownloadFileAsync(string fileId, RequestOptions options);
        public virtual Task<ClientResult<BinaryData>> DownloadFileAsync(string fileId, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GetFile(string fileId, RequestOptions options);
        public virtual ClientResult<OpenAIFileInfo> GetFile(string fileId, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GetFileAsync(string fileId, RequestOptions options);
        public virtual Task<ClientResult<OpenAIFileInfo>> GetFileAsync(string fileId, CancellationToken cancellationToken = default);
        public virtual ClientResult<OpenAIFileInfoCollection> GetFiles(OpenAIFilePurpose? purpose = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GetFiles(string purpose, RequestOptions options);
        public virtual Task<ClientResult<OpenAIFileInfoCollection>> GetFilesAsync(OpenAIFilePurpose? purpose = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GetFilesAsync(string purpose, RequestOptions options);
        public virtual ClientResult<OpenAIFileInfo> UploadFile(BinaryData file, string filename, FileUploadPurpose purpose);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult UploadFile(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual ClientResult<OpenAIFileInfo> UploadFile(Stream file, string filename, FileUploadPurpose purpose, CancellationToken cancellationToken = default);
        public virtual ClientResult<OpenAIFileInfo> UploadFile(string filePath, FileUploadPurpose purpose);
        public virtual Task<ClientResult<OpenAIFileInfo>> UploadFileAsync(BinaryData file, string filename, FileUploadPurpose purpose);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> UploadFileAsync(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual Task<ClientResult<OpenAIFileInfo>> UploadFileAsync(Stream file, string filename, FileUploadPurpose purpose, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<OpenAIFileInfo>> UploadFileAsync(string filePath, FileUploadPurpose purpose);
    }
    public readonly partial struct FileUploadPurpose : IEquatable<FileUploadPurpose> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileUploadPurpose(string value);
        public static FileUploadPurpose Assistants { get; }
        public static FileUploadPurpose Batch { get; }
        public static FileUploadPurpose FineTune { get; }
        public static FileUploadPurpose Vision { get; }
        public readonly bool Equals(FileUploadPurpose other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(FileUploadPurpose left, FileUploadPurpose right);
        public static implicit operator FileUploadPurpose(string value);
        public static bool operator !=(FileUploadPurpose left, FileUploadPurpose right);
        public override readonly string ToString();
    }
    public class OpenAIFileInfo {
        public DateTimeOffset CreatedAt { get; }
        public string Filename { get; }
        public string Id { get; }
        public OpenAIFilePurpose Purpose { get; }
        public int? SizeInBytes { get; }
        public OpenAIFileStatus Status { get; }
        public string StatusDetails { get; }
    }
    public class OpenAIFileInfoCollection : ObjectModel.ReadOnlyCollection<OpenAIFileInfo> {
    }
    public readonly partial struct OpenAIFilePurpose : IEquatable<OpenAIFilePurpose> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenAIFilePurpose(string value);
        public static OpenAIFilePurpose Assistants { get; }
        public static OpenAIFilePurpose AssistantsOutput { get; }
        public static OpenAIFilePurpose Batch { get; }
        public static OpenAIFilePurpose BatchOutput { get; }
        public static OpenAIFilePurpose FineTune { get; }
        public static OpenAIFilePurpose FineTuneResults { get; }
        public static OpenAIFilePurpose Vision { get; }
        public readonly bool Equals(OpenAIFilePurpose other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(OpenAIFilePurpose left, OpenAIFilePurpose right);
        public static implicit operator OpenAIFilePurpose(string value);
        public static bool operator !=(OpenAIFilePurpose left, OpenAIFilePurpose right);
        public override readonly string ToString();
    }
    public static class OpenAIFilesModelFactory {
        public static OpenAIFileInfo OpenAIFileInfo(string id = null, int? sizeInBytes = null, DateTimeOffset createdAt = default, string filename = null, OpenAIFilePurpose purpose = default, OpenAIFileStatus status = default, string statusDetails = null);
        public static OpenAIFileInfoCollection OpenAIFileInfoCollection(IEnumerable<OpenAIFileInfo> items = null);
    }
    public readonly partial struct OpenAIFileStatus : IEquatable<OpenAIFileStatus> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenAIFileStatus(string value);
        public static OpenAIFileStatus Error { get; }
        public static OpenAIFileStatus Processed { get; }
        public static OpenAIFileStatus Uploaded { get; }
        public readonly bool Equals(OpenAIFileStatus other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(OpenAIFileStatus left, OpenAIFileStatus right);
        public static implicit operator OpenAIFileStatus(string value);
        public static bool operator !=(OpenAIFileStatus left, OpenAIFileStatus right);
        public override readonly string ToString();
    }
}
namespace OpenAI.FineTuning {
    public class FineTuningClient {
        protected FineTuningClient();
        public FineTuningClient(ApiKeyCredential credential, OpenAIClientOptions options);
        public FineTuningClient(ApiKeyCredential credential);
        protected internal FineTuningClient(ClientPipeline pipeline, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult CancelJob(string jobId, RequestOptions options);
        public virtual ClientResult<FineTuningJob> CancelJob(string jobId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult> CancelJobAsync(string jobId, RequestOptions options);
        public virtual Task<ClientResult<FineTuningJob>> CancelJobAsync(string jobId, CancellationToken cancellationToken = default);
        public virtual ClientResult CreateJob(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<FineTuningJob> CreateJob(string baseModel, string trainingFileId, FineTuningOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult> CreateJobAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<FineTuningJob>> CreateJobAsync(string baseModel, string trainingFileId, FineTuningOptions options = null, CancellationToken cancellationToken = default);
        public virtual IAsyncEnumerable<FineTuningJobEvent> GetEventsAsync(string jobId, ListEventsOptions options = null);
        public virtual ClientResult GetJob(string jobId, RequestOptions options);
        public virtual Task<ClientResult> GetJobAsync(string jobId, RequestOptions options);
        public virtual Task<ClientResult<FineTuningJob>> GetJobAsync(string jobId);
        public virtual IEnumerable<ClientResult> GetJobCheckpoints(string jobId, string after, int? limit, RequestOptions options);
        public virtual IAsyncEnumerable<ClientResult> GetJobCheckpointsAsync(string jobId, string after, int? limit, RequestOptions options);
        public virtual IEnumerable<ClientResult> GetJobs(string after, int? limit, RequestOptions options);
        public virtual IAsyncEnumerable<ClientResult> GetJobsAsync(string after, int? limit, RequestOptions options);
        public virtual IEnumerable<ClientResult> GetLimitedJobEvents(string jobId, string after, int? limit, RequestOptions options);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IAsyncEnumerable<ClientResult> GetLimitedJobEventsAsync(string jobId, ListEventsOptions options = null, RequestOptions requestoptions = null);
        public virtual Task<FineTuningJob> WaitUntilCompleted(FineTuningJob job);
    }
    public abstract class FineTuningIntegration {
        public static FineTuningIntegration CreateWeightsAndBiasesIntegration(string projectName, string displayName = null, string entityName = null, IEnumerable<string> tags = null);
    }
    public class FineTuningJob {
        public string BaseModel { get; }
        public int? BillableTrainedTokens { get; }
        public DateTimeOffset CreatedAt { get; }
        public FineTuningJobError Error { get; }
        public DateTimeOffset? EstimatedFinishAt { get; }
        public string FineTunedModel { get; }
        public DateTimeOffset? FinishedAt { get; }
        public FineTuningJobHyperparameters Hyperparameters { get; set; }
        public string Id { get; }
        public IReadOnlyList<FineTuningIntegration> Integrations { get; }
        public string OrganizationId { get; }
        public Uri PlaygroundUri { get; }
        public IReadOnlyList<string> ResultFileIds { get; }
        public int Seed { get; }
        public FineTuningJobStatus Status { get; }
        public string TrainingFileId { get; }
        public string UserProvidedSuffix { get; }
        public string ValidationFileId { get; }
    }
    public class FineTuningJobError {
        public string Code { get; }
        public string InvalidParameter { get; }
        public string Message { get; }
    }
    public class FineTuningJobEvent {
        public string InternalFineTuningJobEventLevel;
        public DateTimeOffset CreatedAt { get; }
        public string Id { get; }
        public FineTuningJobEventLevel Level { get; }
        public string Message { get; }
        public FineTuningJobEventObject Object { get; }
    }
    public readonly partial struct FineTuningJobHyperparameters {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public int BatchSize { get; }
        public int CycleCount { get; }
        public float LearningRateMultiplier { get; }
        public IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
    }
    public readonly partial struct FineTuningJobStatus : IEquatable<FineTuningJobStatus> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FineTuningJobStatus(string value);
        public static FineTuningJobStatus Cancelled { get; }
        public static FineTuningJobStatus Failed { get; }
        public bool InProgress { get; }
        public static FineTuningJobStatus Queued { get; }
        public static FineTuningJobStatus Running { get; }
        public static FineTuningJobStatus Succeeded { get; }
        public static FineTuningJobStatus ValidatingFiles { get; }
        public readonly bool Equals(FineTuningJobStatus other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(FineTuningJobStatus left, FineTuningJobStatus right);
        public static implicit operator FineTuningJobStatus(string value);
        public static bool operator !=(FineTuningJobStatus left, FineTuningJobStatus right);
        public override readonly string ToString();
    }
    public class FineTuningOptions {
        public HyperparameterOptions Hyperparameters { get; set; }
        public IList<FineTuningIntegration> Integrations { get; }
        public int? Seed { get; set; }
        public string Suffix { get; set; }
        public string ValidationFile { get; set; }
    }
    public readonly partial struct HyperparameterBatchSize : IEquatable<int>, IEquatable<string>, IEquatable<HyperparameterBatchSize> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperparameterBatchSize(int batchSize);
        public static HyperparameterBatchSize Auto { get; }
        public readonly bool Equals(HyperparameterBatchSize other);
        public readonly bool Equals(int other);
        public override readonly bool Equals(object other);
        public readonly bool Equals(string other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(HyperparameterBatchSize left, HyperparameterBatchSize right);
        public static implicit operator HyperparameterBatchSize(int batchSize);
        public static implicit operator HyperparameterBatchSize(string value);
        public static bool operator !=(HyperparameterBatchSize left, HyperparameterBatchSize right);
        public override readonly string ToString();
    }
    public readonly partial struct HyperparameterCycleCount : IEquatable<int>, IEquatable<string>, IEquatable<HyperparameterCycleCount> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperparameterCycleCount(int epochCount);
        public static HyperparameterCycleCount Auto { get; }
        public readonly bool Equals(HyperparameterCycleCount other);
        public readonly bool Equals(int other);
        public override readonly bool Equals(object other);
        public readonly bool Equals(string other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(HyperparameterCycleCount left, HyperparameterCycleCount right);
        public static implicit operator HyperparameterCycleCount(int epochCount);
        public static implicit operator HyperparameterCycleCount(string value);
        public static bool operator !=(HyperparameterCycleCount left, HyperparameterCycleCount right);
        public override readonly string ToString();
    }
    public readonly partial struct HyperparameterLearningRate : IEquatable<float>, IEquatable<double>, IEquatable<string>, IEquatable<HyperparameterLearningRate> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperparameterLearningRate(double multiplier);
        public HyperparameterLearningRate(float multiplier);
        public static HyperparameterLearningRate Auto { get; }
        public readonly bool Equals(HyperparameterLearningRate other);
        public readonly bool Equals(double other);
        public override readonly bool Equals(object other);
        public readonly bool Equals(float other);
        public readonly bool Equals(string other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(HyperparameterLearningRate left, HyperparameterLearningRate right);
        public static implicit operator HyperparameterLearningRate(double multiplier);
        public static implicit operator HyperparameterLearningRate(float multiplier);
        public static implicit operator HyperparameterLearningRate(string value);
        public static bool operator !=(HyperparameterLearningRate left, HyperparameterLearningRate right);
        public override readonly string ToString();
    }
    public class HyperparameterOptions {
        public HyperparameterOptions();
        public HyperparameterOptions(HyperparameterCycleCount cycleCount = default, HyperparameterBatchSize batchSize = default, HyperparameterLearningRate learningRate = default, IDictionary<string, BinaryData> serializedAdditionalRawData = null);
        public HyperparameterBatchSize BatchSize { get; }
        public HyperparameterCycleCount CycleCount { get; }
        public HyperparameterLearningRate LearningRate { get; }
    }
    public class ListEventsOptions {
        public string After { get; set; }
        public int? Limit { get; set; }
    }
    public class WeightsAndBiasesIntegration : FineTuningIntegration {
        public WeightsAndBiasesIntegration();
        public WeightsAndBiasesIntegration(string projectName);
        public string DisplayName { get; set; }
        public string EntityName { get; set; }
        public required string ProjectName { get; set; }
        public IList<string> Tags { get; }
    }
}
namespace OpenAI.Images {
    public class GeneratedImage {
        public BinaryData ImageBytes { get; }
        public Uri ImageUri { get; }
        public string RevisedPrompt { get; }
    }
    public class GeneratedImageCollection : ObjectModel.ReadOnlyCollection<GeneratedImage> {
        public DateTimeOffset Created { get; }
        public DateTimeOffset CreatedAt { get; }
    }
    public enum GeneratedImageFormat {
        Bytes = 0,
        Uri = 1
    }
    public enum GeneratedImageQuality {
        High = 0,
        Standard = 1
    }
    public readonly partial struct GeneratedImageSize : IEquatable<GeneratedImageSize> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public static readonly GeneratedImageSize W1024xH1024;
        public static readonly GeneratedImageSize W1024xH1792;
        public static readonly GeneratedImageSize W1792xH1024;
        public static readonly GeneratedImageSize W256xH256;
        public static readonly GeneratedImageSize W512xH512;
        public GeneratedImageSize(int width, int height);
        public readonly bool Equals(GeneratedImageSize other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(GeneratedImageSize left, GeneratedImageSize right);
        public static bool operator !=(GeneratedImageSize left, GeneratedImageSize right);
        public override readonly string ToString();
    }
    public enum GeneratedImageStyle {
        Vivid = 0,
        Natural = 1
    }
    public class ImageClient {
        protected ImageClient();
        protected internal ImageClient(ClientPipeline pipeline, string model, OpenAIClientOptions options);
        public ImageClient(string model, ApiKeyCredential credential, OpenAIClientOptions options);
        public ImageClient(string model, ApiKeyCredential credential);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<GeneratedImage> GenerateImage(string prompt, ImageGenerationOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageAsync(string prompt, ImageGenerationOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<GeneratedImage> GenerateImageEdit(Stream image, string imageFilename, string prompt, ImageEditOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<GeneratedImage> GenerateImageEdit(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, ImageEditOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<GeneratedImage> GenerateImageEdit(string imageFilePath, string prompt, ImageEditOptions options = null);
        public virtual ClientResult<GeneratedImage> GenerateImageEdit(string imageFilePath, string prompt, string maskFilePath, ImageEditOptions options = null);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageEditAsync(Stream image, string imageFilename, string prompt, ImageEditOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageEditAsync(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, ImageEditOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageEditAsync(string imageFilePath, string prompt, ImageEditOptions options = null);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageEditAsync(string imageFilePath, string prompt, string maskFilePath, ImageEditOptions options = null);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GenerateImageEdits(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual ClientResult<GeneratedImageCollection> GenerateImageEdits(Stream image, string imageFilename, string prompt, int imageCount, ImageEditOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<GeneratedImageCollection> GenerateImageEdits(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, int imageCount, ImageEditOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<GeneratedImageCollection> GenerateImageEdits(string imageFilePath, string prompt, int imageCount, ImageEditOptions options = null);
        public virtual ClientResult<GeneratedImageCollection> GenerateImageEdits(string imageFilePath, string prompt, string maskFilePath, int imageCount, ImageEditOptions options = null);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GenerateImageEditsAsync(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImageEditsAsync(Stream image, string imageFilename, string prompt, int imageCount, ImageEditOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImageEditsAsync(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, int imageCount, ImageEditOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImageEditsAsync(string imageFilePath, string prompt, int imageCount, ImageEditOptions options = null);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImageEditsAsync(string imageFilePath, string prompt, string maskFilePath, int imageCount, ImageEditOptions options = null);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GenerateImages(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<GeneratedImageCollection> GenerateImages(string prompt, int imageCount, ImageGenerationOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GenerateImagesAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImagesAsync(string prompt, int imageCount, ImageGenerationOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<GeneratedImage> GenerateImageVariation(Stream image, string imageFilename, ImageVariationOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<GeneratedImage> GenerateImageVariation(string imageFilePath, ImageVariationOptions options = null);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageVariationAsync(Stream image, string imageFilename, ImageVariationOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageVariationAsync(string imageFilePath, ImageVariationOptions options = null);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GenerateImageVariations(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual ClientResult<GeneratedImageCollection> GenerateImageVariations(Stream image, string imageFilename, int imageCount, ImageVariationOptions options = null, CancellationToken cancellationToken = default);
        public virtual ClientResult<GeneratedImageCollection> GenerateImageVariations(string imageFilePath, int imageCount, ImageVariationOptions options = null);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GenerateImageVariationsAsync(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImageVariationsAsync(Stream image, string imageFilename, int imageCount, ImageVariationOptions options = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImageVariationsAsync(string imageFilePath, int imageCount, ImageVariationOptions options = null);
    }
    public class ImageEditOptions {
        public string EndUserId { get; set; }
        public GeneratedImageFormat? ResponseFormat { get; set; }
        public GeneratedImageSize? Size { get; set; }
    }
    public class ImageGenerationOptions {
        public string EndUserId { get; set; }
        public GeneratedImageQuality? Quality { get; set; }
        public GeneratedImageFormat? ResponseFormat { get; set; }
        public GeneratedImageSize? Size { get; set; }
        public GeneratedImageStyle? Style { get; set; }
    }
    public class ImageVariationOptions {
        public string EndUserId { get; set; }
        public GeneratedImageFormat? ResponseFormat { get; set; }
        public GeneratedImageSize? Size { get; set; }
    }
    public static class OpenAIImagesModelFactory {
        public static GeneratedImage GeneratedImage(BinaryData imageBytes = null, Uri imageUri = null, string revisedPrompt = null);
        public static GeneratedImageCollection GeneratedImageCollection(DateTimeOffset createdAt = default, IEnumerable<GeneratedImage> items = null);
    }
}
namespace OpenAI.Models {
    public readonly partial struct CreateFineTuningJobRequestModel : IEquatable<CreateFineTuningJobRequestModel> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateFineTuningJobRequestModel(string value);
        public static CreateFineTuningJobRequestModel Babbage002 { get; }
        public static CreateFineTuningJobRequestModel Davinci002 { get; }
        public static CreateFineTuningJobRequestModel Gpt35Turbo { get; }
        public static CreateFineTuningJobRequestModel Gpt4oMini { get; }
        public readonly bool Equals(CreateFineTuningJobRequestModel other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(CreateFineTuningJobRequestModel left, CreateFineTuningJobRequestModel right);
        public static implicit operator CreateFineTuningJobRequestModel(string value);
        public static bool operator !=(CreateFineTuningJobRequestModel left, CreateFineTuningJobRequestModel right);
        public override readonly string ToString();
    }
    public enum FineTuningJobEventLevel {
        Info = 0,
        Warn = 1,
        Error = 2
    }
    public readonly partial struct FineTuningJobEventObject : IEquatable<FineTuningJobEventObject> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FineTuningJobEventObject(string value);
        public static FineTuningJobEventObject FineTuningJobEvent { get; }
        public readonly bool Equals(FineTuningJobEventObject other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(FineTuningJobEventObject left, FineTuningJobEventObject right);
        public static implicit operator FineTuningJobEventObject(string value);
        public static bool operator !=(FineTuningJobEventObject left, FineTuningJobEventObject right);
        public override readonly string ToString();
    }
    public readonly partial struct ListFineTuningJobEventsResponseObject : IEquatable<ListFineTuningJobEventsResponseObject> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListFineTuningJobEventsResponseObject(string value);
        public static ListFineTuningJobEventsResponseObject List { get; }
        public readonly bool Equals(ListFineTuningJobEventsResponseObject other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(ListFineTuningJobEventsResponseObject left, ListFineTuningJobEventsResponseObject right);
        public static implicit operator ListFineTuningJobEventsResponseObject(string value);
        public static bool operator !=(ListFineTuningJobEventsResponseObject left, ListFineTuningJobEventsResponseObject right);
        public override readonly string ToString();
    }
    public class ModelClient {
        protected ModelClient();
        public ModelClient(ApiKeyCredential credential, OpenAIClientOptions options);
        public ModelClient(ApiKeyCredential credential);
        protected internal ModelClient(ClientPipeline pipeline, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult DeleteModel(string model, RequestOptions options);
        public virtual ClientResult<bool> DeleteModel(string model);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> DeleteModelAsync(string model, RequestOptions options);
        public virtual Task<ClientResult<bool>> DeleteModelAsync(string model);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GetModel(string model, RequestOptions options);
        public virtual ClientResult<OpenAIModelInfo> GetModel(string model);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GetModelAsync(string model, RequestOptions options);
        public virtual Task<ClientResult<OpenAIModelInfo>> GetModelAsync(string model);
        public virtual ClientResult<OpenAIModelInfoCollection> GetModels();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GetModels(RequestOptions options);
        public virtual Task<ClientResult<OpenAIModelInfoCollection>> GetModelsAsync();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GetModelsAsync(RequestOptions options);
    }
    public class OpenAIModelInfo {
        public DateTimeOffset CreatedAt { get; }
        public string Id { get; }
        public string OwnedBy { get; }
    }
    public class OpenAIModelInfoCollection : ObjectModel.ReadOnlyCollection<OpenAIModelInfo> {
    }
    public static class OpenAIModelsModelFactory {
        public static OpenAIModelInfo OpenAIModelInfo(string id = null, DateTimeOffset createdAt = default, string ownedBy = null);
        public static OpenAIModelInfoCollection OpenAIModelInfoCollection(IEnumerable<OpenAIModelInfo> items = null);
    }
}
namespace OpenAI.Moderations {
    public class ModerationCategories {
        public bool Harassment { get; }
        public bool HarassmentThreatening { get; }
        public bool Hate { get; }
        public bool HateThreatening { get; }
        public bool SelfHarm { get; }
        public bool SelfHarmInstructions { get; }
        public bool SelfHarmIntent { get; }
        public bool Sexual { get; }
        public bool SexualMinors { get; }
        public bool Violence { get; }
        public bool ViolenceGraphic { get; }
    }
    public class ModerationCategoryScores {
        public float Harassment { get; }
        public float HarassmentThreatening { get; }
        public float Hate { get; }
        public float HateThreatening { get; }
        public float SelfHarm { get; }
        public float SelfHarmInstructions { get; }
        public float SelfHarmIntent { get; }
        public float Sexual { get; }
        public float SexualMinors { get; }
        public float Violence { get; }
        public float ViolenceGraphic { get; }
    }
    public class ModerationClient {
        protected ModerationClient();
        protected internal ModerationClient(ClientPipeline pipeline, string model, OpenAIClientOptions options);
        public ModerationClient(string model, ApiKeyCredential credential, OpenAIClientOptions options);
        public ModerationClient(string model, ApiKeyCredential credential);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<ModerationResult> ClassifyTextInput(string input, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<ModerationResult>> ClassifyTextInputAsync(string input, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult ClassifyTextInputs(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ModerationCollection> ClassifyTextInputs(IEnumerable<string> inputs, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> ClassifyTextInputsAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ModerationCollection>> ClassifyTextInputsAsync(IEnumerable<string> inputs, CancellationToken cancellationToken = default);
    }
    public class ModerationCollection : ObjectModel.ReadOnlyCollection<ModerationResult> {
        public string Id { get; }
        public string Model { get; }
    }
    public class ModerationResult {
        public ModerationCategories Categories { get; }
        public ModerationCategoryScores CategoryScores { get; }
        public bool Flagged { get; }
    }
    public static class OpenAIModerationsModelFactory {
        public static ModerationCategories ModerationCategories(bool hate = false, bool hateThreatening = false, bool harassment = false, bool harassmentThreatening = false, bool selfHarm = false, bool selfHarmIntent = false, bool selfHarmInstructions = false, bool sexual = false, bool sexualMinors = false, bool violence = false, bool violenceGraphic = false);
        public static ModerationCategoryScores ModerationCategoryScores(float hate = 0, float hateThreatening = 0, float harassment = 0, float harassmentThreatening = 0, float selfHarm = 0, float selfHarmIntent = 0, float selfHarmInstructions = 0, float sexual = 0, float sexualMinors = 0, float violence = 0, float violenceGraphic = 0);
        public static ModerationCollection ModerationCollection(string id = null, string model = null, IEnumerable<ModerationResult> items = null);
        public static ModerationResult ModerationResult(bool flagged = false, ModerationCategories categories = null, ModerationCategoryScores categoryScores = null);
    }
}
namespace OpenAI.VectorStores {
    public abstract class FileChunkingStrategy {
        public static FileChunkingStrategy Auto { get; }
        public static FileChunkingStrategy Unknown { get; }
        public static FileChunkingStrategy CreateStaticStrategy(int maxTokensPerChunk, int overlappingTokenCount);
    }
    public class StaticFileChunkingStrategy : FileChunkingStrategy {
        public StaticFileChunkingStrategy(int maxTokensPerChunk, int overlappingTokenCount);
        public int MaxTokensPerChunk { get; }
        public int OverlappingTokenCount { get; }
    }
    public class VectorStore {
        public DateTimeOffset CreatedAt { get; }
        public VectorStoreExpirationPolicy ExpirationPolicy { get; }
        public DateTimeOffset? ExpiresAt { get; }
        public VectorStoreFileCounts FileCounts { get; }
        public string Id { get; }
        public DateTimeOffset? LastActiveAt { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public string Name { get; }
        public VectorStoreStatus Status { get; }
        public int UsageBytes { get; }
    }
    public class VectorStoreBatchFileJob {
        public string BatchId { get; }
        public DateTimeOffset CreatedAt { get; }
        public VectorStoreFileCounts FileCounts { get; }
        public VectorStoreBatchFileJobStatus Status { get; }
        public string VectorStoreId { get; }
    }
    public readonly partial struct VectorStoreBatchFileJobStatus : IEquatable<VectorStoreBatchFileJobStatus> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreBatchFileJobStatus(string value);
        public static VectorStoreBatchFileJobStatus Cancelled { get; }
        public static VectorStoreBatchFileJobStatus Completed { get; }
        public static VectorStoreBatchFileJobStatus Failed { get; }
        public static VectorStoreBatchFileJobStatus InProgress { get; }
        public readonly bool Equals(VectorStoreBatchFileJobStatus other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(VectorStoreBatchFileJobStatus left, VectorStoreBatchFileJobStatus right);
        public static implicit operator VectorStoreBatchFileJobStatus(string value);
        public static bool operator !=(VectorStoreBatchFileJobStatus left, VectorStoreBatchFileJobStatus right);
        public override readonly string ToString();
    }
    public class VectorStoreClient {
        protected VectorStoreClient();
        public VectorStoreClient(ApiKeyCredential credential, OpenAIClientOptions options);
        public VectorStoreClient(ApiKeyCredential credential);
        protected internal VectorStoreClient(ClientPipeline pipeline, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<VectorStoreFileAssociation> AddFileToVectorStore(VectorStore vectorStore, OpenAIFileInfo file);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult AddFileToVectorStore(string vectorStoreId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<VectorStoreFileAssociation> AddFileToVectorStore(string vectorStoreId, string fileId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<VectorStoreFileAssociation>> AddFileToVectorStoreAsync(VectorStore vectorStore, OpenAIFileInfo file);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> AddFileToVectorStoreAsync(string vectorStoreId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<VectorStoreFileAssociation>> AddFileToVectorStoreAsync(string vectorStoreId, string fileId, CancellationToken cancellationToken = default);
        public virtual ClientResult<VectorStoreBatchFileJob> CancelBatchFileJob(VectorStoreBatchFileJob batchJob);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult CancelBatchFileJob(string vectorStoreId, string batchId, RequestOptions options);
        public virtual ClientResult<VectorStoreBatchFileJob> CancelBatchFileJob(string vectorStoreId, string batchJobId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<VectorStoreBatchFileJob>> CancelBatchFileJobAsync(VectorStoreBatchFileJob batchJob);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> CancelBatchFileJobAsync(string vectorStoreId, string batchId, RequestOptions options);
        public virtual Task<ClientResult<VectorStoreBatchFileJob>> CancelBatchFileJobAsync(string vectorStoreId, string batchJobId, CancellationToken cancellationToken = default);
        public virtual ClientResult<VectorStoreBatchFileJob> CreateBatchFileJob(VectorStore vectorStore, IEnumerable<OpenAIFileInfo> files);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult CreateBatchFileJob(string vectorStoreId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<VectorStoreBatchFileJob> CreateBatchFileJob(string vectorStoreId, IEnumerable<string> fileIds, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<VectorStoreBatchFileJob>> CreateBatchFileJobAsync(VectorStore vectorStore, IEnumerable<OpenAIFileInfo> files);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> CreateBatchFileJobAsync(string vectorStoreId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<VectorStoreBatchFileJob>> CreateBatchFileJobAsync(string vectorStoreId, IEnumerable<string> fileIds, CancellationToken cancellationToken = default);
        public virtual ClientResult<VectorStore> CreateVectorStore(VectorStoreCreationOptions vectorStore = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult CreateVectorStore(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<VectorStore>> CreateVectorStoreAsync(VectorStoreCreationOptions vectorStore = null, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult> CreateVectorStoreAsync(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<bool> DeleteVectorStore(VectorStore vectorStore);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult DeleteVectorStore(string vectorStoreId, RequestOptions options);
        public virtual ClientResult<bool> DeleteVectorStore(string vectorStoreId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<bool>> DeleteVectorStoreAsync(VectorStore vectorStore);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> DeleteVectorStoreAsync(string vectorStoreId, RequestOptions options);
        public virtual Task<ClientResult<bool>> DeleteVectorStoreAsync(string vectorStoreId, CancellationToken cancellationToken = default);
        public virtual ClientResult<VectorStoreBatchFileJob> GetBatchFileJob(VectorStoreBatchFileJob batchJob);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GetBatchFileJob(string vectorStoreId, string batchId, RequestOptions options);
        public virtual ClientResult<VectorStoreBatchFileJob> GetBatchFileJob(string vectorStoreId, string batchJobId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<VectorStoreBatchFileJob>> GetBatchFileJobAsync(VectorStoreBatchFileJob batchJob);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GetBatchFileJobAsync(string vectorStoreId, string batchId, RequestOptions options);
        public virtual Task<ClientResult<VectorStoreBatchFileJob>> GetBatchFileJobAsync(string vectorStoreId, string batchJobId, CancellationToken cancellationToken = default);
        public virtual ClientResult<VectorStoreFileAssociation> GetFileAssociation(VectorStore vectorStore, OpenAIFileInfo file);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GetFileAssociation(string vectorStoreId, string fileId, RequestOptions options);
        public virtual ClientResult<VectorStoreFileAssociation> GetFileAssociation(string vectorStoreId, string fileId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<VectorStoreFileAssociation>> GetFileAssociationAsync(VectorStore vectorStore, OpenAIFileInfo file);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GetFileAssociationAsync(string vectorStoreId, string fileId, RequestOptions options);
        public virtual Task<ClientResult<VectorStoreFileAssociation>> GetFileAssociationAsync(string vectorStoreId, string fileId, CancellationToken cancellationToken = default);
        public virtual PageCollection<VectorStoreFileAssociation> GetFileAssociations(VectorStore vectorStore, VectorStoreFileAssociationCollectionOptions options = null);
        public virtual PageCollection<VectorStoreFileAssociation> GetFileAssociations(VectorStoreBatchFileJob batchJob, VectorStoreFileAssociationCollectionOptions options = null);
        public virtual PageCollection<VectorStoreFileAssociation> GetFileAssociations(ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        public virtual PageCollection<VectorStoreFileAssociation> GetFileAssociations(string vectorStoreId, VectorStoreFileAssociationCollectionOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IEnumerable<ClientResult> GetFileAssociations(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options);
        public virtual PageCollection<VectorStoreFileAssociation> GetFileAssociations(string vectorStoreId, string batchJobId, VectorStoreFileAssociationCollectionOptions options = null, CancellationToken cancellationToken = default);
        public virtual PageCollection<VectorStoreFileAssociation> GetFileAssociations(string vectorStoreId, string batchJobId, ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IEnumerable<ClientResult> GetFileAssociations(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options);
        public virtual AsyncPageCollection<VectorStoreFileAssociation> GetFileAssociationsAsync(VectorStore vectorStore, VectorStoreFileAssociationCollectionOptions options = null);
        public virtual AsyncPageCollection<VectorStoreFileAssociation> GetFileAssociationsAsync(VectorStoreBatchFileJob batchJob, VectorStoreFileAssociationCollectionOptions options = null);
        public virtual AsyncPageCollection<VectorStoreFileAssociation> GetFileAssociationsAsync(ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        public virtual AsyncPageCollection<VectorStoreFileAssociation> GetFileAssociationsAsync(string vectorStoreId, VectorStoreFileAssociationCollectionOptions options = null, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IAsyncEnumerable<ClientResult> GetFileAssociationsAsync(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options);
        public virtual AsyncPageCollection<VectorStoreFileAssociation> GetFileAssociationsAsync(string vectorStoreId, string batchJobId, VectorStoreFileAssociationCollectionOptions options = null, CancellationToken cancellationToken = default);
        public virtual AsyncPageCollection<VectorStoreFileAssociation> GetFileAssociationsAsync(string vectorStoreId, string batchJobId, ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IAsyncEnumerable<ClientResult> GetFileAssociationsAsync(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options);
        public virtual ClientResult<VectorStore> GetVectorStore(VectorStore vectorStore);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult GetVectorStore(string vectorStoreId, RequestOptions options);
        public virtual ClientResult<VectorStore> GetVectorStore(string vectorStoreId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<VectorStore>> GetVectorStoreAsync(VectorStore vectorStore);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> GetVectorStoreAsync(string vectorStoreId, RequestOptions options);
        public virtual Task<ClientResult<VectorStore>> GetVectorStoreAsync(string vectorStoreId, CancellationToken cancellationToken = default);
        public virtual PageCollection<VectorStore> GetVectorStores(VectorStoreCollectionOptions options = null, CancellationToken cancellationToken = default);
        public virtual PageCollection<VectorStore> GetVectorStores(ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IEnumerable<ClientResult> GetVectorStores(int? limit, string order, string after, string before, RequestOptions options);
        public virtual AsyncPageCollection<VectorStore> GetVectorStoresAsync(VectorStoreCollectionOptions options = null, CancellationToken cancellationToken = default);
        public virtual AsyncPageCollection<VectorStore> GetVectorStoresAsync(ContinuationToken firstPageToken, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IAsyncEnumerable<ClientResult> GetVectorStoresAsync(int? limit, string order, string after, string before, RequestOptions options);
        public virtual ClientResult<VectorStore> ModifyVectorStore(VectorStore vectorStore, VectorStoreModificationOptions options);
        public virtual ClientResult<VectorStore> ModifyVectorStore(string vectorStoreId, VectorStoreModificationOptions vectorStore, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult ModifyVectorStore(string vectorStoreId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<VectorStore>> ModifyVectorStoreAsync(VectorStore vectorStore, VectorStoreModificationOptions options);
        public virtual Task<ClientResult<VectorStore>> ModifyVectorStoreAsync(string vectorStoreId, VectorStoreModificationOptions vectorStore, CancellationToken cancellationToken = default);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> ModifyVectorStoreAsync(string vectorStoreId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<bool> RemoveFileFromStore(VectorStore vectorStore, OpenAIFileInfo file);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ClientResult RemoveFileFromStore(string vectorStoreId, string fileId, RequestOptions options);
        public virtual ClientResult<bool> RemoveFileFromStore(string vectorStoreId, string fileId, CancellationToken cancellationToken = default);
        public virtual Task<ClientResult<bool>> RemoveFileFromStoreAsync(VectorStore vectorStore, OpenAIFileInfo file);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ClientResult> RemoveFileFromStoreAsync(string vectorStoreId, string fileId, RequestOptions options);
        public virtual Task<ClientResult<bool>> RemoveFileFromStoreAsync(string vectorStoreId, string fileId, CancellationToken cancellationToken = default);
    }
    public class VectorStoreCollectionOptions {
        public string AfterId { get; set; }
        public string BeforeId { get; set; }
        public ListOrder? Order { get; set; }
        public int? PageSize { get; set; }
    }
    public class VectorStoreCreationOptions {
        public FileChunkingStrategy ChunkingStrategy { get; set; }
        public VectorStoreExpirationPolicy ExpirationPolicy { get; set; }
        public IList<string> FileIds { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
        public string Name { get; set; }
    }
    public enum VectorStoreExpirationAnchor {
        Unknown = 0,
        LastActiveAt = 1
    }
    public class VectorStoreExpirationPolicy {
        public VectorStoreExpirationPolicy();
        public VectorStoreExpirationPolicy(VectorStoreExpirationAnchor anchor, int days);
        public required VectorStoreExpirationAnchor Anchor { get; set; }
        public required int Days { get; set; }
    }
    public class VectorStoreFileAssociation {
        public FileChunkingStrategy ChunkingStrategy { get; }
        public DateTimeOffset CreatedAt { get; }
        public string FileId { get; }
        public VectorStoreFileAssociationError LastError { get; }
        public int Size { get; }
        public VectorStoreFileAssociationStatus Status { get; }
        public string VectorStoreId { get; }
    }
    public class VectorStoreFileAssociationCollectionOptions {
        public string AfterId { get; set; }
        public string BeforeId { get; set; }
        public VectorStoreFileStatusFilter? Filter { get; set; }
        public ListOrder? Order { get; set; }
        public int? PageSize { get; set; }
    }
    public class VectorStoreFileAssociationError {
        public VectorStoreFileAssociationErrorCode Code { get; }
        public string Message { get; }
    }
    public readonly partial struct VectorStoreFileAssociationErrorCode : IEquatable<VectorStoreFileAssociationErrorCode> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileAssociationErrorCode(string value);
        public static VectorStoreFileAssociationErrorCode InvalidFile { get; }
        public static VectorStoreFileAssociationErrorCode ServerError { get; }
        public static VectorStoreFileAssociationErrorCode UnsupportedFile { get; }
        public readonly bool Equals(VectorStoreFileAssociationErrorCode other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(VectorStoreFileAssociationErrorCode left, VectorStoreFileAssociationErrorCode right);
        public static implicit operator VectorStoreFileAssociationErrorCode(string value);
        public static bool operator !=(VectorStoreFileAssociationErrorCode left, VectorStoreFileAssociationErrorCode right);
        public override readonly string ToString();
    }
    public enum VectorStoreFileAssociationStatus {
        Unknown = 0,
        InProgress = 1,
        Completed = 2,
        Cancelled = 3,
        Failed = 4
    }
    public class VectorStoreFileCounts {
        public int Cancelled { get; }
        public int Completed { get; }
        public int Failed { get; }
        public int InProgress { get; }
        public int Total { get; }
    }
    public readonly partial struct VectorStoreFileStatusFilter : IEquatable<VectorStoreFileStatusFilter> {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatusFilter(string value);
        public static VectorStoreFileStatusFilter Cancelled { get; }
        public static VectorStoreFileStatusFilter Completed { get; }
        public static VectorStoreFileStatusFilter Failed { get; }
        public static VectorStoreFileStatusFilter InProgress { get; }
        public readonly bool Equals(VectorStoreFileStatusFilter other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override readonly int GetHashCode();
        public static bool operator ==(VectorStoreFileStatusFilter left, VectorStoreFileStatusFilter right);
        public static implicit operator VectorStoreFileStatusFilter(string value);
        public static bool operator !=(VectorStoreFileStatusFilter left, VectorStoreFileStatusFilter right);
        public override readonly string ToString();
    }
    public class VectorStoreModificationOptions {
        public VectorStoreExpirationPolicy ExpirationPolicy { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
        public string Name { get; set; }
    }
    public enum VectorStoreStatus {
        Unknown = 0,
        InProgress = 1,
        Completed = 2,
        Expired = 3
    }
}