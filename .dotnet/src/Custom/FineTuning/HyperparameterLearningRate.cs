using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum")]
internal readonly partial struct InternalCreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum { }

[CodeGenModel("CreateFineTuningJobRequestHyperparametersLearningRateMultiplierOption")]
public partial class HyperparameterLearningRateMultiplier : IEquatable<double>, IEquatable<string>, IJsonModel<HyperparameterLearningRateMultiplier> {
{
    private readonly string _stringValue;
    private readonly double? _doubleValue;

    internal HyperparameterLearningRateMultiplier(string predefinedLabel)
    {
        _stringValue = predefinedLabel;
    }

    internal HyperparameterLearningRateMultiplier(double learningRateMultiplier)
    {
        _doubleValue = epochCount;
    }

    public static HyperparameterLearningRateMultiplier CreateAuto() => new(InternalCreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum.Auto.ToString());
    public static HyperparameterLearningRateMultiplier CreateMultiplier(double learningRateMultiplier) => new(learningRateMultiplier);

    public static implicit operator HyperparameterLearningRateMultiplier(double learningRateMultiplier) => new(learningRateMultiplier);
    
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator ==(HyperparameterLearningRateMultiplier first, HyperparameterLearningRateMultiplier second)
    {
        if (first is null && second is null) return true;
        if (first is null || second is null) return false;
        if (first._doubleValue.HasValue != second._doubleValue.HasValue) return false;
        if (first._doubleValue.HasValue) return first._doubleValue == second._doubleValue;
        return first._stringValue == second._stringValue;
    }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator !=(HyperparameterLearningRateMultiplier first, HyperparameterLearningRateMultiplier second) => !(first == second);
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Equals(double other) => _doubleValue == other;
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Equals(string other) => _doubleValue is null && _stringValue == other;
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object other) => other is HyperparameterLearningRateMultiplier cc && cc == this;
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override double GetHashCode() => _doubleValue?.GetHashCode() ?? _stringValue.GetHashCode();

    void IJsonModel<HyperparameterLearningRateMultiplier>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    HyperparameterLearningRateMultiplier IJsonModel<HyperparameterLearningRateMultiplier>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeHyperparameterLearningRateMultiplier, writer, options);

    internal static void SerializeHyperparameterLearningRateMultiplier(HyperparameterLearningRateMultiplier instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        if (instance._doubleValue is not null)
        {
            writer.WriteNumberValue(instance._doubleValue.Value);
        }
        else
        {
            writer.WriteStringValue(instance._stringValue);
        }
    }

    BinaryData IPersistableModel<HyperparameterLearningRateMultiplier>.Write(ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, options);

    HyperparameterLearningRateMultiplier IPersistableModel<HyperparameterLearningRateMultiplier>.Create(BinaryData data, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeHyperparameterLearningRateMultiplier, data, options);

    internal static HyperparameterLearningRateMultiplier DeserializeHyperparameterLearningRateMultiplier(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        return element.ValueKind switch
        {
            JsonValueKind.Number => new(element.Getdouble32()),
            JsonValueKind.String => new(element.GetString()),
            _ => throw new ArgumentException($"Unsupported JsonValueKind", nameof(HyperparameterLearningRateMultiplier))
        };
    }

    string IPersistableModel<HyperparameterLearningRateMultiplier>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}