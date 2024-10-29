namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJobStatus")]
public readonly partial struct FineTuningOperationStatus
{
    public bool InProgress =>
        _value == FineTuningOperationStatus.ValidatingFiles ||
        _value == FineTuningOperationStatus.Queued ||
        _value == FineTuningOperationStatus.Running;
}
