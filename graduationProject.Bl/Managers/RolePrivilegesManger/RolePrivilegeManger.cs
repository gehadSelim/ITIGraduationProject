using graduationProject.Bl.DTOs;
using graduationProject.DAL;
using graduationProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public class RolePrivilegeManger : IRolePrivilegesManger
    {
        private readonly IRepository<Role_Privileges> _repository;
        public RolePrivilegeManger(IRepository<Role_Privileges> repository)
        {
            _repository= repository;
        }
        public async Task<IEnumerable<RolePrivilegesReadDTO>> GetRolePrivilegesByRoleId(string roleId)
        {
            var privileges = await _repository.GetAllAsync(new[] { "Privilege" });
            var result = privileges.Where(pr=>pr.RoleId == roleId).Select(pr=> new RolePrivilegesReadDTO{
                Id= pr.Id,
                PermissionName = pr.Privilege.Name,
                Permissions = new List<bool>()
                {
                    pr.AddPermission ,
                    pr.ViewPermission,
                    pr.EditPermission,
                    pr.DeletePermission
                }
            }).ToList();

            return result;
        }
    }
}
