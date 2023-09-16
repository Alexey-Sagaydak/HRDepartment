using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDepartment
{
    public class AuthData
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }
    }
}
