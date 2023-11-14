using CommonClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class OrganizationNamesRepository : Repository<OrganizationName>, IOrganizationNamesRepository
    {
        private DBContext DBContext => Context as DBContext;

        public OrganizationNamesRepository(DBContext dBContext) : base(dBContext) { }

        public List<OrganizationName> GetOrganizationNames()
        {
            return DBContext.organizations_names.ToList();
        }

        public List<OrganizationName> GetOrganizationNameLike(string pattern)
        {
            return DBContext.organizations_names.Where(data => data.Name.Contains(pattern)).ToList();
        }

        public OrganizationName AddOrganizationName(string organizationName)
        {
            int maxId = DBContext.organizations_names.Any() ? DBContext.organizations_names.Max(s => s.Id) : 0;

            OrganizationName newOrganizationName = new OrganizationName
            {
                Id = maxId + 1,
                Name = organizationName
            };

            DBContext.organizations_names.Add(newOrganizationName);

            return newOrganizationName;
        }

        public void DeleteOrganizationName(OrganizationName organizationName)
        {
            DBContext.organizations_names.Remove(organizationName);
        }

        public void SaveChanges()
        {
            DBContext.SaveChanges();
        }
    }
}
