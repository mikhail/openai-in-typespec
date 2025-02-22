// <auto-generated/>

#nullable disable

using System;

namespace OpenAI.Assistants
{
    internal static partial class RunStepFileSearchResultContentKindExtensions
    {
        public static string ToSerialString(this Assistants.RunStepFileSearchResultContentKind value) => value switch
        {
            Assistants.RunStepFileSearchResultContentKind.Text => "text",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RunStepFileSearchResultContentKind value.")
        };

        public static Assistants.RunStepFileSearchResultContentKind ToRunStepFileSearchResultContentKind(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "text"))
            {
                return Assistants.RunStepFileSearchResultContentKind.Text;
            }
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RunStepFileSearchResultContentKind value.");
        }
    }
}
