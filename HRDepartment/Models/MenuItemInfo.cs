using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDepartment
{
    public class MenuItemInfo
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string? DLLName { get; set; }
        public string? ClassName { get; set; }
        public int OrderNumber { get; set; }
        
        public MenuItemInfo(int id, int parentId, string name, string? dLLName, string? className, int orderNumber)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
            DLLName = dLLName;
            ClassName = className;
            OrderNumber = orderNumber;
        }
    }
}
