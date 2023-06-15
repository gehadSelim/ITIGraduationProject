using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class RolePrivilegesValidateDTO
    {
        public int Id { get; set; }
        public string PermissionName { get; set; } = string.Empty;
        public List<bool>? Permissions { get; set; } = new List<bool>();
    }
}
