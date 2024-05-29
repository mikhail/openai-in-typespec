// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalRunStepFileSearchToolCallDetails : RunStepToolCall
    {
        internal InternalRunStepFileSearchToolCallDetails(string id, IReadOnlyDictionary<string, string> fileSearch)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(fileSearch, nameof(fileSearch));

            Type = "file_search";
            Id = id;
            FileSearch = fileSearch;
        }

        internal InternalRunStepFileSearchToolCallDetails(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, string id, IReadOnlyDictionary<string, string> fileSearch) : base(type, serializedAdditionalRawData)
        {
            Id = id;
            FileSearch = fileSearch;
        }

        internal InternalRunStepFileSearchToolCallDetails()
        {
        }

        public string Id { get; }
        public IReadOnlyDictionary<string, string> FileSearch { get; }
    }
}