using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenAI.Files;
using OpenAI.FineTuning;
using System;
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
    OpenAIFileClient fileClient;

    string samplePath;
    string validationPath;

    OpenAIFile sampleFile;
    OpenAIFile validationFile;

    [OneTimeSetUp]
    public void Setup()
    {
        client = GetTestClient();
        fileClient = GetTestClient<OpenAIFileClient>(TestScenario.Files);

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
    [Parallelizable(ParallelScope.All)]
    public async Task MinimalRequiredParams([Values] bool isAsync)
    {

        FineTuningOperation ftOp = isAsync
            ? await client.FineTuneAsync("gpt-3.5-turbo", sampleFile.Id)
            : client.FineTune("gpt-3.5-turbo", sampleFile.Id);

        Assert.AreEqual(0, ftOp.Hyperparameters.CycleCount);
        Assert.True(ftOp.Status.InProgress);
        Assert.False(ftOp.HasCompleted);

        _ = isAsync
            ? await ftOp.CancelAndUpdateAsync()
            : ftOp.CancelAndUpdate();

        Assert.AreEqual(FineTuningStatus.Cancelled, ftOp.Status);
        Assert.False(ftOp.Status.InProgress);
        Assert.True(ftOp.HasCompleted);
    }



    [Test]
    [Parallelizable(ParallelScope.All)]
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

        FineTuningOperation ft = isAsync
            ? await client.FineTuneAsync("gpt-3.5-turbo", sampleFile.Id, options)
            : client.FineTune("gpt-3.5-turbo", sampleFile.Id, options);
        Assert.AreEqual(1, ft.Hyperparameters.CycleCount);
        Assert.AreEqual(2, ft.Hyperparameters.BatchSize);
        Assert.AreEqual(3, ft.Hyperparameters.LearningRateMultiplier);
        Assert.AreEqual(ft.UserProvidedSuffix, "TestFTJob");
        Assert.AreEqual(1234567, ft.Seed);
        Assert.AreEqual(validationFile.Id, ft.ValidationFileId);

        ft.CancelAndUpdate();
    }

    [Test]
    [Parallelizable]
    public async Task TestWaitForCompletion()
    {
        // Arrange
        FineTuningOperation ft;
        try
        {
            ft = client.ListOperations(options: new() { PageSize = 100 }).Where((ft) => ft.Status == "succeeded").First();
        }
        catch (InvalidOperationException)
        {
            ft = await client.FineTuneAsync("gpt-3.5-turbo", sampleFile.Id);
        }

        // Act
        await ft.WaitForCompletionAsync();

        // Assert
        Assert.True(ft.HasCompleted);
        Assert.NotNull(ft.Value);
        Assert.True(ft.Value.StartsWith("ft:gpt-3.5-turbo-0125:"));
    }


    [Test]
    [Parallelizable]
    [Explicit("This test requires wandb.ai account and api key integration.")]
    public void WandBIntegrations()
    {
        FineTuningOperation ft = client.FineTune(
            "gpt-3.5-turbo",
            sampleFile.Id,
            options: new()
            {
                Integrations = { new WeightsAndBiasesIntegration("ft-tests") },
            }
        );
        ft.CancelAndUpdate();
    }

    [Test]
    [Parallelizable]
    public void ExceptionThrownOnInvalidFileName()
    {
        Assert.Throws<ClientResultException>(() =>
            client.FineTune(baseModel: "gpt-3.5-turbo", trainingFileId: "Invalid File Name")
        );
    }

    [Test]
    [Parallelizable]
    public void ExceptionThrownOnInvalidModelName()
    {
        Assert.Throws<ClientResultException>(() =>
            client.FineTune(baseModel: "gpt-nonexistent", trainingFileId: sampleFile.Id)
        );
    }

    [Test]
    [Parallelizable]
    public void ExceptionThrownOnInvalidValidationId()
    {
        Assert.Throws<ClientResultException>(() =>
        {
            client.FineTune(
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
            await client.FineTuneAsync(
                "gpt-3.5-turbo",
                sampleFile.Id,
                new() { ValidationFile = "7" }
            );
        });
    }

    [Test]
    [Parallelizable(ParallelScope.All)]
    public void GetJobs([Values(Method.Sync, Method.Async)] Method method)
    {
        // Arrange
        var fts = (method == Method.Async)
            ? client.ListOperationsAsync().Take(10).ToBlockingEnumerable()
            : client.ListOperations().Take(10);


        // Act
        var counter = 0;
        foreach (var ft in fts)  // Network call will happen here on first iteration.
        {
            Assert.IsTrue(ft.OperationId.StartsWith("ftjob"));
            counter++;
        }

        // Assert
        Assert.Greater(counter, 0);
        Assert.LessOrEqual(counter, 10);
    }

    [Test]
    [Parallelizable(ParallelScope.All)]
    public void GetJobById([Values(Method.Sync, Method.Async)] Method method)
    {
        // Arrange
        var id = (method == Method.Async)
            ? client.ListOperationsAsync().ToBlockingEnumerable().First().OperationId
            : client.ListOperations().First().OperationId;


        // Act

        var ftOp = (method == Method.Async)
            ? client.GetOperationAsync(id).Result
            : client.GetOperation(id);

        // Assert
        Assert.AreEqual(ftOp.OperationId, id);
    }


    [Test]
    [Parallelizable]
    public void GetJobsWithAfter()
    {
        // Arrange
        FineTuningOperation firstOp = client.ListOperations().First();

        if (firstOp is null)
        {
            Assert.Fail("No jobs found. At least 2 jobs have to be found to run this test.");
        }

        // Act
        // DISCUSS: we say list operations but filter says AfterOperationId.
        FineTuningOperation secondOp = client.ListOperations(new() { AfterOperationId = firstOp.OperationId }).First();

        if (secondOp is null)
        {
            return; // No second ft found means the filter worked.
        }

        // Assert
        Assert.AreNotEqual(firstOp.OperationId, secondOp.OperationId);
    }

    /// Manual experiments show that there are always at least 2 events:
    /// First one is that the ft is created
    /// Second one is "validating training file"
    /// If this test starts failing because of the wrong count, please first check if the above is still true
    [Test]
    [Parallelizable(ParallelScope.All)]
    public void GetJobEvents([Values(Method.Sync, Method.Async)] Method method)
    {
        // Arrange
        FineTuningOperation ft = client.FineTune("gpt-3.5-turbo", sampleFile.Id);

        ListEventsOptions options = new()
        {
            PageSize = 1
        };
        ft.CancelAndUpdate();

        // Act
        var events = (method == Method.Async)
            ? ft.GetEventsAsync(options).ToBlockingEnumerable()
            : ft.GetEvents(options);

        var first = events.FirstOrDefault();

        // Assert
        if (first is null)
        {
            Assert.Fail("No events found.");
        }
    }

    [Test]
    [Parallelizable(ParallelScope.All)]
    public void GetCheckpoints([Values(Method.Sync, Method.Async)] Method method)
    {
        // Arrange
        // TODO: When `status` option becomes available, use it to get a succeeded ft
        FineTuningOperation job = client.ListOperations(new() { PageSize = 100 })
                                  .Where((job) => job.Status == "succeeded")
                                  .First();


        // Act
        var checkpoints = (method == Method.Async)
            ? job.GetCheckpointsAsync().ToBlockingEnumerable()
            : job.GetCheckpoints();
        FineTuningCheckpoint first = checkpoints.FirstOrDefault();

        // Assert
        if (first is null)
        {
            Assert.Fail("No checkpoints found.");
        }

        FineTuningCheckpointMetrics metrics = first.Metrics;
        Assert.NotNull(metrics);
        Assert.Greater(metrics.Step, 0);
    }

    private static FineTuningClient GetTestClient() => GetTestClient<FineTuningClient>(TestScenario.FineTuning);
}