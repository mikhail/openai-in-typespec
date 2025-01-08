using TypeSpec.OpenAPI;

namespace OpenAI;

union CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum {
  auto: "auto",
}
union CreateFineTuningJobRequestHyperparametersBatchSizeOption {
  CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum,
  int32,
}

union CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum {
  auto: "auto",
}
union CreateFineTuningJobRequestHyperparametersLearningRateMultiplierOption {
  CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum,
  float32,
}

union CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum {
  auto: "auto",
}
union CreateFineTuningJobRequestHyperparametersNEpochsOption {
  CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum,
  int32,
}

union FineTuningJobBatchSize {
  int32,
}

union CreateFineTuningJobRequestHyperparametersBetaChoiceEnum {
  auto: "auto",
}
union CreateFineTuningJobRequestHyperparametersBetaOption {
  CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum,
  int32,
}

union CreateFineTuningJobRequestMethodType {
  supervised: "supervised",
  dpo: "dpo",
  reinforcement: "reinforcement",
}

@discriminator("type")
model FineTuningJobRequestMethod {
  type: CreateFineTuningJobRequestMethodType;
}

model FineTuningJobRequestMethodSupervised extends FineTuningJobRequestMethod {
  type: CreateFineTuningJobRequestMethodType.supervised;
  supervised: {
    hyperparameters: {
      /**
       * The number of epochs to train the model for. An epoch refers to one full cycle
       * through the training dataset.
       */
      @minValue(1)
      @maxValue(50)
      n_epochs?: CreateFineTuningJobRequestHyperparametersNEpochsOption = CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum.auto;

      /**
       * Number of examples in each batch. A larger batch size means that model parameters
       * are updated less frequently, but with lower variance.
       */
      @minValue(1)
      @maxValue(256)
      batch_size?: CreateFineTuningJobRequestHyperparametersBatchSizeOption = CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum.auto;

      /**
       * Scaling factor for the learning rate. A smaller learning rate may be useful to avoid
       * overfitting.
       */
      @minValue(0)
      learning_rate_multiplier?: CreateFineTuningJobRequestHyperparametersLearningRateMultiplierOption = CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum.auto;
    };
  };
}

model FineTuningJobRequestMethodDpo extends FineTuningJobRequestMethod {
  type: CreateFineTuningJobRequestMethodType.dpo;
  dpo: {
    hyperparameters: {
      /**
       * The number of epochs to train the model for. An epoch refers to one full cycle
       * through the training dataset.
       */
      @minValue(1)
      @maxValue(50)
      n_epochs?: CreateFineTuningJobRequestHyperparametersNEpochsOption = CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum.auto;

      /**
       * Number of examples in each batch. A larger batch size means that model parameters
       * are updated less frequently, but with lower variance.
       */
      @minValue(1)
      @maxValue(256)
      batch_size?: CreateFineTuningJobRequestHyperparametersBatchSizeOption = CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum.auto;

      /**
       * Scaling factor for the learning rate. A smaller learning rate may be useful to avoid
       * overfitting.
       */
      @minValue(0)
      learning_rate_multiplier?: CreateFineTuningJobRequestHyperparametersLearningRateMultiplierOption = CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum.auto;

      /**
       * The beta value for the DPO method. A higher beta value will increase the weight of the penalty between the policy and reference model.
       */
      beta?: CreateFineTuningJobRequestHyperparametersBetaOption = CreateFineTuningJobRequestHyperparametersBetaChoiceEnum.auto;
    };
  };
}

