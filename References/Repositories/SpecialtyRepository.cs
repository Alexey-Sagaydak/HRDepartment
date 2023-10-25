using CommonClasses;
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

        public void AddSpecialty(Specialty specialty)
        {
            DBContext.specialties.Add(specialty);
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
