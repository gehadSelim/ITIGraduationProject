using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL.Data.Models
{
    public class Employee
    {
        public string Id { get; set; } = string.Empty;

        [ForeignKey("Role")]
        public string RoleId { get; set; } = string.Empty;
        public virtual Role? Role { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; } = string.Empty;
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey("Branch")]
        public byte BranchId { get; set; }
        public virtual Branch? Branch { get; set; }

    }
}
