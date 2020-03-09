namespace BowlingGameKata.ScoringRules
{
    internal class FallbackRule : IScoreRule
    {
        public bool Test(Frame frame, int round) => true;
        public int Calculate(Frame frame, Frame nextFrame1, Frame nextFrame2, int round) => frame.Sum;
    }
}