namespace BowlingGame
{
    public class Game
    {
        private const int MaxRollsInBowling = 21;
        private readonly int[] _rolls = new int[MaxRollsInBowling];
        private int _currentRoll;

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            const int framesInBowling = 10;
            int score = 0;
            int frameIndex = 0;

            for (int i = 0; i < framesInBowling; i++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + BonusForStrike(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + BonusForSpare(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfPinsInAFrame(frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }

        private bool IsSpare(int frameIndex)
        {
            return SumOfPinsInAFrame(frameIndex) == 10;
        }

        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }

        private int SumOfPinsInAFrame(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        private int BonusForSpare(int frameIndex)
        {
            return _rolls[frameIndex + 2];
        }

        private int BonusForStrike(int frameIndex)
        {
            return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }
    }
}
