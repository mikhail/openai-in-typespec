// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;
using OpenAI.Internal;

namespace OpenAI.Chat
{
    internal partial class InternalChatResponseFormatJsonSchema : ChatResponseFormat
    {
        public InternalChatResponseFormatJsonSchema(InternalResponseFormatJsonSchemaJsonSchema jsonSchema) : base("json_schema")
        {
            Argument.AssertNotNull(jsonSchema, nameof(jsonSchema));

            JsonSchema = jsonSchema;
        }

        internal InternalChatResponseFormatJsonSchema(string @type, IDictionary<string, BinaryData> additionalBinaryDataProperties, InternalResponseFormatJsonSchemaJsonSchema jsonSchema) : base(@type, additionalBinaryDataProperties)
        {
            JsonSchema = jsonSchema;
        }

        public InternalResponseFormatJsonSchemaJsonSchema JsonSchema { get; }
    }
}
