using graduationProject.Bl.DTOs;
using graduationProject.Bl.Managers;
using graduationProject.DAL.Data.Models;
using graduationProject.DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace graduationProject.Bl.Managers
{
    public class RepresentativeManager : IRepresentativeManager
    {
        private readonly IRepository<Representative> _repository;
        private readonly IRepository<RepresentativeState> _staterepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public RepresentativeManager(IRepository<Representative> repository, UserManager<ApplicationUser> userManager, IRepository<RepresentativeState> staterepository)
        {
            _repository = repository;
            _userManager = userManager;
            _staterepository = staterepository;
        }
        public async Task<RepresentativeWriteDTO> AddAsync(RepresentativeWriteDTO entity)
        {
            ApplicationUser applicationUser = new()
            {
                UserName = entity.UserName,
                FullName = entity.FullName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address,
            };
            var result1 = await _userManager.CreateAsync(applicationUser, entity.Password);
            if (!result1.Succeeded)
            {
                var errorList = result1.Errors.Select(r => r.Description).ToList();
                throw new Exception(errorList.FirstOrDefault());
            }

            Representative newRepresentative = new()
            {
                Id = applicationUser.Id,
                ApplicationUserId = applicationUser.Id,
                BranchId = entity.BranchId,
                RepresentativeStates = entity.StatesId.Select(s=> new RepresentativeState
                {
                    StateId = s
                }).ToList(),
                DiscountType= entity.DiscountType,
                CompanyOrderRatio= entity.CompanyOrderRatio,
            };

            await _repository.AddAsync(newRepresentative);

            try
            {
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                await _userManager.DeleteAsync(applicationUser);
                throw new Exception("Failed to create Representative");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, newRepresentative.Id),
                new Claim(ClaimTypes.Role , "Representative"),
                new Claim(ClaimTypes.UserData,applicationUser.UserName),
            };

            await _userManager.AddClaimsAsync(applicationUser, claims);

            return entity;

        }

        public async Task<IEnumerable<RepresentativeReadDTO>> GetAllActiveAsync()
        {
            var representatives =  _repository.GetAllAsync(new[] { "ApplicationUser", "Branch" }).Result
                                                .Include(r=>r.RepresentativeStates)
                                                .ThenInclude(r=>r.State);

            var result = representatives
                .Where(r => r.ApplicationUser.Status == true)
                .Select(r => new RepresentativeReadDTO
                {
                    Id = r.Id,
                    UserName = r.ApplicationUser.UserName,
                    FullName = r.ApplicationUser.FullName,
                    Email = r.ApplicationUser.Email,
                    PhoneNumber = r.ApplicationUser.PhoneNumber,
                    Address = r.ApplicationUser.Address,
                    Branch = r.Branch.Name,
                    Status = r.ApplicationUser.Status,
                    Date = r.Date,
                    CompanyOrderRatio= r.CompanyOrderRatio,
                    DiscountType = r.DiscountType,
                    States = r.RepresentativeStates.Select(s=>new RepresentativeStateReadDTO
                    {
                        Id = s.Id,
                        State = s.State.Name
                    }).ToList(),
                });
            return result;
        }

        public async Task<IEnumerable<RepresentativeSimpleReadDTO>> GetAllActiveByStateIdAsync(int StateId)
        {
            var representatives = await _repository.GetAllAsync(new[] { "ApplicationUser", "RepresentativeStates" });

            var result = representatives
                .Where(r => r.ApplicationUser.Status == true
                && r.RepresentativeStates.Any(s => s.StateId == (byte)StateId))
                .Select(r => new RepresentativeSimpleReadDTO
                {
                    Id = r.Id,
                    FullName = r.ApplicationUser.FullName
                });
            return result;
        }

        public async Task<IEnumerable<RepresentativeReadDTO>> GetAllAsync()
        {
            var representatives = _repository.GetAllAsync(new[] { "ApplicationUser", "Branch" }).Result.Include(r => r.RepresentativeStates).ThenInclude(r => r.State);

            var result = representatives
                .Select(r => new RepresentativeReadDTO
                {
                    Id = r.Id,
                    UserName = r.ApplicationUser.UserName,
                    FullName = r.ApplicationUser.FullName,
                    Email = r.ApplicationUser.Email,
                    PhoneNumber = r.ApplicationUser.PhoneNumber,
                    Address = r.ApplicationUser.Address,
                    Branch = r.Branch.Name,
                    Status = r.ApplicationUser.Status,
                    Date = r.Date,
                    CompanyOrderRatio = r.CompanyOrderRatio,
                    DiscountType = r.DiscountType,
                    States = r.RepresentativeStates.Select(s => new RepresentativeStateReadDTO
                    {
                        Id = s.Id,
                        State = s.State.Name
                    }).ToList(),
                });

            return result;
        }

        public async Task<RepresentativeReadDTO> GetByApplicationUserIdAsync(string id)
        {
            var representative = _repository.GetAllAsync(new[] { "ApplicationUser", "Branch" }).Result
                                            .Include(r => r.RepresentativeStates)
                                            .ThenInclude(r => r.State)
                                            .FirstOrDefault(r=>r.ApplicationUserId == id);

            RepresentativeReadDTO result = new()
            {
                Id = representative.Id,
                UserName = representative.ApplicationUser.UserName,
                FullName = representative.ApplicationUser.FullName,
                Email = representative.ApplicationUser.Email,
                PhoneNumber = representative.ApplicationUser.PhoneNumber,
                Address = representative.ApplicationUser.Address,
                Branch = representative.Branch.Name,
                Status = representative.ApplicationUser.Status,
                Date = representative.Date,
                DiscountType = representative.DiscountType,
                CompanyOrderRatio = representative.CompanyOrderRatio,
                States= representative.RepresentativeStates.Select(s => new RepresentativeStateReadDTO
                {
                    Id = s.Id,
                    State = s.State.Name
                }).ToList(),
            };
            return result;
        }

        public async Task<RepresentativeReadDTO> GetByIdAsync(string id)
        {
            var representative = _repository.GetAllAsync(new[] { "ApplicationUser", "Branch" }).Result
                                            .Include(r => r.RepresentativeStates)
                                            .ThenInclude(r => r.State)
                                            .FirstOrDefault(r => r.ApplicationUserId == id);

            RepresentativeReadDTO result = new()
            {
                Id = representative.Id,
                UserName = representative.ApplicationUser.UserName,
                FullName = representative.ApplicationUser.FullName,
                Email = representative.ApplicationUser.Email,
                PhoneNumber = representative.ApplicationUser.PhoneNumber,
                Address = representative.ApplicationUser.Address,
                Branch = representative.Branch.Name,
                Status = representative.ApplicationUser.Status,
                Date = representative.Date,
                DiscountType = representative.DiscountType,
                CompanyOrderRatio = representative.CompanyOrderRatio,
                States = representative.RepresentativeStates.Select(s => new RepresentativeStateReadDTO
                {
                    Id = s.Id,
                    State = s.State.Name
                }).ToList(),
            };
            return result;
        }

        public async Task<RepresentativeUpdateStatusDTO> UpdateStatusAsync(RepresentativeUpdateStatusDTO entity)
        {
            var oldApplicationUser = await _userManager.FindByIdAsync(entity.Id);
            if (oldApplicationUser == null)
            {
                throw new Exception("Failed to find user");
            }
            oldApplicationUser.Status = entity.Status;

            var result = await _userManager.UpdateAsync(oldApplicationUser);

            if (!result.Succeeded)
            {
                throw new Exception("Failed to update user");
            }
            return entity;
        }

        public async Task<RepresentativeUpdateDTO> UpdateAsync(RepresentativeUpdateDTO entity)
        {
            var oldApplicationUser = await _userManager.FindByIdAsync(entity.Id);

            if (oldApplicationUser == null)
            {
                throw new Exception("Failed to find user");
            }

            oldApplicationUser.UserName = entity.UserName;
            oldApplicationUser.FullName = entity.FullName;
            oldApplicationUser.Email = entity.Email;
            oldApplicationUser.PhoneNumber = entity.PhoneNumber;
            oldApplicationUser.Address = entity.Address;
            if (!string.IsNullOrEmpty(entity.Password))
                oldApplicationUser.PasswordHash = _userManager.PasswordHasher.HashPassword(oldApplicationUser, entity.Password);

            var result = await _userManager.UpdateAsync(oldApplicationUser);

            if (!result.Succeeded)
            {
                throw new Exception("Failed to update user");
            }

            Representative updatedRepresentative = await _repository.GetByCriteriaAsync(r => (r.Id == entity.Id), new[] { "RepresentativeStates" });

            _staterepository.DeleteRange(updatedRepresentative.RepresentativeStates.ToList());
           
            _staterepository.AddRange(entity.States.Select(s => new RepresentativeState
            {
                RepresentativeId = entity.Id,
                StateId = s.StateId
            }).ToList());

            updatedRepresentative.BranchId = entity.BranchId;
            updatedRepresentative.DiscountType = entity.DiscountType;
            updatedRepresentative.CompanyOrderRatio = entity.CompanyOrderRatio;

            #region update claims 

            var existingClaims = await _userManager.GetClaimsAsync(oldApplicationUser);

            var existingUserDataClaim = (await _userManager.GetClaimsAsync(oldApplicationUser)).FirstOrDefault(c => c.Type == ClaimTypes.UserData);

            await _userManager.ReplaceClaimAsync(oldApplicationUser, existingUserDataClaim, new Claim(ClaimTypes.UserData, oldApplicationUser.UserName.ToString()));

            #endregion

            await _repository.UpdateAsync(updatedRepresentative);
            _repository.SaveChanges();

            return entity;
        }
    }
}
