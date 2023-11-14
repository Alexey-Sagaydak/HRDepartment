using System.Collections.Generic;

namespace CommonClasses
{
    public interface IEduInstitutionsRepository
    {
        EduInstitution AddEduInstitution(string eduInstitution);
        void DeleteEduInstitution(EduInstitution specialty);
        List<EduInstitution> GetEduInstitutions();
        List<EduInstitution> GetEduInstitutionsLike(string pattern);
        void SaveChanges();
    }
}