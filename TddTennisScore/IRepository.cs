using System.Collections.Generic;

namespace TddTennisScore
{
    public interface IRepository<T>
    {
        T GetGame(int id);
    }
}