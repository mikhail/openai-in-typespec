﻿using OpenAI.Models;
using System.Collections.Generic;

namespace OpenAI.FineTuning;

/// <summary>
/// Represents additional options available when creating a <see cref="FineTuningJob"/>.
/// </summary>
[CodeGenModel("CreateFineTuningJobRequest")]
public partial class FineTuningOptions
{

    [CodeGenMember("Model")]
    internal CreateFineTuningJobRequestModel Model { get; set; }
    [CodeGenMember("TrainingFile")]
    internal string TrainingFile { get; set; }


    /// <inheritdoc cref="HyperparameterOptions"/>
    [CodeGenMember("Hyperparameters")]
    public HyperparameterOptions Hyperparameters { get; set; }

    /// <summary>
    /// Suffix to append to the model name and job name
    /// </summary>
    [CodeGenMember("Suffix")]
    public string Suffix { get; set; }

    /// <summary>
    /// The validation file Id that is already uploaded. String should match pattern '^file-[a-zA-Z0-9]{24}$' and is retrieved by using a FileClient.UploadFile(...) call.
    /// </summary>
    [CodeGenMember("ValidationFile")]
    public string ValidationFile { get; set; }

    /// <summary>
    /// <para>A list of integrations to use See <see cref="Integration"/>.</para>
    /// Only WandB.io is currently supported.
    /// </summary>
    [CodeGenMember("Integrations")]
    public IList<FineTuningIntegration> Integrations { get; }


    /// <summary>
    /// The seed to use for reproducibility.
    /// A random one will be generated if you do not set one.
    /// </summary>
    [CodeGenMember("Seed")]
    public int? Seed { get; set; }

    public FineTuningOptions()
    {
        Integrations = new ChangeTrackingList<FineTuningIntegration>();
    }

    internal FineTuningOptions(CreateFineTuningJobRequestModel model, string trainingFile)
        : this()
    {
        Argument.AssertNotNull(trainingFile, nameof(trainingFile));

        Model = model;
        TrainingFile = trainingFile;
    }
}