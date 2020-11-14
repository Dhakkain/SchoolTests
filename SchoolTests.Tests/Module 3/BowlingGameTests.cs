using FluentAssertions;
using NUnit.Framework;
using SchoolTests.Module3;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTests.Tests.Module3
{
    [TestFixture]
    public class BowlingGameTests
    {
        [Test]
        [TestCase(2,3)]
        [TestCase(7, 0)]
        [TestCase(1, 1)]
        public void ShouldReturnScoreEqualToPinsNumberGiven(int firstThrow, int secondThrow)
        {
        BowlingGame bowlingGame = new BowlingGame();

            bowlingGame.ThrowBowling(firstThrow, secondThrow);
            var result = bowlingGame.GetScore();
            result.Should().Be(firstThrow + secondThrow);
        }

        [Test]
        [TestCase(5, 5, 3)]
        [TestCase(2, 8, 1)]
        [TestCase(6, 4, 7)]
        public void ShouldReturnScoreWithExtraTenPointPointWhenAllBowlsThrows(int firstThrow, int secondThrow, int pointFromNextRoll)
        {
            BowlingGame bowlingGame = new BowlingGame();
            bowlingGame.ThrowBowling(firstThrow, secondThrow);
            bowlingGame.ThrowBowling(pointFromNextRoll, 0);
            var result = bowlingGame.GetScore();
            result.Should().Be(2* pointFromNextRoll + 10);
        }

        [Test]
        [TestCase(10)]
        public void ShouldReturnScoreWithExtraBonusWhenSpareThrowsXTimes(int frames)
        {
            BowlingGame bowlingGame = new BowlingGame();
            for (int i = 0; i < frames; i++)
            {
                bowlingGame.ThrowBowling(5, 5);
            }

            var result = bowlingGame.GetScore();
            result.Should().Be(145);
        }


        [Test]
        public void ShouldReturnScoreWithExtraBonusWhenStrikeThrowsXTimes()
        {
            BowlingGame bowlingGame = new BowlingGame();
            for (int i = 0; i < 11; i++)
            {
                bowlingGame.ThrowBowling(10, 0);
            }

            var result = bowlingGame.GetScore();
            result.Should().Be(110);
        }
    }
}
