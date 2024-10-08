// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.VectorStores;

namespace OpenAI.Assistants
{
    public partial class VectorStoreCreationHelper
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        public VectorStoreCreationHelper()
        {
            FileIds = new ChangeTrackingList<string>();
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        internal VectorStoreCreationHelper(IList<string> fileIds, FileChunkingStrategy chunkingStrategy, IDictionary<string, string> metadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            FileIds = fileIds;
            ChunkingStrategy = chunkingStrategy;
            Metadata = metadata;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public IList<string> FileIds { get; }
        public IDictionary<string, string> Metadata { get; }
    }
}
