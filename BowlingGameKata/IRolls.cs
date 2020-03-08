namespace BowlingGameKata
{
    public interface IScore
    {
        int Points { get; }
        bool IsReady();
        IScore Add(int count);
    }
}