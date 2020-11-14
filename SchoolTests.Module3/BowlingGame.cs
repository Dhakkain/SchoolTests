using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SchoolTests.Module3
{
    public class BowlingGame
    {
        private int[] BowlThrows { get; set; } = new int[22];

        private int CurrentFrame { get; set; } = 0;


        public int GetScore()
        {
            var gameScore = 0;
            var rollIndex = 0;
            for (int i = 0; i < 10; i++)
            {
                if (IsStrike(BowlThrows[rollIndex]))
                {
                    gameScore += 10 + BowlThrows[rollIndex + 1] + BowlThrows[rollIndex + 2];
                    rollIndex++;
                }
                else if (IsSpare(BowlThrows[rollIndex], BowlThrows[rollIndex + 1]))
                {
                    gameScore += 10 + BowlThrows[rollIndex + 2];
                    rollIndex += 2;
                }
                else
                {
                    gameScore += BowlThrows[rollIndex] + BowlThrows[rollIndex + 1];
                    rollIndex += 2;
                }
            }


            return gameScore;
        }

        public void ThrowBowling(int firstThrow, int secondThrow)
        {
            BowlThrows[CurrentFrame] = firstThrow;
            CurrentFrame++;
            BowlThrows[CurrentFrame] = secondThrow;
            CurrentFrame++;

        }

        private bool IsSpare(int firstThrow, int secondThrow)
        {
            return (firstThrow + secondThrow) == 10;
        }

        private bool IsStrike(int bowlThrow)
        {
            return bowlThrow == 10;
        }

    }
}
