// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Assistants
{
    public readonly partial struct AssistantCollectionOrder : IEquatable<AssistantCollectionOrder>
    {
        private readonly string _value;

        public AssistantCollectionOrder(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AscendingValue = "asc";
        private const string DescendingValue = "desc";
        public static bool operator ==(AssistantCollectionOrder left, AssistantCollectionOrder right) => left.Equals(right);
        public static bool operator !=(AssistantCollectionOrder left, AssistantCollectionOrder right) => !left.Equals(right);
        public static implicit operator AssistantCollectionOrder(string value) => new AssistantCollectionOrder(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AssistantCollectionOrder other && Equals(other);
        public bool Equals(AssistantCollectionOrder other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}