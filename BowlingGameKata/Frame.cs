using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata
{
    internal class Frame 
    {
        public void Roll(int count) => _rolls.Add(count);

        public int RollCount => _rolls.Count;

        public int Sum => _rolls.Sum();

        private List<int> _rolls = new List<int>();
    }
}