model FineTuningJobRequestMethodReinforcement
  extends FineTuningJobRequestMethod {
  type: CreateFineTuningJobRequestMethodType.reinforcement;
  reinforcement: {
    hyperparameters: {
      /**
       * The number of epochs to train the model for. An epoch refers to one full cycle
       * through the training dataset.
       */
      @minValue(1)
      @maxValue(50)
      n_epochs?: CreateFineTuningJobRequestHyperparametersNEpochsOption = CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum.auto;

      /**
       * Number of examples in each batch. A larger batch size means that model parameters
       * are updated less frequently, but with lower variance.
       */
      @minValue(1)
      @maxValue(256)
      batch_size?: CreateFineTuningJobRequestHyperparametersBatchSizeOption = CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum.auto;

      /**
       * Scaling factor for the learning rate. A smaller learning rate may be useful to avoid
       * overfitting.
       */
      @minValue(0)
      learning_rate_multiplier?: CreateFineTuningJobRequestHyperparametersLearningRateMultiplierOption = CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum.auto;
    };
  };
}

model CreateFineTuningJobRequest {
  /**
   * The name of the model to fine-tune. You can select one of the
   * [supported models](/docs/guides/fine-tuning/which-models-can-be-fine-tuned).
   */
  @extension("x-oaiTypeLabel", "string")
  `model`:
    | string
    | "babbage-002"
    | "davinci-002"
    | "gpt-3.5-turbo"
    | "gpt-4o-mini";

  @doc("""
    The ID of an uploaded file that contains training data.
    
    See [upload file](/docs/api-reference/files/create) for how to upload a file.
    
    Your dataset must be formatted as a JSONL file. Additionally, you must upload your file with the purpose `fine-tune`.
    
    The contents of the file should differ depending on if the model uses the [chat](/docs/api-reference/fine-tuning/chat-input) or [completions](/docs/api-reference/fine-tuning/completions-input) format.
    
    See the [fine-tuning guide](/docs/guides/fine-tuning) for more details.
    """)
  training_file: string;

  // Tool customization: reflect observed wire truth (learning_rate_multiplier, n_epochs) for hyperparameters in ft responses
  /** The hyperparameters used for the fine-tuning job. */
  #deprecated "This field is marked as deprecated."
  hyperparameters?: {
    /**
     * The number of epochs to train the model for. An epoch refers to one full cycle
     * through the training dataset.
     */
    @minValue(1)
    @maxValue(50)
    n_epochs?: CreateFineTuningJobRequestHyperparametersNEpochsOption = CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum.auto;

    /**
     * Number of examples in each batch. A larger batch size means that model parameters
     * are updated less frequently, but with lower variance.
     */
    @minValue(1)
    @maxValue(256)
    batch_size?: CreateFineTuningJobRequestHyperparametersBatchSizeOption = CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum.auto;

    /**
     * Scaling factor for the learning rate. A smaller learning rate may be useful to avoid
     * overfitting.
     */
    @minValue(0)
    learning_rate_multiplier?: CreateFineTuningJobRequestHyperparametersLearningRateMultiplierOption = CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum.auto;
  };

  @doc("""
    A string of up to 64 characters that will be added to your fine-tuned model name.
    
    For example, a `suffix` of "custom-model-name" would produce a model name like `ft:gpt-4o-mini:openai:custom-model-name:7p4lURel`.
    """)
  @minLength(1)
  @maxLength(64)
  suffix?: string | null = null;

  @doc("""
    The ID of an uploaded file that contains validation data.
    
    If you provide this file, the data is used to generate validation
    metrics periodically during fine-tuning. These metrics can be viewed in
    the fine-tuning results file.
    The same data should not be present in both train and validation files.
    
    Your dataset must be formatted as a JSONL file. You must upload your file with the purpose `fine-tune`.
    
    See the [fine-tuning guide](/docs/guides/fine-tuning) for more details.
    """)
  validation_file?: string | null;

  // Tool customization: establish a discriminated type basis
  /** A list of integrations to enable for your fine-tuning job. */
  integrations?: CreateFineTuningJobRequestIntegrations | null;

  /**
   * The seed controls the reproducibility of the job. Passing in the same seed and job parameters should produce the same results, but may differ in rare cases.
   * If a seed is not specified, one will be generated for you.
   */
  @minValue(0)
  @maxValue(2147483647)
  seed?: int32 | null;

  method?: FineTuningJobRequestMethod;
}

