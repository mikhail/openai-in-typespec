// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Files
{
    internal readonly partial struct InternalUploadObject : IEquatable<InternalUploadObject>
    {
        private readonly string _value;

        public InternalUploadObject(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UploadValue = "upload";

        public static InternalUploadObject Upload { get; } = new InternalUploadObject(UploadValue);
        public static bool operator ==(InternalUploadObject left, InternalUploadObject right) => left.Equals(right);
        public static bool operator !=(InternalUploadObject left, InternalUploadObject right) => !left.Equals(right);
        public static implicit operator InternalUploadObject(string value) => new InternalUploadObject(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalUploadObject other && Equals(other);
        public bool Equals(InternalUploadObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}
