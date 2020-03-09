using System.Collections.Generic;
using BowlingGameKata.Policies;

namespace BowlingGameKata
{
    internal class FrameManager
    {
        public FrameManager()
        {
            _currentFrame = new Frame();
            _round = 1;
            _framePolicy = new FramePolicy();
            _frames = new Dictionary<int, Frame>
            {
                [_round] = _currentFrame
            };
        }

        public Frame GetCurrentFrame()
        {
            if (!_framePolicy.ShouldStartNewFrame(_currentFrame)) return _currentFrame;

            _round++;
            _currentFrame = new Frame();
            _frames[_round] = _currentFrame;
            return _currentFrame;
        }

        public Frame GetFrame(int round)
            => _frames.ContainsKey(round)
                ? _frames[round]
                : new Frame();

        private Frame _currentFrame;
        private readonly Dictionary<int, Frame> _frames;
        private int _round;
        private readonly FramePolicy _framePolicy;
    }
}