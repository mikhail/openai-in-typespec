﻿using NUnit.Framework;
using OpenAI.FineTuning;
using System;

namespace OpenAI.Tests.FineTuning;

[Parallelizable(ParallelScope.Fixtures)]
[Category("FineTuning")]
[Category("Unit")]

class HyperparameterOptionsTests
{
    [Test]
    [Parallelizable]
    public void OptionsCanEasilyCompare()
    {
        Assert.AreEqual(new HyperparameterCycleCount(1), 1);
        Assert.AreEqual(new HyperparameterBatchSize(1), 1);
        Assert.AreEqual(new HyperparameterLearningRate(1), 1);
        Assert.AreEqual(new HyperparameterBetaFactor(1), 1);

        Assert.AreEqual(1, new HyperparameterCycleCount(1));
        Assert.AreEqual(1, new HyperparameterBatchSize(1));
        Assert.AreEqual(1.0, new HyperparameterLearningRate(1));
        Assert.AreEqual(1, new HyperparameterBetaFactor(1));

        Assert.That(1 == new HyperparameterCycleCount(1));
        Assert.That(1 == new HyperparameterBatchSize(1));
        Assert.That(0.5 == new HyperparameterLearningRate(0.5));

        Assert.That(new HyperparameterBatchSize(1) == 1);
        Assert.That(new HyperparameterCycleCount(1) == 1);
        Assert.That(new HyperparameterLearningRate(1) == 1);
        Assert.That(new HyperparameterBetaFactor(1) == 1);
    }

    [Test]
    [Parallelizable]
    public void OptionsCanEasilySet()
    {
        FineTuningTrainingMethod supervisedMethod = FineTuningTrainingMethod.CreateSupervised();
        // TODO: Add more tests here
    }
}
