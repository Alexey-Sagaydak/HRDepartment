using System.Collections.Generic;

namespace CommonClasses
{
    public interface IDivisionsRepository
    {
        Division AddDivision(string division);
        void DeleteDivision(Division division);
        List<Division> GetDivisions();
        List<Division> GetDivisionsLike(string pattern);
        void SaveChanges();
    }
}