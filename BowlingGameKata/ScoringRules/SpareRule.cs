namespace BowlingGameKata.ScoringRules
{
    internal class SpareRule : IScoreRule
    {
        public bool Test(Frame frame, int round) => frame.RollCount == 2 && frame.Sum == BowlingGame.MaxPinCount;
        public int Calculate(Frame frame, Frame nextFrame1, Frame nextFrame2, int round) => frame.Sum + nextFrame1.Sum;
    }
}