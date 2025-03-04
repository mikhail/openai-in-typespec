// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.AI.OpenAI;

namespace Azure.AI.OpenAI.Chat
{
    internal partial class InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions : DataSourceAuthentication
    {
        public InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions(string key, string keyId) : base("key_and_key_id")
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(keyId, nameof(keyId));

            Key = key;
            KeyId = keyId;
        }

        internal InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions(string @type, IDictionary<string, BinaryData> additionalBinaryDataProperties, string key, string keyId) : base(@type, additionalBinaryDataProperties)
        {
            Key = key;
            KeyId = keyId;
        }

        public string Key { get; set; }

        public string KeyId { get; set; }
    }
}
