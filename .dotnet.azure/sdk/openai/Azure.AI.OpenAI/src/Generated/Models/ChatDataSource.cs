// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary>
    /// A representation of configuration data for a single Azure OpenAI chat data source.
    /// This will be used by a chat completions request that should use Azure OpenAI chat extensions to augment the
    /// response behavior.
    /// The use of this configuration is compatible only with Azure OpenAI.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="AzureSearchChatDataSource"/>, <see cref="CosmosChatDataSource"/>, <see cref="ElasticsearchChatDataSource"/>, <see cref="PineconeChatDataSource"/>, and <see cref="MongoDBChatDataSource"/>.
    /// </summary>
    public abstract partial class ChatDataSource
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        private protected ChatDataSource(string @type)
        {
            Type = @type;
        }

        internal ChatDataSource(string @type, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Type = @type;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The differentiating type identifier for the data source. </summary>
        internal string Type { get; set; }

        /// <summary></summary>
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
