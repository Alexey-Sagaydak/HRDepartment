using CommonClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class PositionsRepository : Repository<Position>, IPositionsRepository
    {
        private DBContext DBContext => Context as DBContext;

        public PositionsRepository(DBContext dBContext) : base(dBContext) { }

        public List<Position> GetPositions()
        {
            return DBContext.positions.ToList();
        }

        public List<Position> GetPositionsLike(string pattern)
        {
            return DBContext.positions.Where(data => data.Name.Contains(pattern)).ToList();
        }

        public Position AddPosition(string position)
        {
            int maxId = DBContext.positions.Any() ? DBContext.positions.Max(s => s.Id) : 0;

            Position newPosition = new Position
            {
                Id = maxId + 1,
                Name = position
            };

            DBContext.positions.Add(newPosition);

            return newPosition;
        }

        public void DeletePosition(Position position)
        {
            DBContext.positions.Remove(position);
        }

        public void SaveChanges()
        {
            DBContext.SaveChanges();
        }
    }
}
