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
        public virtual DbSet<AuthData> hr_app_users { get; set; }
        public virtual DbSet<Employee> employees { get; set; }
        public virtual DbSet<Passport> passports { get; set; }
        public virtual DbSet<EduDocument> edu_documents { get; set; }
        public virtual DbSet<Workplace> places_of_work { get; set; }
        public virtual DbSet<Order> orders { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Employee>()
                .Property(e => e.AcademicTitle)
                .HasConversion<string>(); // Преобразование ENUM в строку

            modelBuilder
                .Entity<Employee>()
                .Property(e => e.AcademicDegree)
                .HasConversion<string>(); // Преобразование ENUM в строку

            modelBuilder
                .Entity<Passport>()
                .Property(e => e.Gender)
                .HasConversion<string>(); // Преобразование ENUM в строку
        }
    }
}
