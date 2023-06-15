 using graduationProject.Bl.DTOs;
using graduationProject.DAL;
using graduationProject.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public class RolesManager : IRolesManager
    {
        private readonly RoleManager<Role> _roleManager;

        public RolesManager(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<RoleWriteDTO> AddAsync(RoleWriteDTO entity)
        {
            List<Role_Privileges> role_Privileges = new List<Role_Privileges>();

            foreach(var item in entity.RolePrivileges)
            {
                role_Privileges.Add(new()
                {
                    PrivilegeId= item.PrivilegeId,
                    AddPermission = item.AddPermission,
                    DeletePermission = item.DeletePermission,
                    EditPermission = item.EditPermission,
                    ViewPermission = item.ViewPermission
                });
            }

            Role role = new(entity.RoleName)
            {
                NormalizedName = entity.RoleName.ToUpper(),
                RolePrivileges = role_Privileges
            };

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                throw new Exception("Failed to create Role");
            }

            return entity;
        }

        public async Task<IdentityResult> DeleteAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                throw new Exception("Role is Not Found");
            }

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to Delete Role");
            }
            return result;
        }

        public IEnumerable<RoleReadDTO> GetAll()
        {
            var roles = _roleManager.Roles;

            var result = roles.Select(r => new RoleReadDTO
            {
                Id = r.Id,
                RoleName = r.Name,
                Permissions = r.RolePrivileges.Select(rp => new RolePrivilegesReadDTO()
                {
                    Id= rp.Id,
                    PermissionName = rp.Privilege.ArabicName,
                    Permissions = new List<bool> { rp.AddPermission , rp.ViewPermission , rp.EditPermission , rp.DeletePermission}

                })
            });
            return result;
        }

        public async Task<RoleUpdateDTO> UpdateAsync(RoleUpdateDTO role)
        {
            var existingRole = await _roleManager.FindByIdAsync(role.RoleId);
            if (existingRole == null)
            {
                throw new Exception("Role is Not Found");
            }

            List<Role_Privileges> role_Privileges = new List<Role_Privileges>();

            foreach (var item in role.RolePrivileges)
            {
                role_Privileges.Add(new()
                {
                    Id = item.Id,
                    PrivilegeId = item.PrivilegeId,
                    AddPermission = item.AddPermission,
                    DeletePermission = item.DeletePermission,
                    EditPermission = item.EditPermission,
                    ViewPermission = item.ViewPermission
                });
            }

            existingRole.Name = role.RoleName;
            existingRole.NormalizedName = role.RoleName.ToUpper();
            existingRole.RolePrivileges = role_Privileges;


            var result = await _roleManager.UpdateAsync(existingRole);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to Update Role");
            }

            return role;
        }
    }
}
