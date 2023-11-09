using CommonClasses;
using System.Collections.Generic;

namespace CommonClasses
{
    public interface ISpecialtyRepository
    {
        Specialty AddSpecialty(string specialty);
        void DeleteSpecialty(Specialty specialty);
        void SaveChanges();
        List<Specialty> GetSpecialties();
        List<Specialty> GetSpecialtiesLike(string pattern);
    }
}