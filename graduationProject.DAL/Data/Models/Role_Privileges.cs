using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL.Data.Models
{
    public class Role_Privileges
    {
        public int Id { get; set; }

        [ForeignKey("Role")]
        public string RoleId { get; set; } = string.Empty;
        public virtual Role? Role { get; set; }

        [ForeignKey("Privilege")]
        public byte PrivilegeId { get; set; }
        public virtual Privilege? Privilege { get; set; }
        public bool AddPermission { get; set; } = false;
        public bool EditPermission { get; set; } = false;
        public bool DeletePermission { get; set; } = false;
        public bool ViewPermission { get; set; } = false;


    }
}
