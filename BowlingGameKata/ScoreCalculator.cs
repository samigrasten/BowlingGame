using System.Collections.Generic;
using System.Linq;
using BowlingGameKata.ScoringRules;

namespace BowlingGameKata
{
    internal class ScoreCalculator
    {
        public int CalculateScore(FrameManager frameManager)
        {
            return Enumerable.Range(1, BowlingGame.MaxPinCount)
                .Select(frameManager.GetFrame)
                .Select((frame, round) =>
                {
                    var rule = _rules.First(r => r.Test(frame, round));
                    return rule.Calculate(frame, frameManager.GetFrame(round+2), frameManager.GetFrame(round+3), round);
                })
                .Sum();
        }

        private readonly List<IScoreRule> _rules = new List<IScoreRule> {
            
            new SpareRule(),
            new FallbackRule()
        };
    }
}