using BowlingGameKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class BowlingGameTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void EveryKnockedPinGivesOnePoint(int count)
        {
            BowlingGame sut = CreateSut();
            sut.Roll(count);
            Assert.That(sut.Score(), Is.EqualTo(count));
        }

        [Test]
        [TestCase(new[] { 5, 5, 3 }, 16)]
        [TestCase(new[] { 2, 10, 5 }, 17)]
        public void TotalScoreIsSumOfKnockedDownPins(int[] rolls, int expectedScore)
        {
            var sut = CreateSut();
            rolls.ToList().ForEach(roll => sut.Roll(roll));
            Assert.That(sut.Score(), Is.EqualTo(expectedScore));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(11)]
        public void RolledDownPinsIsBetweenZeroAndTen(int amount)
        {
            var sut = CreateSut();
            Assert.That(() => sut.Roll(amount), Throws.Exception);
        }

        [Test]
        [TestCase(new[] { 1, 9, 5, 0 }, 20)]
        [TestCase(new[] { 5, 5, 0, 0 }, 10)]
        [TestCase(new[] { 5, 4, 3, 7, 5, 0 }, 29)]
        public void WhenSpareNextFrameIsAddedToScore(int[] rolls, int expectedScore)
        {
            var sut = CreateSut();
            rolls.ToList().ForEach(count => sut.Roll(count));
            Assert.That(sut.Score, Is.EqualTo(expectedScore));
        }

        private static BowlingGame CreateSut()
        {
            return new BowlingGame();
        }
    }
}