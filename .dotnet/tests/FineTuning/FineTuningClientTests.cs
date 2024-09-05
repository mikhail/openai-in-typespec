using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Models;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;



namespace OpenAI.Tests.FineTuning;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
[Category("FineTuning")]
[Category("Smoke")]
public class FineTuningClientTests
{

    FineTuningClient client;
    FileClient fileClient;

    string samplePath;
    string validationPath;

    OpenAIFileInfo sampleFile;
    OpenAIFileInfo validationFile;

    [OneTimeSetUp]
    public void Setup()
    {
        client = GetTestClient();
        fileClient = GetTestClient<FileClient>(TestScenario.Files);

        samplePath = Path.Combine("Assets", "fine_tuning_sample.jsonl");
        validationPath = Path.Combine("Assets", "fine_tuning_sample_validation.jsonl");

        sampleFile = fileClient.UploadFile(samplePath, FileUploadPurpose.FineTune);
        validationFile = fileClient.UploadFile(validationPath, FileUploadPurpose.FineTune);

    }

    [OneTimeTearDown]
    public void TearDown()
    {
        fileClient.DeleteFile(sampleFile.Id);
        fileClient.DeleteFile(validationFile.Id);
    }



    [Test]
    [Parallelizable]
    public void MinimalRequiredParams()
    {

        FineTuningJob job = client.CreateJob("gpt-3.5-turbo", sampleFile.Id);

        Assert.True(job.Status.InProgress);
        Assert.AreEqual(0, job.Hyperparameters.CycleCount);

        job = client.CancelJob(job.JobId);

        Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
        Assert.False(job.Status.InProgress);
    }

    // minimal but async
    [Test]
    [Parallelizable]
    public async Task MinimalRequiredParamsAsync()
    {

        FineTuningJob job = await client.CreateJobAsync("gpt-3.5-turbo", sampleFile.Id);

        Assert.True(job.Status.InProgress);
        Assert.AreEqual(0, job.Hyperparameters.CycleCount);

        job = await client.CancelJobAsync(job.JobId);

        Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
        Assert.False(job.Status.InProgress);
    }

    [Test]
    [Parallelizable]
    public void AllParameters()
    {
        // This test does not check for Integrations because it requires a valid API key

        var options = new FineTuningOptions()
        {
            Hyperparameters = new() {
                CycleCount = 1,
                BatchSize = 2,
                LearningRate = 3
            },
            Suffix = "TestFTJob",
            ValidationFile = validationFile.Id,
            Seed = 1234567
        };

        FineTuningJob job = client.CreateJob(
            "gpt-3.5-turbo",
            sampleFile.Id,
            options
            );

        Assert.AreEqual(1, job.Hyperparameters.CycleCount);
        Assert.AreEqual(2, job.Hyperparameters.BatchSize);
        Assert.AreEqual(3, job.Hyperparameters.LearningRateMultiplier);
        Assert.AreEqual(job.UserProvidedSuffix, "TestFTJob");
        Assert.AreEqual(1234567, job.Seed);
        Assert.AreEqual(validationFile.Id, job.ValidationFileId);

        job = client.CancelJob(job.JobId);
    }

    [Test]
    [Parallelizable]
    public async Task AllParametersAsync()
    {
        // This test does not check for Integrations because it requires a valid API key

        var options = new FineTuningOptions()
        {
            Hyperparameters = new()
            {
                CycleCount = 1,
                BatchSize = 2,
                LearningRate = 3
            },
            Suffix = "TestFTJob",
            ValidationFile = validationFile.Id,
            Seed = 1234567
        };

        FineTuningJob job = await client.CreateJobAsync(
            "gpt-3.5-turbo",
            sampleFile.Id,
            options
        );


        Assert.AreEqual(1, job.Hyperparameters.CycleCount);
        Assert.AreEqual(2, job.Hyperparameters.BatchSize);
        Assert.AreEqual(3, job.Hyperparameters.LearningRateMultiplier);
        Assert.AreEqual(job.UserProvidedSuffix, "TestFTJob");
        Assert.AreEqual(1234567, job.Seed);
        Assert.AreEqual(validationFile.Id, job.ValidationFileId);

        job = await client.CancelJobAsync(job.JobId);
    }



