using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGameKata
{
    public class BowlingGame
    {
        public BowlingGame()
        {
            _currentFrame = new Frame(1);
            _frames = new Dictionary<int, IFrame>();
            _frames[_currentFrame.Round] = _currentFrame;
        }

        public void Roll(int count)
        {
            count.AssertIsPositive();
            count.AssertIsLessOrEqual(MaxPinCount);

            _currentFrame.Roll(count);
            _currentFrame = _currentFrame.ResolveNextFrame();
            _frames[_currentFrame.Round] = _currentFrame;
        }

        public int Score() => _frames.Values.Sum(frame => frame.Score);
        
        public const int MaxPinCount = 10;
        private IFrame _currentFrame;
        private Dictionary<int, IFrame> _frames;
    }

    internal class Frame : IFrame
    {
        public Frame(int round)
        {
            Round = round;
            _score = new OpenScores(this);
        }

        public void Roll(int count) => _score = _score.Add(count);

        public IFrame ResolveNextFrame()
        {
            if (!_score.IsReady()) return this;

            NextFrame = new Frame(Round + 1);
            return NextFrame;
        }

        public int Score => _score.Points;
        public int Round { get; private set; }

        public IFrame NextFrame { get; private set; } = new VoidFrame();
        private IScore _score { get; set; }
    }

    public interface IFrame
    {
        void Roll(int count);
        IFrame ResolveNextFrame();
        int Score { get; }
        int Round { get; }
        IFrame NextFrame { get; }
    }

    public abstract class Score
    {
        public IScore Add(int score)
        {
            _rolls.Add(score);
            return _rolls.Count() == 2 && Points == BowlingGame.MaxPinCount
                ?  new SpareScores(Frame, _rolls)
                : (IScore) this;
        }

        public virtual int Points => _rolls.Sum();
        protected IFrame Frame { get; set; }
        protected List<int> _rolls = new List<int>();
    }

    public class OpenScores : Score, IScore
    {
        public OpenScores(IFrame frame)
        {
            Frame = frame;
        }

        public bool IsReady() => _rolls.Count == 2;
    }

    public class SpareScores : Score, IScore
    {
        public SpareScores(IFrame frame, List<int> rolls)
        {
            Frame = frame;
            _rolls = rolls;
        }

        public bool IsReady() => true;

        public override int Points
        {
            get => _rolls.Sum() + Frame.NextFrame.Score;
        }
    }
}