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
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Windows.Controls;

namespace CommonClasses
{
    public class DBContext : DbContext
    {
        public virtual DbSet<Specialty> specialties { get; set; }
        public virtual DbSet<EduInstitution> educational_institutions { get; set; }
        public virtual DbSet<EduDocumentType> edu_document_types { get; set; }
        public virtual DbSet<Position> positions { get; set; }
        public virtual DbSet<Division> divisions { get; set; }
        public virtual DbSet<OrganizationName> organizations_names { get; set; }
        public virtual DbSet<AuthData> hr_app_users { get; set; }
        public virtual DbSet<Employee> employees { get; set; }
        public virtual DbSet<Passport> passports { get; set; }
        public virtual DbSet<EduDocument> edu_documents { get; set; }
        public virtual DbSet<Workplace> places_of_work { get; set; }
        public virtual DbSet<Order> orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Passport>()
                .Property(p => p.Gender)
                .HasConversion(
                    g => g.ToString(),           // Конвертация Enum в строку для сохранения в базе данных
                    g => (Gender)Enum.Parse(typeof(Gender), g)  // Конвертация строки из базы данных в Enum
                );

            modelBuilder
                .Entity<Employee>()
                .Property(e => e.AcademicTitle)
                .HasConversion<string>();

            modelBuilder
                .Entity<Employee>()
                .Property(e => e.AcademicDegree)
                .HasConversion<string>();
        }
    }
}
