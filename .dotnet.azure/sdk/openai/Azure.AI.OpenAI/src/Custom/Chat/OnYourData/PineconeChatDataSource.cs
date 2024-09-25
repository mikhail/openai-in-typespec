// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("PineconeChatDataSource")]
public partial class PineconeChatDataSource : AzureChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalPineconeChatDataSourceParameters InternalParameters { get; }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.Environment"/>
    required public string Environment
    {
        get => InternalParameters.Environment;
        set => InternalParameters.Environment = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.IndexName"/>
    required public string IndexName
    {
        get => InternalParameters.IndexName;
        set => InternalParameters.IndexName = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.Authentication"/>
    required public DataSourceAuthentication Authentication
    {
        get => InternalParameters.Authentication;
        set => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.VectorizationSource"/>
    required public DataSourceVectorizer VectorizationSource
    {
        get => InternalParameters.VectorizationSource;
        set => InternalParameters.VectorizationSource = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.FieldMappings"/>
    required public DataSourceFieldMappings FieldMappings
    {
        get => InternalParameters.FieldMappings;
        set => InternalParameters.FieldMappings = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.TopNDocuments"/>
    public int? TopNDocuments
    {
        get => InternalParameters.TopNDocuments;
        set => InternalParameters.TopNDocuments = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.InScope"/>
    public bool? InScope
    {
        get => InternalParameters.InScope;
        set => InternalParameters.InScope = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.Strictness"/>
    public int? Strictness
    {
        get => InternalParameters.Strictness;
        set => InternalParameters.Strictness = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.MaxSearchQueries"/>
    public int? MaxSearchQueries
    {
        get => InternalParameters.MaxSearchQueries;
        set => InternalParameters.MaxSearchQueries = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.AllowPartialResult"/>
    public bool? AllowPartialResult
    {
        get => InternalParameters.AllowPartialResult;
        set => InternalParameters.AllowPartialResult = value;
    }

    /// <inheritdoc cref="InternalPineconeChatDataSourceParameters.OutputContextFlags"/>
    public DataSourceOutputContexts? OutputContextFlags
    {
        get => InternalParameters.OutputContextFlags;
        set => InternalParameters.OutputContextFlags = value;
    }

    public PineconeChatDataSource() : base(type: "pinecone", serializedAdditionalRawData: null)
    {
        InternalParameters = new();
    }

    // CUSTOM: Made internal.
    /// <summary> Initializes a new instance of <see cref="PineconeChatDataSource"/>. </summary>
    /// <param name="internalParameters"> The parameter information to control the use of the Pinecone data source. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalParameters"/> is null. </exception>
    internal PineconeChatDataSource(InternalPineconeChatDataSourceParameters internalParameters) : this()
    {
        Argument.AssertNotNull(internalParameters, nameof(internalParameters));
        InternalParameters = internalParameters;
    }

    /// <summary> Initializes a new instance of <see cref="PineconeChatDataSource"/>. </summary>
    /// <param name="type"></param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    /// <param name="internalParameters"> The parameter information to control the use of the Azure Search data source. </param>
    [SetsRequiredMembers]
    internal PineconeChatDataSource(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalPineconeChatDataSourceParameters internalParameters)
        : base(type, serializedAdditionalRawData)
    {
        InternalParameters = internalParameters;
    }
}