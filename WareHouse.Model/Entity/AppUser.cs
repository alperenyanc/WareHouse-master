using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Model.Enum;

namespace WareHouse.Model.Entity
{
    public class AppUser:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }
        public Gender Gender { get; set; }
    }
}
