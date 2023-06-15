using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class RolePrivilegesWriteDTO
    {
        public string RoleId { get; set; } = string.Empty;
        public byte PrivilegeId { get; set; }
        public bool AddPermission { get; set; } = false;
        public bool EditPermission { get; set; } = false;
        public bool DeletePermission { get; set; } = false; 
        public bool ViewPermission { get; set; } = false;
    }
}
