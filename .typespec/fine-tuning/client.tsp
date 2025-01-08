import "@azure-tools/typespec-client-generator-core";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@access(FinetuneChatRequestInput, Access.public);
@@usage(FinetuneChatRequestInput, Usage.input);

@@access(FinetuneCompletionRequestInput, Access.public);
@@usage(FinetuneCompletionRequestInput, Usage.input);

@@access(FineTuningJobsPageToken, Access.public);
@@usage(FineTuningJobsPageToken, Usage.input);

@@access(CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum,
  Access.public
);
@@usage(CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum,
  Usage.input
);
@@access(CreateFineTuningJobRequestHyperparametersNEpochsOption, Access.public);
@@usage(CreateFineTuningJobRequestHyperparametersNEpochsOption, Usage.input);

@@access(CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum,
  Access.public
);
@@usage(CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum,
  Usage.input
);
@@access(CreateFineTuningJobRequestHyperparametersLearningRateMultiplierOption,
  Access.public
);
@@usage(CreateFineTuningJobRequestHyperparametersLearningRateMultiplierOption,
  Usage.input
);

@@access(CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum,
  Access.public
);
@@usage(CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum,
  Usage.input
);
@@access(CreateFineTuningJobRequestHyperparametersBatchSizeOption,
  Access.public
);
@@usage(CreateFineTuningJobRequestHyperparametersBatchSizeOption, Usage.input);

@@access(CreateFineTuningJobRequestHyperparametersBetaChoiceEnum,
  Access.public
);
@@usage(CreateFineTuningJobRequestHyperparametersBetaChoiceEnum, Usage.input);
@@access(CreateFineTuningJobRequestHyperparametersBetaOption, Access.public);
@@usage(CreateFineTuningJobRequestHyperparametersBetaOption, Usage.input);
