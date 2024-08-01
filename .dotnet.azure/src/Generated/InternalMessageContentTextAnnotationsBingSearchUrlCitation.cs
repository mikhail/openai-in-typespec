// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Assistants
{
    /// <summary> The MessageContentTextAnnotationsBingSearchUrlCitation. </summary>
    internal partial class InternalMessageContentTextAnnotationsBingSearchUrlCitation : MessageContentTextObjectAnnotation
    {
        /// <summary> Initializes a new instance of <see cref="InternalMessageContentTextAnnotationsBingSearchUrlCitation"/>. </summary>
        /// <param name="text"> The text in the message content that needs to be replaced. </param>
        /// <param name="urlCitation"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="urlCitation"/> is null. </exception>
        internal InternalMessageContentTextAnnotationsBingSearchUrlCitation(string text, InternalMessageContentTextAnnotationsBingSearchUrlCitationUrlCitation urlCitation, int startIndex, int endIndex)
        {
            Argument.AssertNotNull(text, nameof(text));
            Argument.AssertNotNull(urlCitation, nameof(urlCitation));

            Type = "url_citation";
            Text = text;
            UrlCitation = urlCitation;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        /// <summary> Initializes a new instance of <see cref="InternalMessageContentTextAnnotationsBingSearchUrlCitation"/>. </summary>
        /// <param name="type"> The discriminated type identifier for the content item. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="text"> The text in the message content that needs to be replaced. </param>
        /// <param name="urlCitation"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        internal InternalMessageContentTextAnnotationsBingSearchUrlCitation(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, string text, InternalMessageContentTextAnnotationsBingSearchUrlCitationUrlCitation urlCitation, int startIndex, int endIndex) : base(type, serializedAdditionalRawData)
        {
            Text = text;
            UrlCitation = urlCitation;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        /// <summary> Initializes a new instance of <see cref="InternalMessageContentTextAnnotationsBingSearchUrlCitation"/> for deserialization. </summary>
        internal InternalMessageContentTextAnnotationsBingSearchUrlCitation()
        {
        }

        /// <summary> The text in the message content that needs to be replaced. </summary>
        internal string Text { get; set; }
        /// <summary> Gets the url citation. </summary>
        internal InternalMessageContentTextAnnotationsBingSearchUrlCitationUrlCitation UrlCitation { get; set; }
        /// <summary> Gets the start index. </summary>
        internal int StartIndex { get; set; }
        /// <summary> Gets the end index. </summary>
        internal int EndIndex { get; set; }
    }
}
