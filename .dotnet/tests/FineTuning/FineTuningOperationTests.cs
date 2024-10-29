using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using OpenAI.FineTuning;

namespace OpenAI.Tests.FineTuning;


[Parallelizable(ParallelScope.Fixtures)]
[Category("FineTuning")]
[Category("Unit")]

internal class FineTuningOperationTests
{
    [Test]
    [Parallelizable]
    public void TestInProgress()
    {
        FineTuningOperation job;
        job = JobStub(status: FineTuningOperationStatus.Queued);
        Assert.IsTrue(job.Status.InProgress);

        job = JobStub(status: FineTuningOperationStatus.Succeeded);
        Assert.IsFalse(job.Status.InProgress);
    }

    private static FineTuningOperation JobStub(FineTuningOperationStatus? status = null)
    {
        return ModelReaderWriter.Read<FineTuningOperation>(BinaryData.FromString($$"""
        {
          "object": "fine_tuning.job",
          "id": "ftjob-unitTest",
          "created_at": {{DateTimeOffset.MinValue.ToUnixTimeSeconds()}},
          "error": null,
          "fine_tuned_model": "ft:gpt-3.5-turbo-0125:personal::unitTest",
          "finished_at": {{DateTimeOffset.Now.ToUnixTimeSeconds()}},
          "hyperparameters": {},
          "model": "gpt-3.5-turbo-0125",
          "organization_id": "org-unitTest",
          "result_files": ["file-unitTest"],
          "status": "{{status ?? FineTuningOperationStatus.Succeeded}}",
          "trained_tokens": 0,
          "training_file": "file-unitTest",
          "validation_file": "file-unitTest",
          "seed": 0
        }
        """));
    }
}
