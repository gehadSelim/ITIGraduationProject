using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL.Data.Models
{
    public class Privilege
    {
        public byte Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string ArabicName { get; set; } = string.Empty;

        public virtual ICollection<Role_Privileges>? RolePrivileges { get; set; }
    }
}