    [Test]
    [Parallelizable]
    [Explicit("This test is slow and costs $ because it completes the fine-tuning job.")]
    public async Task TestWaitForSuccess()
    {
        // Keep number of iterations low to avoid high costs
        var hp = new HyperparameterOptions()
        {
            CycleCount = 1,
            BatchSize = 10,
        };

        FineTuningJob job = client.CreateJob(
            "gpt-3.5-turbo",
            sampleFile.Id,
            options: new() { Hyperparameters = hp }
        );

        job = await client.WaitUntilCompleted(job);
        // Debug logs might be similar to:
        /*
         *     Waiting for 30 seconds
         *     Waiting for 30 seconds
         *     ...
         *     Waiting for 30 seconds
         *     Waiting for 00:03:16.7177007
         */

        Assert.AreEqual(FineTuningJobStatus.Succeeded, job.Status);
    }


    [Test]
    [Parallelizable]
    [Explicit("This test requires wandb.ai account and api key integration.")]
    public void WandBIntegrations()
    {
        FineTuningJob job = client.CreateJob(
            "gpt-3.5-turbo",
            sampleFile.Id,
            options: new()
            {
                Integrations = { new WeightsAndBiasesIntegration("ft-tests") },
            }
        );
        client.CancelJob(job.JobId);
    }

    [Test]
    [Parallelizable]
    public void ExceptionThrownOnInvalidFileName()
    {
        Assert.Throws<ClientResultException>(() =>
            client.CreateJob(baseModel: "gpt-3.5-turbo", trainingFileId: "Invalid File Name")
        );
    }

    [Test]
    [Parallelizable]
    public void ExceptionThrownOnInvalidModelName()
    {
        Assert.Throws<ClientResultException>(() =>
            client.CreateJob(baseModel: "gpt-nonexistent", trainingFileId: sampleFile.Id)
        );
    }

    [Test]
    [Parallelizable]
    public void ExceptionThrownOnInvalidValidationId()
    {
        Assert.Throws<ClientResultException>(() =>
        {
            FineTuningJob job = client.CreateJob(
                "gpt-3.5-turbo",
                sampleFile.Id,
                new() { ValidationFile = "7" }
            );
        });
    }

    [Test]
    [Parallelizable]
    public void ExceptionThrownOnInvalidValidationIdAsync()
    {
        Assert.ThrowsAsync<ClientResultException>(async () =>
        {
            var job = await client.CreateJobAsync(
                "gpt-3.5-turbo",
                sampleFile.Id,
                new() { ValidationFile = "7" }
                );
        });
    }

    [Test]
    [Parallelizable]
    public async Task GetEventsWithPagination()
    {
        FineTuningJob job = client.CreateJob("gpt-3.5-turbo", sampleFile.Id);
        client.CancelJob(job.JobId);

        IAsyncEnumerable<ClientResult> result = client.GetLimitedJobEventsAsync(job.JobId);
        AsyncPageCollection<FineTuningJobEvent> pagesOfEvents = (AsyncPageCollection<FineTuningJobEvent>)result;

        await foreach (var page in pagesOfEvents)
        {
            foreach (var @event in page.Values)
            {
                Assert.IsTrue(@event.Id.StartsWith("ftevent"));
            }
        }
    }

    /// Manual experiments show that there are always at least 2 events:
    /// First one is that the job is created
    /// Second one is "validating training file"
    /// If this test starts failing because of the wrong count, please first check if the above is still true
    [Test]
    [Parallelizable]
    public async Task AutoResolvePagination()
    {
        FineTuningJob job = client.CreateJob("gpt-3.5-turbo", sampleFile.Id);

        ListEventsOptions options = new()
        {
            Limit = 1
        };
        var events = client.GetJobEventsAsync(job.JobId, options);

        client.CancelJob(job.JobId);

        var count = 1;
        await foreach (var e in events)
        {
            Assert.IsTrue(e.Id.StartsWith("ftevent"));
            count++;
        }
        Assert.GreaterOrEqual(count, 2);
    }

    // Test getting all the jobs
    [Test]
    [Parallelizable]
    public void GetJobs()
    {
        //var jobs = client.GetJobs();

        //Assert.GreaterOrEqual(jobs.Count, 0);
    }

    private static FineTuningClient GetTestClient() => GetTestClient<FineTuningClient>(TestScenario.FineTuning);

}