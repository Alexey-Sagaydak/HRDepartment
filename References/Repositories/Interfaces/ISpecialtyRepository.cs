using CommonClasses;
using System.Collections.Generic;

namespace References
{
    public interface ISpecialtyRepository
    {
        Specialty AddSpecialty(string specialty);
        void DeleteSpecialty(Specialty specialty);
        void SaveChanges();
        List<Specialty> GetSpecialties();
    }
}