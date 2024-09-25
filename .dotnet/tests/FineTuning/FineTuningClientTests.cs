using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenAI.Files;
using OpenAI.FineTuning;
using System.ClientModel;
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

    public enum Method
    {
        Sync,
        Async
    }

    FineTuningClient client;
    FileClient fileClient;

    string samplePath;
    string validationPath;

    OpenAIFile sampleFile;
    OpenAIFile validationFile;

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
    public async Task MinimalRequiredParams([Values] bool isAsync)
    {

        FineTuningJob job = isAsync
            ? await client.CreateJobAsync("gpt-3.5-turbo", sampleFile.Id)
            : client.CreateJob("gpt-3.5-turbo", sampleFile.Id);

        Assert.True(job.Status.InProgress);
        Assert.AreEqual(0, job.Hyperparameters.CycleCount);

        job = isAsync
            ? await client.CancelJobAsync(job.JobId)
            : client.CancelJob(job.JobId);

        Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
        Assert.False(job.Status.InProgress);
    }



    [Test]
    [Parallelizable]
    public async Task AllParameters([Values] bool isAsync)
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

        FineTuningJob job = isAsync
            ? await client.CreateJobAsync("gpt-3.5-turbo", sampleFile.Id, options)
            : client.CreateJob("gpt-3.5-turbo", sampleFile.Id, options);

        Assert.AreEqual(1, job.Hyperparameters.CycleCount);
        Assert.AreEqual(2, job.Hyperparameters.BatchSize);
        Assert.AreEqual(3, job.Hyperparameters.LearningRateMultiplier);
        Assert.AreEqual(job.UserProvidedSuffix, "TestFTJob");
        Assert.AreEqual(1234567, job.Seed);
        Assert.AreEqual(validationFile.Id, job.ValidationFileId);

        job = isAsync
            ? await client.CancelJobAsync(job.JobId)
            : client.CancelJob(job.JobId);
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
    public void GetJobs([Values] bool isAsync)
    {
        // Arrange

        // Act
        var jobs = isAsync
            ? client.GetJobsAsync().Take(10).ToBlockingEnumerable()
            : client.GetJobs().Take(10);

        // Assert
        var counter = 0;
        foreach (var job in jobs)
        {
            Assert.IsTrue(job.JobId.StartsWith("ftjob"));
            counter++;
        }

        Assert.Greater(counter, 0);
        Assert.LessOrEqual(counter, 10);
    }

    [Test]
    [Parallelizable]
    public void GetJobsWithAfter()
    {
        var firstJob = client.GetJobs().First();

        if (firstJob is null)
        {
            Assert.Fail("No jobs found. At least 2 jobs have to be found to run this test.");
        }
        var secondJob = client.GetJobs(new() { AfterJobId = firstJob.JobId }).First();

        Assert.AreNotEqual(firstJob.JobId, secondJob.JobId);
        // Can't assert that one was created after the next because they might be created at the same second.
        // Assert.Greater(secondJob.CreatedAt, firstJob.CreatedAt, $"{firstJob}, {secondJob}");
    }

    /// Manual experiments show that there are always at least 2 events:
    /// First one is that the job is created
    /// Second one is "validating training file"
    /// If this test starts failing because of the wrong count, please first check if the above is still true
    [Test]
    [Parallelizable]
    public void GetJobEvents([Values(Method.Sync, Method.Async)] Method method)
    {
        // Arrange
        FineTuningJob job = client.CreateJob("gpt-3.5-turbo", sampleFile.Id);

        ListEventsOptions options = new()
        {
            PageSize = 1
        };
        client.CancelJob(job.JobId);

        // Act
        var events = (method == Method.Async)
            ? client.GetJobEventsAsync(job.JobId, options).ToBlockingEnumerable()
            : client.GetJobEvents(job.JobId, options);
        var first = events.FirstOrDefault();

        // Assert
        if (first is null)
        {
            Assert.Fail("No events found.");
        }
    }

    [Test]
    [Parallelizable]
    public void GetJobCheckpoints([Values(Method.Sync, Method.Async)] Method method)
    {
        // Arrange
        // TODO: When `status` option becomes available, use it to get a succeeded job
        FineTuningJob job = client.GetJobs(new() { PageSize = 100 })
                                  .Where((job) => job.Status == "succeeded")
                                  .First();

        // Act
        var checkpoints = (method == Method.Async)
            ? client.GetJobCheckpointsAsync(job.JobId).ToBlockingEnumerable()
            : client.GetJobCheckpoints(job.JobId);
        FineTuningJobCheckpoint first = checkpoints.FirstOrDefault();

        // Assert
        if (first is null)
        {
            Assert.Fail("No checkpoints found.");
        }
    }


    private static FineTuningClient GetTestClient() => GetTestClient<FineTuningClient>(TestScenario.FineTuning);

}