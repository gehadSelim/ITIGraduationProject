﻿using graduationProject.Bl.DTOs;
using graduationProject.DAL;
using graduationProject.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IRepository<Employee> _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmployeeManager(IRepository<Employee> repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<EmployeeWriteDTO> AddAsync(EmployeeWriteDTO entity)
        {
            ApplicationUser applicationUser = new()
            {
                FullName = entity.FullName, 
                UserName = entity.UserName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address,
            };
            var result1 = await _userManager.CreateAsync(applicationUser, entity.Password);
            if (!result1.Succeeded)
            {
                var errorList = result1.Errors.Select(e => e.Description).ToList();
                throw new Exception(errorList.FirstOrDefault());
            }

            Employee newEmployee = new()
            {
                Id = applicationUser.Id,
                ApplicationUserId = applicationUser.Id,
                RoleId = entity.RoleId,
                BranchId = entity.BranchId
            };

           
            await _repository.AddAsync(newEmployee);


            try
            {
                _repository.SaveChanges();
            }
            catch
            {
                await _userManager.DeleteAsync(applicationUser);
                throw new Exception("Failed to create Employee");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, newEmployee.Id),
                new Claim(ClaimTypes.UserData,applicationUser.UserName),
                new Claim(ClaimTypes.Role, newEmployee.RoleId),
            };

            await _userManager.AddClaimsAsync(applicationUser, claims);
            return entity;
        }

        public async Task<IEnumerable<EmployeeReadDTO>> GetAllActiveAsync()
        {
            var employees = await _repository.GetAllAsync(new[] {"Role", "ApplicationUser", "Branch" });
            
            var result = employees
                .Where(e => e.ApplicationUser.Status == true)
                .Select(e => new EmployeeReadDTO
                {
                    Id = e.Id,
                    FullName = e.ApplicationUser.FullName,
                    UserName = e.ApplicationUser.UserName,
                    Email = e.ApplicationUser.Email,
                    PhoneNumber = e.ApplicationUser.PhoneNumber,
                    Address = e.ApplicationUser.Address,
                    Branch = e.Branch.Name,
                    Status = e.ApplicationUser.Status,
                    Date = e.Date,
                    RoleName = e.Role.Name
                });
            return result;
        }

        public async Task<IEnumerable<EmployeeReadDTO>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync(new[] { "Role", "ApplicationUser", "Branch" });

            var result = employees
                .Select(e => new EmployeeReadDTO
                {
                    Id = e.Id,
                    UserName = e.ApplicationUser.UserName,
                    FullName = e.ApplicationUser.FullName,
                    Email = e.ApplicationUser.Email,
                    PhoneNumber = e.ApplicationUser.PhoneNumber,
                    Address = e.ApplicationUser.Address,
                    Branch = e.Branch.Name,
                    Status = e.ApplicationUser.Status,
                    Date = e.Date,
                    RoleName = e.Role.Name
                });
            return result;
        }

        public async Task<EmployeeReadDTO> GetByApplicationUserIdAsync(string id)
        {
            var employee = await _repository.GetByCriteriaAsync(e => (e.ApplicationUserId == id), new[] { "Role", "ApplicationUser", "Branch" });

            EmployeeReadDTO result = new()
            {
                Id = employee.Id,
                UserName = employee.ApplicationUser.UserName,
                FullName = employee.ApplicationUser.FullName,
                Email = employee.ApplicationUser.Email,
                PhoneNumber = employee.ApplicationUser.PhoneNumber,
                Address = employee.ApplicationUser.Address,
                Branch = employee.Branch.Name,
                Status = employee.ApplicationUser.Status,
                Date = employee.Date,
                RoleName = employee.Role.Name
            };
            return result;
        }

        public async Task<EmployeeReadDTO> GetByIdAsync(string id)
        {
            var employee = await _repository.GetByCriteriaAsync( e => (e.Id == id) ,new[] { "Role", "ApplicationUser", "Branch" });

            EmployeeReadDTO result = new()
            {
                Id = employee.Id,
                UserName = employee.ApplicationUser.UserName,
                FullName = employee.ApplicationUser.FullName,
                Email = employee.ApplicationUser.Email,
                PhoneNumber = employee.ApplicationUser.PhoneNumber,
                Address = employee.ApplicationUser.Address,
                Branch = employee.Branch.Name,
                Status = employee.ApplicationUser.Status,
                Date = employee.Date,
                RoleName = employee.Role.Name
            };
            return result;
        }

        public async Task<EmployeeUpdateDTO> UpdateAsync(EmployeeUpdateDTO entity)
        {
            var oldApplicationUser = await _userManager.FindByIdAsync(entity.Id);

            if(oldApplicationUser == null)
            {
                throw new Exception("Failed to find user");
            }

            oldApplicationUser.UserName = entity.UserName;
            oldApplicationUser.FullName = entity.FullName;
            oldApplicationUser.Email = entity.Email;
            oldApplicationUser.PhoneNumber = entity.PhoneNumber;
            oldApplicationUser.Address = entity.Address;
            oldApplicationUser.Status= entity.Status;
            oldApplicationUser.PasswordHash = _userManager.PasswordHasher.HashPassword(oldApplicationUser, entity.Password);

            var result = await _userManager.UpdateAsync(oldApplicationUser);

            if (!result.Succeeded)
            {
                throw new Exception("Failed to update user");
            }

            Employee updatedEmployee = await _repository.GetByCriteriaAsync(e => (e.Id == entity.Id));

            updatedEmployee.BranchId = entity.BranchId;
            updatedEmployee.RoleId = entity.RoleId;

            #region update claims 

            var existingRoleIdClaim = (await _userManager.GetClaimsAsync(oldApplicationUser)).FirstOrDefault(c => c.Type == ClaimTypes.Role);

            await _userManager.ReplaceClaimAsync(oldApplicationUser, existingRoleIdClaim, new Claim(ClaimTypes.Role, entity.RoleId.ToString()));
       
            var existingUserDataClaim = (await _userManager.GetClaimsAsync(oldApplicationUser)).FirstOrDefault(c => c.Type == ClaimTypes.UserData);

            await _userManager.ReplaceClaimAsync(oldApplicationUser, existingUserDataClaim, new Claim(ClaimTypes.UserData, entity.UserName.ToString()));

            #endregion

            await _repository.UpdateAsync(updatedEmployee);
            _repository.SaveChanges();

            return entity;

        }

        public async Task<IEnumerable<RolePrivilegesValidateDTO>> GetRolePrivilegesByUserId(string userId)
        {
            var employee = _repository.GetAllAsync().Result
                                      .Where(e => e.Id == userId)
                                      .Include(e => e.Role)
                                      .ThenInclude(r => r.RolePrivileges)
                                      .ThenInclude(rp => rp.Privilege)
                                      .FirstOrDefault();

            var permissions = employee.Role.RolePrivileges.Select(r => new RolePrivilegesValidateDTO
            {
                Id = r.Id,
                PermissionName = r.Privilege.Name,
                Permissions = new List<bool>()
                {
                    r.AddPermission,
                    r.ViewPermission,
                    r.EditPermission,
                    r.DeletePermission
                }
            }).ToList();

            return permissions;

        }
    }
}