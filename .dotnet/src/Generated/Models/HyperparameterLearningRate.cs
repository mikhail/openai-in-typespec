// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.FineTuning
{
    public readonly partial struct HyperparameterLearningRate : IEquatable<HyperparameterLearningRate>
    {
        private readonly string _value;

        private const string AutoValue = "auto";

        public static HyperparameterLearningRate Auto { get; } = new HyperparameterLearningRate(AutoValue);
        public static bool operator ==(HyperparameterLearningRate left, HyperparameterLearningRate right) => left.Equals(right);
        public static bool operator !=(HyperparameterLearningRate left, HyperparameterLearningRate right) => !left.Equals(right);
        public static implicit operator HyperparameterLearningRate(string value) => new HyperparameterLearningRate(value);
        public bool Equals(HyperparameterLearningRate other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}
