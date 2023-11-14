using System.Collections.Generic;

namespace CommonClasses
{
    public interface IOrganizationNamesRepository
    {
        OrganizationName AddOrganizationName(string organizationName);
        void DeleteOrganizationName(OrganizationName organizationName);
        List<OrganizationName> GetOrganizationNameLike(string pattern);
        List<OrganizationName> GetOrganizationNames();
        void SaveChanges();
    }
}