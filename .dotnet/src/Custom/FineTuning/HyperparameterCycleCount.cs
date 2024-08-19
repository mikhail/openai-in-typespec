using System;
using System.ComponentModel;

namespace OpenAI.FineTuning;


public partial class HyperparameterCycleCount: BinaryData
{
    public HyperparameterCycleCount(BinaryData data) : base(data) { }

    private HyperparameterCycleCount(string predefinedLabel) : base($@"""{predefinedLabel}""") { }
    public HyperparameterCycleCount(int epochCount) : base($"{epochCount}") { }


    public static implicit operator HyperparameterCycleCount(int epochCount) => new(epochCount);

    public bool Equals(int other) => this == new HyperparameterCycleCount(other);
    public bool Equals(string other) => this == new HyperparameterCycleCount(other);

    //public override bool Equals(object other) => other is HyperparameterCycleCount cc && cc == this;
}
