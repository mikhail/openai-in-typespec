// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Models
{
    public readonly partial struct ListFineTuningJobEventsResponseObject : IEquatable<ListFineTuningJobEventsResponseObject>
    {
        private readonly string _value;

        public ListFineTuningJobEventsResponseObject(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ListValue = "list";

        public static ListFineTuningJobEventsResponseObject List { get; } = new ListFineTuningJobEventsResponseObject(ListValue);
        public static bool operator ==(ListFineTuningJobEventsResponseObject left, ListFineTuningJobEventsResponseObject right) => left.Equals(right);
        public static bool operator !=(ListFineTuningJobEventsResponseObject left, ListFineTuningJobEventsResponseObject right) => !left.Equals(right);
        public static implicit operator ListFineTuningJobEventsResponseObject(string value) => new ListFineTuningJobEventsResponseObject(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ListFineTuningJobEventsResponseObject other && Equals(other);
        public bool Equals(ListFineTuningJobEventsResponseObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}
