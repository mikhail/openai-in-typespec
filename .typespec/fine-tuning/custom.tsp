using TypeSpec.OpenAPI;

namespace OpenAI;

model CreateFineTuningJobRequestHyperparameters {
  /**
   * The number of epochs to train the model for. An epoch refers to one full cycle
   * through the training dataset.
   */
  @minValue(1)
  @maxValue(50)
  n_epochs?: integer | "auto";

  /**
   * Number of examples in each batch. A larger batch size means that model parameters
   * are updated less frequently, but with lower variance.
   */
  @minValue(1)
  @maxValue(256)
  batch_size?: integer | "auto";

  /**
   * Scaling factor for the learning rate. A smaller learning rate may be useful to avoid
   * overfitting.
   */
  @minValue(0)
  @minValueExclusive(1)
  learning_rate_multiplier?: float | "auto";
}

model FineTuningJobHyperparameters {
  /**
   * The number of epochs to train the model for. An epoch refers to one full cycle
   * through the training dataset.
   */
  n_epochs: integer | "auto";

  /**
   * Number of examples in each batch. A larger batch size means that model parameters
   * are updated less frequently, but with lower variance.
   */
  batch_size: integer | "auto";

  /**
   * Scaling factor for the learning rate. A smaller learning rate may be useful to avoid
   * overfitting.
   */
  learning_rate_multiplier: float | "auto";
}
