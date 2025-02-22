// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalRunToolCallObjectFunction
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalRunToolCallObjectFunction(string name, string arguments)
        {
            Name = name;
            Arguments = arguments;
        }

        internal InternalRunToolCallObjectFunction(string name, string arguments, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Name = name;
            Arguments = arguments;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Name { get; }

        public string Arguments { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
