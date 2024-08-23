using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using OpenAI.FineTuning;

namespace OpenAI.Tests.FineTuning;


[Parallelizable(ParallelScope.Fixtures)]
[Category("FineTuning")]
[Category("Unit")]

internal class FineTuningJobTests
{
    [Test]
    [Parallelizable]
    public void PlaygroundURL()
    {
        var job = JobStub();
        var uri = job.PlaygroundUri;
        var expected = "https://platform.openai.com/playground/chat?models=gpt-3.5-turbo-0125&models=ft:gpt-3.5-turbo-0125:personal::unitTest";
        Assert.AreEqual(expected, uri.ToString());
    }

    // Test that inProgress changes when the status changes.
    [Test]
    [Parallelizable]
    public void TestInProgress()
    {
        FineTuningJob job;
        job = JobStub(status: FineTuningJobStatus.Queued);
        Assert.IsTrue(job.Status.InProgress);

        job = JobStub(status: FineTuningJobStatus.Succeeded);
        Assert.IsFalse(job.Status.InProgress);
    }

    private static FineTuningJob JobStub(FineTuningJobStatus? status = null)
    {
        return ModelReaderWriter.Read<FineTuningJob>(BinaryData.FromString($$"""
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
          "status": "{{status ?? FineTuningJobStatus.Succeeded}}",
          "trained_tokens": 0,
          "training_file": "file-unitTest",
          "validation_file": "file-unitTest",
          "seed": 0
        }
        """));
    }
}
