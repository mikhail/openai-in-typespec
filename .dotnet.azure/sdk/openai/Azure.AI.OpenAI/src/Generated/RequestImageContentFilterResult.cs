// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    /// <summary> A content filter result for an image generation operation's input request content. </summary>
    public partial class RequestImageContentFilterResult : ResponseImageContentFilterResult
    {
        /// <summary> Initializes a new instance of <see cref="RequestImageContentFilterResult"/>. </summary>
        /// <param name="jailbreak">
        /// A detection result that describes user prompt injection attacks, where malicious users deliberately exploit
        /// system vulnerabilities to elicit unauthorized behavior from the LLM. This could lead to inappropriate content
        /// generation or violations of system-imposed restrictions.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jailbreak"/> is null. </exception>
        internal RequestImageContentFilterResult(ContentFilterDetectionResult jailbreak)
        {
            Argument.AssertNotNull(jailbreak, nameof(jailbreak));

            Jailbreak = jailbreak;
        }

        /// <summary> Initializes a new instance of <see cref="RequestImageContentFilterResult"/>. </summary>
        /// <param name="sexual">
        /// A content filter category for language related to anatomical organs and genitals, romantic relationships, acts
        /// portrayed in erotic or affectionate terms, pregnancy, physical sexual acts, including those portrayed as an
        /// assault or a forced sexual violent act against one's will, prostitution, pornography, and abuse.
        /// </param>
        /// <param name="violence">
        /// A content filter category for language related to physical actions intended to hurt, injure, damage, or kill
        /// someone or something; describes weapons, guns and related entities, such as manufactures, associations,
        /// legislation, and so on.
        /// </param>
        /// <param name="hate">
        /// A content filter category that can refer to any content that attacks or uses pejorative or discriminatory
        /// language with reference to a person or identity group based on certain differentiating attributes of these groups
        /// including but not limited to race, ethnicity, nationality, gender identity and expression, sexual orientation,
        /// religion, immigration status, ability status, personal appearance, and body size.
        /// </param>
        /// <param name="selfHarm">
        /// A content filter category that describes language related to physical actions intended to purposely hurt, injure,
        /// damage one's body or kill oneself.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="profanity">
        /// A detection result that identifies whether crude, vulgar, or otherwise objection language is present in the
        /// content.
        /// </param>
        /// <param name="customBlocklists"> A collection of binary filtering outcomes for configured custom blocklists. </param>
        /// <param name="jailbreak">
        /// A detection result that describes user prompt injection attacks, where malicious users deliberately exploit
        /// system vulnerabilities to elicit unauthorized behavior from the LLM. This could lead to inappropriate content
        /// generation or violations of system-imposed restrictions.
        /// </param>
        internal RequestImageContentFilterResult(ContentFilterSeverityResult sexual, ContentFilterSeverityResult violence, ContentFilterSeverityResult hate, ContentFilterSeverityResult selfHarm, IDictionary<string, BinaryData> serializedAdditionalRawData, ContentFilterDetectionResult profanity, ContentFilterBlocklistResult customBlocklists, ContentFilterDetectionResult jailbreak) : base(sexual, violence, hate, selfHarm, serializedAdditionalRawData)
        {
            Profanity = profanity;
            CustomBlocklists = customBlocklists;
            Jailbreak = jailbreak;
        }

        /// <summary> Initializes a new instance of <see cref="RequestImageContentFilterResult"/> for deserialization. </summary>
        internal RequestImageContentFilterResult()
        {
        }

        /// <summary>
        /// A detection result that identifies whether crude, vulgar, or otherwise objection language is present in the
        /// content.
        /// </summary>
        public ContentFilterDetectionResult Profanity { get; }
        /// <summary> A collection of binary filtering outcomes for configured custom blocklists. </summary>
        public ContentFilterBlocklistResult CustomBlocklists { get; }
        /// <summary>
        /// A detection result that describes user prompt injection attacks, where malicious users deliberately exploit
        /// system vulnerabilities to elicit unauthorized behavior from the LLM. This could lead to inappropriate content
        /// generation or violations of system-imposed restrictions.
        /// </summary>
        public ContentFilterDetectionResult Jailbreak { get; }
    }
}