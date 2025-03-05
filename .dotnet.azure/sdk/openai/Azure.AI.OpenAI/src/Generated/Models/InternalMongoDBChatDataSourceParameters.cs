// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.AI.OpenAI;

namespace Azure.AI.OpenAI.Chat
{
    internal partial class InternalMongoDBChatDataSourceParameters
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public InternalMongoDBChatDataSourceParameters(string endpoint, string databaseName, string collectionName, string appName, string indexName, DataSourceFieldMappings fieldMappings, DataSourceAuthentication authentication, DataSourceVectorizer embeddingDependency)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(databaseName, nameof(databaseName));
            Argument.AssertNotNull(collectionName, nameof(collectionName));
            Argument.AssertNotNull(appName, nameof(appName));
            Argument.AssertNotNull(indexName, nameof(indexName));
            Argument.AssertNotNull(fieldMappings, nameof(fieldMappings));
            Argument.AssertNotNull(authentication, nameof(authentication));
            Argument.AssertNotNull(embeddingDependency, nameof(embeddingDependency));

            Endpoint = endpoint;
            DatabaseName = databaseName;
            CollectionName = collectionName;
            AppName = appName;
            IndexName = indexName;
            FieldMappings = fieldMappings;
            Authentication = authentication;
            EmbeddingDependency = embeddingDependency;
            _internalIncludeContexts = new ChangeTrackingList<string>();
        }

        internal InternalMongoDBChatDataSourceParameters(int? topNDocuments, bool? inScope, int? strictness, int? maxSearchQueries, bool? allowPartialResult, string endpoint, string databaseName, string collectionName, string appName, string indexName, DataSourceFieldMappings fieldMappings, DataSourceAuthentication authentication, DataSourceVectorizer embeddingDependency, IList<string> internalIncludeContexts, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            TopNDocuments = topNDocuments;
            InScope = inScope;
            Strictness = strictness;
            MaxSearchQueries = maxSearchQueries;
            AllowPartialResult = allowPartialResult;
            Endpoint = endpoint;
            DatabaseName = databaseName;
            CollectionName = collectionName;
            AppName = appName;
            IndexName = indexName;
            FieldMappings = fieldMappings;
            Authentication = authentication;
            EmbeddingDependency = embeddingDependency;
            _internalIncludeContexts = internalIncludeContexts;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The configured number of documents to feature in the query. </summary>
        public int? TopNDocuments { get; set; }

        /// <summary> Whether queries should be restricted to use of the indexed data. </summary>
        public bool? InScope { get; set; }

        /// <summary>
        /// The configured strictness of the search relevance filtering.
        /// Higher strictness will increase precision but lower recall of the answer.
        /// </summary>
        public int? Strictness { get; set; }

        /// <summary>
        /// The maximum number of rewritten queries that should be sent to the search provider for a single user message.
        /// By default, the system will make an automatic determination.
        /// </summary>
        public int? MaxSearchQueries { get; set; }

        /// <summary>
        /// If set to true, the system will allow partial search results to be used and the request will fail if all
        /// partial queries fail. If not specified or specified as false, the request will fail if any search query fails.
        /// </summary>
        public bool? AllowPartialResult { get; set; }

        /// <summary> The name of the MongoDB cluster endpoint. </summary>
        public string Endpoint { get; set; }

        /// <summary> The name of the MongoDB database. </summary>
        public string DatabaseName { get; set; }

        /// <summary> The name of the MongoDB collection. </summary>
        public string CollectionName { get; set; }

        /// <summary> The name of the MongoDB application. </summary>
        public string AppName { get; set; }

        /// <summary> The name of the MongoDB index. </summary>
        public string IndexName { get; set; }

        /// <summary></summary>
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
