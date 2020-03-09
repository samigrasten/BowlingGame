using System.ComponentModel;
using System.Runtime.Versioning;
using System.Text;

namespace BowlingGameKata
{
    public class BowlingGame
    {
        public BowlingGame()
        {
            _frameManager = new FrameManager();
            _scoreCalculator = new ScoreCalculator();
        }

        public OperationResult Roll(int count)
        {
            if (count < 0) return OperationResult.Failed("Roll count must be positive");
            if (count > MaxPinCount) return OperationResult.Failed($"Roll count must be less than {MaxPinCount}");

            var currentFrame = _frameManager.GetCurrentFrame();
            currentFrame.Roll(count);
            return OperationResult.Success();
        }

        public const int MaxPinCount = 10;
        public int Score() => _scoreCalculator.CalculateScore(_frameManager);

        private readonly FrameManager _frameManager;
        private readonly ScoreCalculator _scoreCalculator;
    }
}