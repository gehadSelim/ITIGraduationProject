using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class RolePrivilegesUpdateDTO
    {
        public int Id { get; set; }
        public string RoleId { get; set; } = string.Empty;
        public byte PrivilegeId { get; set; }
        public bool AddPermission { get; set; } 
        public bool EditPermission { get; set; } 
        public bool DeletePermission { get; set; } 
        public bool ViewPermission { get; set; } 
    }
}
