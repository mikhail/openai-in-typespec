// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Assistants
{
    internal readonly partial struct InternalCreateThreadAndRunRequestModel : IEquatable<InternalCreateThreadAndRunRequestModel>
    {
        private readonly string _value;

        public InternalCreateThreadAndRunRequestModel(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Gpt4oValue = "gpt-4o";
        private const string Gpt4o20240806Value = "gpt-4o-2024-08-06";
        private const string Gpt4o20240513Value = "gpt-4o-2024-05-13";
        private const string Gpt4oMiniValue = "gpt-4o-mini";
        private const string Gpt4oMini20240718Value = "gpt-4o-mini-2024-07-18";
        private const string Gpt4TurboValue = "gpt-4-turbo";
        private const string Gpt4Turbo20240409Value = "gpt-4-turbo-2024-04-09";
        private const string Gpt40125PreviewValue = "gpt-4-0125-preview";
        private const string Gpt4TurboPreviewValue = "gpt-4-turbo-preview";
        private const string Gpt41106PreviewValue = "gpt-4-1106-preview";
        private const string Gpt4VisionPreviewValue = "gpt-4-vision-preview";
        private const string Gpt4Value = "gpt-4";
        private const string Gpt40314Value = "gpt-4-0314";
        private const string Gpt40613Value = "gpt-4-0613";
        private const string Gpt432kValue = "gpt-4-32k";
        private const string Gpt432k0314Value = "gpt-4-32k-0314";
        private const string Gpt432k0613Value = "gpt-4-32k-0613";
        private const string Gpt35TurboValue = "gpt-3.5-turbo";
        private const string Gpt35Turbo16kValue = "gpt-3.5-turbo-16k";
        private const string Gpt35Turbo0613Value = "gpt-3.5-turbo-0613";
        private const string Gpt35Turbo1106Value = "gpt-3.5-turbo-1106";
        private const string Gpt35Turbo0125Value = "gpt-3.5-turbo-0125";
        private const string Gpt35Turbo16k0613Value = "gpt-3.5-turbo-16k-0613";

        public static InternalCreateThreadAndRunRequestModel Gpt4o { get; } = new InternalCreateThreadAndRunRequestModel(Gpt4oValue);
        public static InternalCreateThreadAndRunRequestModel Gpt4o20240806 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt4o20240806Value);
        public static InternalCreateThreadAndRunRequestModel Gpt4o20240513 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt4o20240513Value);
        public static InternalCreateThreadAndRunRequestModel Gpt4oMini { get; } = new InternalCreateThreadAndRunRequestModel(Gpt4oMiniValue);
        public static InternalCreateThreadAndRunRequestModel Gpt4oMini20240718 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt4oMini20240718Value);
        public static InternalCreateThreadAndRunRequestModel Gpt4Turbo { get; } = new InternalCreateThreadAndRunRequestModel(Gpt4TurboValue);
        public static InternalCreateThreadAndRunRequestModel Gpt4Turbo20240409 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt4Turbo20240409Value);
        public static InternalCreateThreadAndRunRequestModel Gpt40125Preview { get; } = new InternalCreateThreadAndRunRequestModel(Gpt40125PreviewValue);
        public static InternalCreateThreadAndRunRequestModel Gpt4TurboPreview { get; } = new InternalCreateThreadAndRunRequestModel(Gpt4TurboPreviewValue);
        public static InternalCreateThreadAndRunRequestModel Gpt41106Preview { get; } = new InternalCreateThreadAndRunRequestModel(Gpt41106PreviewValue);
        public static InternalCreateThreadAndRunRequestModel Gpt4VisionPreview { get; } = new InternalCreateThreadAndRunRequestModel(Gpt4VisionPreviewValue);
        public static InternalCreateThreadAndRunRequestModel Gpt4 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt4Value);
        public static InternalCreateThreadAndRunRequestModel Gpt40314 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt40314Value);
        public static InternalCreateThreadAndRunRequestModel Gpt40613 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt40613Value);
        public static InternalCreateThreadAndRunRequestModel Gpt432k { get; } = new InternalCreateThreadAndRunRequestModel(Gpt432kValue);
        public static InternalCreateThreadAndRunRequestModel Gpt432k0314 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt432k0314Value);
        public static InternalCreateThreadAndRunRequestModel Gpt432k0613 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt432k0613Value);
        public static InternalCreateThreadAndRunRequestModel Gpt35Turbo { get; } = new InternalCreateThreadAndRunRequestModel(Gpt35TurboValue);
        public static InternalCreateThreadAndRunRequestModel Gpt35Turbo16k { get; } = new InternalCreateThreadAndRunRequestModel(Gpt35Turbo16kValue);
        public static InternalCreateThreadAndRunRequestModel Gpt35Turbo0613 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt35Turbo0613Value);
        public static InternalCreateThreadAndRunRequestModel Gpt35Turbo1106 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt35Turbo1106Value);
        public static InternalCreateThreadAndRunRequestModel Gpt35Turbo0125 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt35Turbo0125Value);
        public static InternalCreateThreadAndRunRequestModel Gpt35Turbo16k0613 { get; } = new InternalCreateThreadAndRunRequestModel(Gpt35Turbo16k0613Value);
        public static bool operator ==(InternalCreateThreadAndRunRequestModel left, InternalCreateThreadAndRunRequestModel right) => left.Equals(right);
        public static bool operator !=(InternalCreateThreadAndRunRequestModel left, InternalCreateThreadAndRunRequestModel right) => !left.Equals(right);
        public static implicit operator InternalCreateThreadAndRunRequestModel(string value) => new InternalCreateThreadAndRunRequestModel(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalCreateThreadAndRunRequestModel other && Equals(other);
        public bool Equals(InternalCreateThreadAndRunRequestModel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}
