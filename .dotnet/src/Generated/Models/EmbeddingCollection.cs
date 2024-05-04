// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OpenAI.Embeddings
{
    /// <summary> The CreateEmbeddingResponse. </summary>
    public partial class EmbeddingCollection : ReadOnlyCollection<Embedding>
    {
        /// <summary> The name of the model used to generate the embedding. </summary>
        public string Model { get; }

        /// <summary> The usage information for the request. </summary>
        public EmbeddingTokenUsage Usage { get; }
    }
}