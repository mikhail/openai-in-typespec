// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary> The DataSourceFieldMappings. </summary>
    public partial class DataSourceFieldMappings
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal DataSourceFieldMappings(string titleFieldName, string urlFieldName, string filePathFieldName, IList<string> contentFieldNames, string contentFieldSeparator, IList<string> vectorFieldNames, IList<string> imageVectorFieldNames, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            TitleFieldName = titleFieldName;
            UrlFieldName = urlFieldName;
            FilePathFieldName = filePathFieldName;
            ContentFieldNames = contentFieldNames;
            ContentFieldSeparator = contentFieldSeparator;
            VectorFieldNames = vectorFieldNames;
            ImageVectorFieldNames = imageVectorFieldNames;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
