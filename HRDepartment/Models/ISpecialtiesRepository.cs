using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDepartment
{
    public interface ISpecialtiesRepository : IRepository<Specialty>
    {
        Specialty GetSpecialty(int count);
    }
}
