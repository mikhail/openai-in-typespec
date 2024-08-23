// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Models
{
    public readonly partial struct CreateFineTuningJobRequestModel : IEquatable<CreateFineTuningJobRequestModel>
    {
        private readonly string _value;

        public CreateFineTuningJobRequestModel(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Babbage002Value = "babbage-002";
        private const string Davinci002Value = "davinci-002";
        private const string Gpt35TurboValue = "gpt-3.5-turbo";
        private const string Gpt4oMiniValue = "gpt-4o-mini";

        public static CreateFineTuningJobRequestModel Babbage002 { get; } = new CreateFineTuningJobRequestModel(Babbage002Value);
        public static CreateFineTuningJobRequestModel Davinci002 { get; } = new CreateFineTuningJobRequestModel(Davinci002Value);
        public static CreateFineTuningJobRequestModel Gpt35Turbo { get; } = new CreateFineTuningJobRequestModel(Gpt35TurboValue);
        public static CreateFineTuningJobRequestModel Gpt4oMini { get; } = new CreateFineTuningJobRequestModel(Gpt4oMiniValue);
        public static bool operator ==(CreateFineTuningJobRequestModel left, CreateFineTuningJobRequestModel right) => left.Equals(right);
        public static bool operator !=(CreateFineTuningJobRequestModel left, CreateFineTuningJobRequestModel right) => !left.Equals(right);
        public static implicit operator CreateFineTuningJobRequestModel(string value) => new CreateFineTuningJobRequestModel(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateFineTuningJobRequestModel other && Equals(other);
        public bool Equals(CreateFineTuningJobRequestModel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}