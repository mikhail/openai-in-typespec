// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    public partial class JobError
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal JobError(string code, string message, string invalidParameter)
        {
            Argument.AssertNotNull(code, nameof(code));
            Argument.AssertNotNull(message, nameof(message));

            Code = code;
            Message = message;
            InvalidParameter = invalidParameter;
        }

        internal JobError(string code, string message, string invalidParameter, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Code = code;
            Message = message;
            InvalidParameter = invalidParameter;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal JobError()
        {
        }

        public string Code { get; }
        public string Message { get; }
    }
}