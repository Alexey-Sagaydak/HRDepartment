using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class EduDocument
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("employee_id")]
        public long EmployeeId { get; set; }

        [Column("edu_document_type_id")]
        public long EduDocumentTypeId { get; set; }

        [Column("edu_institution_id")]
        public long EduInstitutionId { get; set; }

        [Column("specialty_id")]
        public long? SpecialtyId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("middle_name")]
        public string MiddleName { get; set; }

        [Column("is_with_honors")]
        public bool IsWithHonors { get; set; }

        [Column("series")]
        public string? Series { get; set; }

        [Column("number")]
        public string? Number { get; set; }

        [Column("reg_number")]
        public string? RegistrationNumber { get; set; }

        [Column("date_of_issue")]
        public DateTime DateOfIssue { get; set; }
    }

}
