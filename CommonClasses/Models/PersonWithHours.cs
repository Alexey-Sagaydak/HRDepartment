using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class PersonWithHours
    {
        [Column("employee_id")]
        public int? Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("surname")]
        public string? Surname { get; set; }

        [Column("middle_name")]
        public string? MiddleName { get; set; }

        [Column("total_work_duration")]
        public int? Hours { get; set; }
    }
}
