namespace TddTennisScore
{
    public interface IRepository<T>
    {
        Game GetGame(int gameId);
    }
}