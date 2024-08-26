// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Models;

namespace OpenAI.FineTuning
{
    public partial class FineTuningJobEventsList
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal FineTuningJobEventsList(IEnumerable<FineTuningJobEvent> data)
        {
            Argument.AssertNotNull(data, nameof(data));

            Data = data;
        }

        internal FineTuningJobEventsList(IEnumerable<FineTuningJobEvent> data, string @object, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Data = data;
            _object = @object;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal FineTuningJobEventsList()
        {
        }
    }
}
