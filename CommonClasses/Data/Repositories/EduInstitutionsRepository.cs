using CommonClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class EduInstitutionsRepository : Repository<EduInstitution>, IEduInstitutionsRepository
    {
        private DBContext DBContext => Context as DBContext;

        public EduInstitutionsRepository(DBContext dBContext) : base(dBContext) { }

        public List<EduInstitution> GetEduInstitutions()
        {
            return DBContext.educational_institutions.ToList();
        }

        public List<EduInstitution> GetEduInstitutionsLike(string pattern)
        {
            return DBContext.educational_institutions.Where(data => data.Name.Contains(pattern)).ToList();
        }

        public EduInstitution AddEduInstitution(string eduInstitution)
        {
            int maxId = DBContext.educational_institutions.Any() ? DBContext.educational_institutions.Max(s => s.Id) : 0;

            EduInstitution newEduInstitution = new EduInstitution
            {
                Id = maxId + 1,
                Name = eduInstitution
            };

            DBContext.educational_institutions.Add(newEduInstitution);

            return newEduInstitution;
        }

        public void DeleteEduInstitution(EduInstitution eduInstitution)
        {
            DBContext.educational_institutions.Remove(eduInstitution);
        }

        public void SaveChanges()
        {
            DBContext.SaveChanges();
        }
    }
}
