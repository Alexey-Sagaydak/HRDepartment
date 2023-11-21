using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class AccessRights : IAccessRights
    {
        public AccessRights(int userId, int menuItemId, bool read, bool wright, bool edit, bool delete)
        {
            UserId = userId;
            MenuItemId = menuItemId;
            Read = read;
            Write = wright;
            Edit = edit;
            Delete = delete;
        }

        public int UserId { get; set; }
        public int MenuItemId { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
    }
}
