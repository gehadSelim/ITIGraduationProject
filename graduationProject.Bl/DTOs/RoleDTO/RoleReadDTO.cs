using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class RoleReadDTO
    {
        public string? Id { get; set; }
        public string? RoleName { get; set; }
        public DateTime AddedDate { get; set; } 
        public IEnumerable<RolePrivilegesReadDTO>? Permissions { get; set; }
    }
}
