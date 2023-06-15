using Microsoft.AspNetCore.Identity;

namespace graduationProject.DAL.Data.Models
{
    public class Role : IdentityRole
    {
        public Role(string name) : base(name) { }

        public virtual ICollection<Role_Privileges>? RolePrivileges { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

    }
}