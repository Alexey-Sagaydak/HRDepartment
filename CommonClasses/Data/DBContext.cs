using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using CommonClasses;

namespace CommonClasses
{
    public class DBContext : DbContext
    {
        public virtual DbSet<Specialty> specialties { get; set; }
        public virtual DbSet<AuthData> employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ReadStringFromFile(@"Resources\DBConnectionString.txt");

            optionsBuilder.UseNpgsql(connectionString);
        }

        private static string ReadStringFromFile(string filePath)
        {
            if (File.Exists(filePath))
                return File.ReadAllText(filePath);
            else
                throw new FileNotFoundException("Не найден файл со строкой подключения к БД", filePath);
        }
    }
}
