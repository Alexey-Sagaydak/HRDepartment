using CommonClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class EduDocumentTypesRepository : Repository<EduDocumentType>, IEduDocumentTypesRepository
    {
        private DBContext DBContext => Context as DBContext;

        public EduDocumentTypesRepository(DBContext dBContext) : base(dBContext) { }

        public List<EduDocumentType> GetEduDocumentTypes()
        {
            return DBContext.edu_document_types.ToList();
        }

        public List<EduDocumentType> GetEduInstitutionsLike(string pattern)
        {
            return DBContext.edu_document_types.Where(data => data.Name.Contains(pattern)).ToList();
        }

        public EduDocumentType AddEduInstitution(string eduDocumentType)
        {
            int maxId = DBContext.edu_document_types.Any() ? DBContext.edu_document_types.Max(s => s.Id) : 0;

            EduDocumentType newEduInstitution = new EduDocumentType
            {
                Id = maxId + 1,
                Name = eduDocumentType
            };

            DBContext.edu_document_types.Add(newEduInstitution);

            return newEduInstitution;
        }

        public void DeleteEduInstitution(EduDocumentType eduDocumentType)
        {
            DBContext.edu_document_types.Remove(eduDocumentType);
        }

        public void SaveChanges()
        {
            DBContext.SaveChanges();
        }
    }
}
