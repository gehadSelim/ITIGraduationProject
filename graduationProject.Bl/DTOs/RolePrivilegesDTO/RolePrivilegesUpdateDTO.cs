using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class RolePrivilegesUpdateDTO
    {
        public byte PrivilegeId { get; set; }
        public List<bool>? Permissions { get; set; } = new List<bool>();

    }
}
