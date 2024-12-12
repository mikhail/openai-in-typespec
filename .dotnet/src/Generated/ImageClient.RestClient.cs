// <auto-generated/>

#nullable disable

using System.ClientModel;
using System.ClientModel.Primitives;
using OpenAI;

namespace OpenAI.Images
{
    public partial class ImageClient
    {
        private static PipelineMessageClassifier _pipelineMessageClassifier200;

        private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

        internal PipelineMessage CreateCreateImageRequest(BinaryContent content, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "POST";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/images/generations", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateCreateImageEditRequest(BinaryContent content, string contentType, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "POST";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/images/edits", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", contentType);
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateCreateImageVariationRequest(BinaryContent content, string contentType, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "POST";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/images/variations", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", contentType);
            request.Content = content;
            message.Apply(options);
            return message;
        }
    }
}
