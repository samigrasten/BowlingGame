namespace BowlingGameKata
{
    internal class VoidFrame : IFrame
    {
        public int Score => 0;

        public int Round => 0;

        public IFrame ResolveNextFrame() => this;
        public IFrame NextFrame => this;

        public void Roll(int count) { }
    }
}