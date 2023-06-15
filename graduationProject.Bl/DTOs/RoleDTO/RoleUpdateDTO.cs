using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class RoleUpdateDTO
    {
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public IEnumerable<RolePrivilegesUpdateDTO>? RolePrivileges { get; set; }
    }
}
