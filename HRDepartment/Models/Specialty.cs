using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDepartment
{
    public class Specialty
    {
        public int id { get; set; }
        public string name { get; set; }

        public Specialty(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
