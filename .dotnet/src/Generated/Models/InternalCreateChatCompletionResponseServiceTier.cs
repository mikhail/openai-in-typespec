// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using OpenAI;

namespace OpenAI.Chat
{
    internal readonly partial struct InternalCreateChatCompletionResponseServiceTier : IEquatable<InternalCreateChatCompletionResponseServiceTier>
    {
        private readonly string _value;
        private const string ScaleValue = "scale";
        private const string DefaultValue = "default";

        public InternalCreateChatCompletionResponseServiceTier(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        public static InternalCreateChatCompletionResponseServiceTier Scale { get; } = new InternalCreateChatCompletionResponseServiceTier(ScaleValue);

        public static InternalCreateChatCompletionResponseServiceTier Default { get; } = new InternalCreateChatCompletionResponseServiceTier(DefaultValue);

        public static bool operator ==(InternalCreateChatCompletionResponseServiceTier left, InternalCreateChatCompletionResponseServiceTier right) => left.Equals(right);

        public static bool operator !=(InternalCreateChatCompletionResponseServiceTier left, InternalCreateChatCompletionResponseServiceTier right) => !left.Equals(right);

        public static implicit operator InternalCreateChatCompletionResponseServiceTier(string value) => new InternalCreateChatCompletionResponseServiceTier(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalCreateChatCompletionResponseServiceTier other && Equals(other);

        public bool Equals(InternalCreateChatCompletionResponseServiceTier other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        public override string ToString() => _value;
    }
}
