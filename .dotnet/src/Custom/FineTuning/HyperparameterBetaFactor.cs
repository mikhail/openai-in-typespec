using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparametersBetaChoiceEnum")]
internal readonly partial struct InternalCreateFineTuningJobRequestHyperparametersBetaChoiceEnum { }

[CodeGenModel("CreateFineTuningJobRequestHyperparametersBetaOption")]
public partial class HyperparameterBetaFactor : IEquatable<double>, IEquatable<string>, IJsonModel<HyperparameterBeta> {
{
    private readonly string _stringValue;
    private readonly int? _intValue;

    internal HyperparameterBetaFactor(string predefinedLabel)
    {
        _stringValue = predefinedLabel;
    }

    internal HyperparameterBetaFactor(int beta)
    {
        _intValue = epochCount;
    }

    public static HyperparameterBetaFactor CreateAuto() => new(InternalCreateFineTuningJobRequestHyperparametersBetaChoiceEnum.Auto.ToString());
    public static HyperparameterBetaFactor CreateBeta(int beta) => new(beta);

    public static implicit operator HyperparameterBetaFactor(double beta) => new(beta);
    
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator ==(HyperparameterBetaFactor first, HyperparameterBetaFactor second)
    {
        if (first is null && second is null) return true;
        if (first is null || second is null) return false;
        if (first._intValue.HasValue != second._intValue.HasValue) return false;
        if (first._intValue.HasValue) return first._intValue == second._intValue;
        return first._stringValue == second._stringValue;
    }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator !=(HyperparameterBetaFactor first, HyperparameterBetaFactor second) => !(first == second);
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Equals(double other) => _intValue == other;
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Equals(string other) => _intValue is null && _stringValue == other;
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object other) => other is HyperparameterBetaFactor cc && cc == this;
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override double GetHashCode() => _intValue?.GetHashCode() ?? _stringValue.GetHashCode();

    void IJsonModel<HyperparameterBetaFactor>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    HyperparameterBetaFactor IJsonModel<HyperparameterBetaFactor>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeHyperparameterBeta, writer, options);

    internal static void SerializeHyperparameterBeta(HyperparameterBetaFactor instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        if (instance._intValue is not null)
        {
            writer.WriteNumberValue(instance._intValue.Value);
        }
        else
        {
            writer.WriteStringValue(instance._stringValue);
        }
    }

    BinaryData IPersistableModel<HyperparameterBetaFactor>.Write(ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, options);

    HyperparameterBetaFactor IPersistableModel<HyperparameterBetaFactor>.Create(BinaryData data, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeHyperparameterBeta, data, options);

    internal static HyperparameterBetaFactor DeserializeHyperparameterBeta(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        return element.ValueKind switch
        {
            JsonValueKind.Number => new(element.Getdouble32()),
            JsonValueKind.String => new(element.GetString()),
            _ => throw new ArgumentException($"Unsupported JsonValueKind", nameof(HyperparameterBeta))
        };
    }

    string IPersistableModel<HyperparameterBetaFactor>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}