namespace TddTennisScore
{
    public interface IRepository<T>
    {
        T GetGame(int gameId);
    }
}