using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class Order
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("employee_id")]
        public long? EmployeeId { get; set; }

        [Column("type_of_order_id")]
        public long TypeOfOrderId { get; set; }

        [Column("date_of_signing")]
        public DateTime DateOfSigning { get; set; }

        [Column("effective_date")]
        public DateTime EffectiveDate { get; set; }

        [Column("number_of_order")]
        public string NumberOfOrder { get; set; }
    }

}
