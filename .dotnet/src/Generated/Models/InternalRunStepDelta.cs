// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalRunStepDelta
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalRunStepDelta(string id, InternalRunStepDeltaObjectDelta delta)
        {
            Id = id;
            Delta = delta;
        }

        internal InternalRunStepDelta(string id, InternalRunStepDeltaObjectDelta delta, object @object, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Id = id;
            Delta = delta;
            Object = @object;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Id { get; }

        public InternalRunStepDeltaObjectDelta Delta { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
