namespace BowlingGameKata.ScoringRules
{
    internal interface IScoreRule
    {
        bool Test(Frame frame, int round);
        int Calculate(Frame frame, Frame nextFrame1, Frame nextFrame2, int round);
    }
}