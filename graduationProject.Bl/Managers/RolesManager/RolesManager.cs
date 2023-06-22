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
        private readonly IRepository<Role_Privileges> _rolesRepository;
        public RolesManager(RoleManager<Role> roleManager, IRepository<Role_Privileges> rolesRepository)
        {
            _roleManager = roleManager;
            _rolesRepository = rolesRepository;
        }

        public async Task<RoleWriteDTO> AddAsync(RoleWriteDTO entity)
        {
            List<Role_Privileges> role_Privileges = new List<Role_Privileges>();

            foreach(var item in entity.RolePrivileges)
            {
                role_Privileges.Add(new()
                {
                    PrivilegeId= item.PrivilegeId,
                    AddPermission = item.Permissions[0],
                    ViewPermission = item.Permissions[1],
                    EditPermission = item.Permissions[2],
                    DeletePermission = item.Permissions[3]
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
                var errorList = result.Errors.Select(r => r.Description).ToList();
                throw new Exception(errorList.FirstOrDefault());
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
                var errorList = result.Errors.Select(r => r.Description).ToList();
                throw new Exception(errorList.FirstOrDefault());
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
                AddedDate = r.Date,
                Permissions = r.RolePrivileges.Select(rp => new RolePrivilegesReadDTO()
                {
                    Id = rp.Id,
                    PrivilegeId = rp.PrivilegeId,
                    Permissions = new List<bool> { rp.AddPermission, rp.ViewPermission, rp.EditPermission, rp.DeletePermission }

                })
            });
            return result;
        }

        public async Task<RoleUpdateDTO> UpdateAsync(RoleUpdateDTO role)
        {
            var existingRole = _roleManager.Roles.Include(r => r.RolePrivileges).FirstOrDefault(r => r.Id == role.RoleId);

            if (existingRole == null)
            {
                throw new Exception("Role is Not Found");
            }

            _rolesRepository.DeleteRange(existingRole.RolePrivileges.ToList());

            _rolesRepository.AddRange(role.RolePrivileges.Select(rp => new Role_Privileges
            {
                RoleId = role.RoleId,
                PrivilegeId = rp.PrivilegeId,
                AddPermission = rp.Permissions[0],
                ViewPermission = rp.Permissions[1],
                EditPermission = rp.Permissions[2],
                DeletePermission = rp.Permissions[3]
            }).ToList());

            _rolesRepository.SaveChanges();

            existingRole.Name = role.RoleName;
            existingRole.NormalizedName = role.RoleName.ToUpper();

            var result = await _roleManager.UpdateAsync(existingRole);
            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(r => r.Description).ToList();
                throw new Exception(errorList.FirstOrDefault());
            }

            return role;
        }
    }
}
