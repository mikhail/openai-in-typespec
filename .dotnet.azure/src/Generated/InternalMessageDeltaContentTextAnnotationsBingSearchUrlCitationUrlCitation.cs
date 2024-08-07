// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Assistants
{
    /// <summary> The MessageDeltaContentTextAnnotationsBingSearchUrlCitationUrlCitation. </summary>
    internal partial class InternalMessageDeltaContentTextAnnotationsBingSearchUrlCitationUrlCitation
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        /// <summary> Initializes a new instance of <see cref="InternalMessageDeltaContentTextAnnotationsBingSearchUrlCitationUrlCitation"/>. </summary>
        internal InternalMessageDeltaContentTextAnnotationsBingSearchUrlCitationUrlCitation()
        {
        }

        /// <summary> Initializes a new instance of <see cref="InternalMessageDeltaContentTextAnnotationsBingSearchUrlCitationUrlCitation"/>. </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalMessageDeltaContentTextAnnotationsBingSearchUrlCitationUrlCitation(Uri url, string title, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Url = url;
            Title = title;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the url. </summary>
        internal Uri Url { get; set; }
        /// <summary> Gets the title. </summary>
        internal string Title { get; set; }
    }
}

