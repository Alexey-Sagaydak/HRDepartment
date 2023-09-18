using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDepartment
{
    public class AuthenticatorRepository : Repository<AuthData>, IAuthenticatorRepository
    {
        private DBContext DBContext => Context as DBContext;
        private PasswordHash passwordHash = new PasswordHash("3yYQv8xx5MjR63RFwWxLxaXR");

        public AuthenticatorRepository(DBContext dBContext) : base(dBContext) { }

        public int FindEmployee(string email, string password)
        {

            int id = DBContext.employees.Where(e => e.Email == email && e.PasswordHash == passwordHash.HashPassword(password))
                        .Select(e => e.Id)
                        .FirstOrDefault();
            return id;
        }

        public bool ChangePassword(int id, string previousPassword, string newPassword)
        {
            AuthData user = DBContext.employees.FirstOrDefault(u => u.Id == id);

            if (user != null && user.PasswordHash == passwordHash.HashPassword(previousPassword))
            {
                user.PasswordHash = passwordHash.HashPassword(newPassword);
                DBContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
