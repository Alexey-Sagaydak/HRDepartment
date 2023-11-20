using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CommonClasses
{
    public enum Gender
    {
        [Description("Мужской")]
        male = 0,

        [Description("Женский")]
        female = 1
    }
    
    public class Passport
    {
        public Passport(long employeeId)
        {
            Id = null;
            EmployeeId = employeeId;
            Name = string.Empty;
            Surname = string.Empty;
            MiddleName = string.Empty;
            DateOfBirth = new DateTime(2023, 11, 20, 12, 0, 0, DateTimeKind.Utc); ;
            PlaceOfBirth = string.Empty;
            DateOfIssue = new DateTime(2023, 11, 20, 12, 0, 0, DateTimeKind.Utc); ;
            PlaceOfIssue = null;
            Series = null;
            Number = null;
        }

        [Column("id")]
        public long? Id { get; set; }

        [Column("employee_id")]
        public long EmployeeId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("middle_name")]
        public string MiddleName { get; set; }

        [Column("gender")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("place_of_birth")]
        public string? PlaceOfBirth { get; set; }

        [Column("date_of_issue")]
        public DateTime? DateOfIssue { get; set; }

        [Column("place_of_issue")]
        public string? PlaceOfIssue { get; set; }

        [Column("series")]
        public int? Series { get; set; }

        [Column("number")]
        public int? Number { get; set; }
    }

}
