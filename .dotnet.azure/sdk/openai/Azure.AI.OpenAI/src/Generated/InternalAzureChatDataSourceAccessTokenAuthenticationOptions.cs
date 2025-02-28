// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary> The AzureChatDataSourceAccessTokenAuthenticationOptions. </summary>
    internal partial class InternalAzureChatDataSourceAccessTokenAuthenticationOptions : DataSourceAuthentication
    {
        /// <summary> Initializes a new instance of <see cref="InternalAzureChatDataSourceAccessTokenAuthenticationOptions"/>. </summary>
        /// <param name="accessToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="accessToken"/> is null. </exception>
        public InternalAzureChatDataSourceAccessTokenAuthenticationOptions(string accessToken)
        {
            Argument.AssertNotNull(accessToken, nameof(accessToken));

            Type = "access_token";
            AccessToken = accessToken;
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureChatDataSourceAccessTokenAuthenticationOptions"/>. </summary>
        /// <param name="type"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="accessToken"></param>
        internal InternalAzureChatDataSourceAccessTokenAuthenticationOptions(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, string accessToken) : base(type, serializedAdditionalRawData)
        {
            AccessToken = accessToken;
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureChatDataSourceAccessTokenAuthenticationOptions"/> for deserialization. </summary>
        internal InternalAzureChatDataSourceAccessTokenAuthenticationOptions()
        {
        }

        /// <summary> Gets the access token. </summary>
        internal string AccessToken { get; set; }
    }
}
