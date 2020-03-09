using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata.Policies
{
    internal class FramePolicy
    {
        public bool ShouldStartNewFrame(Frame frame)
            => _rules.Any(rule => rule(frame));

        private readonly List<Predicate<Frame>> _rules = new List<Predicate<Frame>> {
            frame => frame.Sum == BowlingGame.MaxPinCount,
            frame => frame.RollCount == 2
        };
    }
}