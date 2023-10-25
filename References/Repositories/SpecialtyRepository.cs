using CommonClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References
{
    public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
    {
        private DBContext DBContext => Context as DBContext;

        public SpecialtyRepository(DBContext dBContext) : base(dBContext) { }

        public List<Specialty> GetSpecialties()
        {
            return DBContext.specialties.ToList();
        }

        public Specialty AddSpecialty(string specialty)
        {
            int maxId = DBContext.specialties.Any() ? DBContext.specialties.Max(s => s.Id) : 0;

            Specialty newSpecialty = new Specialty
            {
                Id = maxId + 1,
                Name = specialty
            };

            DBContext.specialties.Add(newSpecialty);

            return newSpecialty;
        }

        public void DeleteSpecialty(Specialty specialty)
        {
            DBContext.specialties.Remove(specialty);
        }
        
        public void SaveChanges()
        {
            DBContext.SaveChanges();
        }
    }
}
