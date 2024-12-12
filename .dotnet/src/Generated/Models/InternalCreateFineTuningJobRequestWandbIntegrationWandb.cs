// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.FineTuning
{
    internal partial class InternalCreateFineTuningJobRequestWandbIntegrationWandb
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public InternalCreateFineTuningJobRequestWandbIntegrationWandb(string project)
        {
            Argument.AssertNotNull(project, nameof(project));

            Tags = new ChangeTrackingList<string>();
            Project = project;
        }

        internal InternalCreateFineTuningJobRequestWandbIntegrationWandb(string name, string entity, IList<string> tags, string project, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Name = name;
            Entity = entity;
            Tags = tags;
            Project = project;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Name { get; set; }

        public string Entity { get; set; }

        public IList<string> Tags { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