model FineTuningJobHyperparameters {
  beta: int32 | null;

  /**
   * The number of epochs to train the model for. An epoch refers to one full cycle
   * through the training dataset.
   */
  n_epochs: int32 | null;

  /**
   * Number of examples in each batch. A larger batch size means that model parameters
   * are updated less frequently, but with lower variance.
   */
  batch_size: int32 | null;

  /**
   * Scaling factor for the learning rate. A smaller learning rate may be useful to avoid
   * overfitting.
   */
  learning_rate_multiplier: float32 | null;
}

@discriminator("type")
model CreateFineTuningJobRequestIntegration {
  type: string;
}

model CreateFineTuningJobRequestWandbIntegration
  extends CreateFineTuningJobRequestIntegration {
  type: "wandb";
  wandb: {
    project: string;
    name?: string | null;
    entity?: string | null;
    tags?: string[];
  };
}

@discriminator("type")
model FineTuningIntegration {
  type: string;
}

model FineTuningJobsPageToken {
  limit?: int32;
  after?: string;
}

// Tool customization: Represent undocumented response 'user_provided_suffix' property
@doc("""
  The `fine_tuning.job` object represents a fine-tuning job that has been created through the API.
  """)
model FineTuningJob {
  /** The descriptive suffix applied to the job, as specified in the job creation request. */
  user_provided_suffix?: string | null;

  /** The object identifier, which can be referenced in the API endpoints. */
  id: string;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the fine-tuning job was created. */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  @doc("""
    For fine-tuning jobs that have `failed`, this will contain more information on the cause of the failure.
    """)
  error: {
    /** A machine-readable error code. */
    code: string;

    /** A human-readable error message. */
    message: string;

    @doc("""
      The parameter that was invalid, usually `training_file` or `validation_file`. This field will be null if the failure was not parameter-specific.
      """)
    param: string | null;
  } | null;

  /** The name of the fine-tuned model that is being created. The value will be null if the fine-tuning job is still running. */
  fine_tuned_model: string | null;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the fine-tuning job was finished. The value will be null if the fine-tuning job is still running. */
  @encode("unixTimestamp", int32)
  finished_at: utcDateTime | null;

  // Tool customization: reflect observed wire truth (learning_rate_multiplier, n_epochs) for hyperparameters in ft responses
  /** The hyperparameters used for the fine-tuning job. See the [fine-tuning guide](/docs/guides/fine-tuning) for more details. */
  hyperparameters?: FineTuningJobHyperparameters;

  /** The base model that is being fine-tuned. */
  `model`: string;

  /** The object type, which is always "fine_tuning.job". */
  object: "fine_tuning.job";

  /** The organization that owns the fine-tuning job. */
  organization_id: string;

  /** The compiled results file ID(s) for the fine-tuning job. You can retrieve the results with the [Files API](/docs/api-reference/files/retrieve-contents). */
  result_files: string[];

  @doc("""
    The current status of the fine-tuning job, which can be either `validating_files`, `queued`, `running`, `succeeded`, `failed`, or `cancelled`.
    """)
  status:
    | "validating_files"
    | "queued"
    | "running"
    | "succeeded"
    | "failed"
    | "cancelled";

  /** The total number of billable tokens processed by this fine-tuning job. The value will be null if the fine-tuning job is still running. */
  trained_tokens: int32 | null;

  /** The file ID used for training. You can retrieve the training data with the [Files API](/docs/api-reference/files/retrieve-contents). */
  training_file: string;

  /** The file ID used for validation. You can retrieve the validation results with the [Files API](/docs/api-reference/files/retrieve-contents). */
  validation_file: string | null;

  /** A list of integrations to enable for this fine-tuning job. */
  integrations?: FineTuningJobIntegrations | null;

  /** The seed used for the fine-tuning job. */
  seed: int32;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the fine-tuning job is estimated to finish. The value will be null if the fine-tuning job is not running. */
  @encode("unixTimestamp", int32)
  estimated_finish?: utcDateTime | null;

  method: FineTuningJobRequestMethod | null;
}
