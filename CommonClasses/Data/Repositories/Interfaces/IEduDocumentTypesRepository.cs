using System.Collections.Generic;

namespace CommonClasses
{
    public interface IEduDocumentTypesRepository
    {
        EduDocumentType AddEduInstitution(string eduDocumentType);
        void DeleteEduInstitution(EduDocumentType eduDocumentType);
        List<EduDocumentType> GetEduDocumentTypes();
        List<EduDocumentType> GetEduInstitutionsLike(string pattern);
        void SaveChanges();
    }
}