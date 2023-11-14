using CommonClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class DivisionsRepository : Repository<Division>, IDivisionsRepository
    {
        private DBContext DBContext => Context as DBContext;

        public DivisionsRepository(DBContext dBContext) : base(dBContext) { }

        public List<Division> GetDivisions()
        {
            return DBContext.divisions.ToList();
        }

        public List<Division> GetDivisionsLike(string pattern)
        {
            return DBContext.divisions.Where(data => data.Name.Contains(pattern)).ToList();
        }

        public Division AddDivision(string division)
        {
            int maxId = DBContext.edu_document_types.Any() ? DBContext.divisions.Max(s => s.Id) : 0;

            Division newDivision = new Division
            {
                Id = maxId + 1,
                Name = division
            };

            DBContext.divisions.Add(newDivision);

            return newDivision;
        }

        public void DeleteDivision(Division division)
        {
            DBContext.divisions.Remove(division);
        }

        public void SaveChanges()
        {
            DBContext.SaveChanges();
        }
    }
}
