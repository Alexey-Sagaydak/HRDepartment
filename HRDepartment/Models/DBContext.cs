using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HRDepartment
{
    public class DBContext : DbContext
    {
        public virtual DbSet<Specialty> specialties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Host=localhost;Port=5432;Username=admin;Password=admin;Database=HRDepartmentDB;";

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
