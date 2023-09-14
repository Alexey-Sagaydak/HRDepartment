using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRDepartment
{
    public class SpecialtiesRepository : Repository<Specialty>, ISpecialtiesRepository
    {
        private DBContext DBContext => Context as DBContext;
        public SpecialtiesRepository(DBContext dBContext) : base(dBContext) { }
        public Specialty GetSpecialty(int s_id)
        {
            return DBContext.specialties.SingleOrDefault(a => a.id == s_id);
        }
    }
}
