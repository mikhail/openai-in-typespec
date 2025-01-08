using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum")]
internal readonly partial struct InternalCreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum { }

[CodeGenModel("CreateFineTuningJobRequestHyperparametersNEpochsOption")]
public partial class HyperparameterCycleCount : IEquatable<int>, IEquatable<string>, IJsonModel<HyperparameterCycleCount>
{
    private readonly string _stringValue;
    private readonly int? _intValue;

    internal HyperparameterCycleCount(string predefinedLabel)
    {
        _stringValue = predefinedLabel;
    }

    public HyperparameterCycleCount(int epochCount)
    {
        _intValue = epochCount;
    }

    public static HyperparameterCycleCount CreateAuto() => new(InternalCreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum.Auto.ToString());
    public static HyperparameterCycleCount CreateEpochCount(int epochCount) => new(epochCount);

    public static implicit operator HyperparameterCycleCount(int epochCount) => new(epochCount);
    
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator ==(HyperparameterCycleCount first, HyperparameterCycleCount second)
    {
        if (first is null && second is null) return true;
        if (first is null || second is null) return false;
        if (first._intValue.HasValue != second._intValue.HasValue) return false;
        if (first._intValue.HasValue) return first._intValue == second._intValue;
        return first._stringValue == second._stringValue;
    }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator !=(HyperparameterCycleCount first, HyperparameterCycleCount second) => !(first == second);
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Equals(int other) => _intValue == other;
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Equals(string other) => _intValue is null && _stringValue == other;
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object other) => other is HyperparameterCycleCount cc && cc == this;
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _intValue?.GetHashCode() ?? _stringValue.GetHashCode();

    void IJsonModel<HyperparameterCycleCount>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        SerializeHyperparameterCycleCount(this, writer, options);
    }

    HyperparameterCycleCount IJsonModel<HyperparameterCycleCount>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeHyperparameterCycleCount(document.RootElement, options);
    }

    internal static void SerializeHyperparameterCycleCount(HyperparameterCycleCount instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
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

    BinaryData IPersistableModel<HyperparameterCycleCount>.Write(ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, options);

    HyperparameterCycleCount IPersistableModel<HyperparameterCycleCount>.Create(BinaryData data, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeHyperparameterCycleCount, data, options);

    internal static HyperparameterCycleCount DeserializeHyperparameterCycleCount(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        return element.ValueKind switch
        {
            JsonValueKind.Number => new(element.GetInt32()),
            JsonValueKind.String => new(element.GetString()),
            _ => throw new ArgumentException($"Unsupported JsonValueKind", nameof(HyperparameterCycleCount))
        };
    }

    string IPersistableModel<HyperparameterCycleCount>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}