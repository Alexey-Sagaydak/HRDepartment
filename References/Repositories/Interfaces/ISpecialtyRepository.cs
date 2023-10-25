using CommonClasses;
using System.Collections.Generic;

namespace References
{
    public interface ISpecialtyRepository
    {
        void AddSpecialty(Specialty specialty);
        void DeleteSpecialty(Specialty specialty);
        void SaveChanges();
        List<Specialty> GetSpecialties();
    }
}