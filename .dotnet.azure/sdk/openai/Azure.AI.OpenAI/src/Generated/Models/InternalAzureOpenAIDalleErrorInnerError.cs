// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    internal partial class InternalAzureOpenAIDalleErrorInnerError
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalAzureOpenAIDalleErrorInnerError()
        {
        }

        internal InternalAzureOpenAIDalleErrorInnerError(InternalAzureOpenAIDalleErrorInnerErrorCode? code, string revisedPrompt, RequestImageContentFilterResult contentFilterResults, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Code = code;
            RevisedPrompt = revisedPrompt;
            ContentFilterResults = contentFilterResults;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The code associated with the inner error. </summary>
        public InternalAzureOpenAIDalleErrorInnerErrorCode? Code { get; set; }

        /// <summary> If applicable, the modified prompt used for generation. </summary>
        public string RevisedPrompt { get; set; }

        /// <summary> The content filter result details associated with the inner error. </summary>
        public RequestImageContentFilterResult ContentFilterResults { get; set; }

        /// <summary></summary>
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
