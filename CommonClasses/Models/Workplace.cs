using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class Workplace
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("employee_id")]
        public long EmployeeId { get; set; }

        [Column("organization_id")]
        public long OrganizationId { get; set; }

        [Column("position_id")]
        public long PositionId { get; set; }

        [Column("kind_of_work")]
        public string? KindOfWork { get; set; }

        [Column("start_of_work")]
        public DateTime? StartOfWork { get; set; }

        [Column("end_of_work")]
        public DateTime? EndOfWork { get; set; }

        [Column("division_id")]
        public long DivisionId { get; set; }

        [Column("reason")]
        public string? Reason { get; set; }

        [Column("order_id")]
        public long? OrderId { get; set; }
        public Order? Order { get; set; }
    }

}
