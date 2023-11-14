using System.Collections.Generic;

namespace CommonClasses
{
    public interface IPositionsRepository
    {
        Position AddPosition(string position);
        void DeletePosition(Position position);
        List<Position> GetPositions();
        List<Position> GetPositionsLike(string pattern);
        void SaveChanges();
    }
}