using graduationProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class RolePrivilegesReadDTO
    {
        public int Id { get; set; }
        public byte PrivilegeId { get; set; }
        public List<bool>? Permissions { get; set; } = new List<bool>();
      
    }
}
