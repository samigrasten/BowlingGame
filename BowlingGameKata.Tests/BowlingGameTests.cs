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
        [TestCase(new[] { 5, 2, 3 }, 10)]
        [TestCase(new[] { 2, 4, 5 }, 11)]
        public void TotalScoreIsSumOfKnockedDownPins(int[] rolls, int expectedScore)
        {
            var sut = CreateSut();
            rolls.ToList().ForEach(roll => sut.Roll(roll));
            Assert.That(sut.Score(), Is.EqualTo(expectedScore));
        }

        [Test]
        [TestCase(-1, false)]
        [TestCase(0, true)]
        [TestCase(10, true)]
        [TestCase(11, false)]
        public void RolledDownPinsIsBetweenZeroAndTen(int amount, bool expectedResult)
        {
            var sut = CreateSut();
            var result = sut.Roll(amount);
            Assert.That(result.IsSuccess, Is.EqualTo(expectedResult));
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