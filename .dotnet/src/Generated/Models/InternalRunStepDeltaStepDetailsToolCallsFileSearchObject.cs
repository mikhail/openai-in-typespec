// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalRunStepDeltaStepDetailsToolCallsFileSearchObject : InternalRunStepDeltaStepDetailsToolCallsObjectToolCallsObject
    {
        internal InternalRunStepDeltaStepDetailsToolCallsFileSearchObject(int index, InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch fileSearch)
        {
            Argument.AssertNotNull(fileSearch, nameof(fileSearch));

            Type = "file_search";
            Index = index;
            FileSearch = fileSearch;
        }

        internal InternalRunStepDeltaStepDetailsToolCallsFileSearchObject(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, int index, string id, InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch fileSearch) : base(type, serializedAdditionalRawData)
        {
            Index = index;
            Id = id;
            FileSearch = fileSearch;
        }

        internal InternalRunStepDeltaStepDetailsToolCallsFileSearchObject()
        {
        }

        public int Index { get; }
        public string Id { get; }
        public InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch FileSearch { get; }
    }
}
