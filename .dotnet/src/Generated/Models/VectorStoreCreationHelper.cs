// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;
using OpenAI.VectorStores;

namespace OpenAI.Assistants
{
    public partial class VectorStoreCreationHelper
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public VectorStoreCreationHelper()
        {
            FileIds = new ChangeTrackingList<string>();
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        internal VectorStoreCreationHelper(IList<string> fileIds, IDictionary<string, string> metadata, FileChunkingStrategy chunkingStrategy, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            FileIds = fileIds;
            Metadata = metadata;
            ChunkingStrategy = chunkingStrategy;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public IList<string> FileIds { get; }

        public IDictionary<string, string> Metadata { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
