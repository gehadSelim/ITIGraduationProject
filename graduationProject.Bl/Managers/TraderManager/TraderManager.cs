using graduationProject.Bl.DTOs;
using graduationProject.DAL;
using graduationProject.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public class TraderManager : ITraderManager
    {
        private readonly IRepository<Trader> _repository;
        private readonly IRepository<SpecialPackage> _sprepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TraderManager(IRepository<Trader> repository, UserManager<ApplicationUser> userManager, IRepository<SpecialPackage> sprepository)
        {
            _repository = repository;
            _userManager = userManager;
            _sprepository = sprepository;
        }

        public async Task<TraderWriteDTO> AddAsync(TraderWriteDTO entity)
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
                var errorList = result1.Errors.Select(t => t.Description).ToList();
                throw new Exception(errorList.FirstOrDefault());
            }

            List<SpecialPackage> specialPackages = new List<SpecialPackage>();

            if (entity.SpecialPackages != null)
            {
                foreach (var specialPackage in entity.SpecialPackages.DistinctBy(s => s.CityId))
                {

                    specialPackages.Add(new()
                    {
                        StateId = specialPackage.StateId,
                        CityId = specialPackage.CityId,
                        ShippingCost = specialPackage.ShippingCost,

                    });

                }
            }
            
            Trader newTrader = new()
            {
                Id = applicationUser.Id,
                ApplicationUserId = applicationUser.Id,
                BranchId = entity.BranchId,
                CityId = entity.CityId,
                StateId = entity.StateId,
                RejectedOrderlossRatio= entity.RejectedOrderlossRatio,
                StoreName = entity.StoreName,
                SpecialPackages= specialPackages,

            };

            await _repository.AddAsync(newTrader);

            try
            {
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                await _userManager.DeleteAsync(applicationUser);
                throw new Exception("Failed to create Trader");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, newTrader.Id),
                new Claim(ClaimTypes.Role , "Trader"),
                new Claim(ClaimTypes.UserData,applicationUser.UserName),
            };

            await _userManager.AddClaimsAsync(applicationUser, claims);


            return entity;
        }

        public void DeleteTraderSpecialPackages(int specialPackageId)
        {
            var specialPackage = _sprepository.GetByIdAsync(specialPackageId).Result;
            _sprepository.DeleteById(specialPackage);
            _sprepository.SaveChanges();
        }

        public async Task<IEnumerable<TraderReadDTO>> GetAllActiveAsync()
        {
            var traders = await _repository.GetAllAsync(new[] { "City", "State", "ApplicationUser", "Branch" , "SpecialPackages" });

            var result = traders
                .Where(t => t.ApplicationUser.Status == true)
                .Select(t => new TraderReadDTO
                {
                    Id = t.Id,
                    UserName = t.ApplicationUser.UserName,
                    FullName = t.ApplicationUser.FullName,
                    Email = t.ApplicationUser.Email,
                    PhoneNumber = t.ApplicationUser.PhoneNumber,
                    Address = t.ApplicationUser.Address,
                    Branch = new()
                    {
                        Id = t.Branch.Id,
                        Name= t.Branch.Name

                    },
                    Status = t.ApplicationUser.Status,
                    Date = t.Date,
                    RejectedOrderlossRatio = t.RejectedOrderlossRatio,
                    StoreName = t.StoreName,
                    City = new()
                    {
                        Id = t.City.Id,
                        Name = t.City.Name,
                    },
                    State = new()
                    {
                        Id = t.State.Id,
                        Name = t.State.Name
                    },
                    SpecialPackages = t.SpecialPackages.Select(s => new SpecialPackageReadDTO {
                        //Id = s.Id,
                        ShippingCost = s.ShippingCost,
                        City = s.City.Name,
                        State = s.State.Name
                    })
                });
            return result;
        }

        public async Task<IEnumerable<TraderReadDTO>> GetAllAsync()
        {
            var traders = await _repository.GetAllAsync(new[] { "City", "State", "ApplicationUser", "Branch" , "SpecialPackages" });

            var result = traders
                .Select(t => new TraderReadDTO
                {
                    Id = t.Id,
                    UserName = t.ApplicationUser.UserName,
                    FullName = t.ApplicationUser.FullName,
                    Email = t.ApplicationUser.Email,
                    PhoneNumber = t.ApplicationUser.PhoneNumber,
                    Address = t.ApplicationUser.Address,
                    Status = t.ApplicationUser.Status,
                    Date = t.Date,
                    RejectedOrderlossRatio = t.RejectedOrderlossRatio,
                    StoreName = t.StoreName,
                    Branch = new()
                    {
                        Id = t.Branch.Id,
                        Name = t.Branch.Name

                    },
                    City = new()
                    {
                        Id = t.City.Id,
                        Name = t.City.Name,
                    },
                    State = new()
                    {
                        Id = t.State.Id,
                        Name = t.State.Name
                    },
                    SpecialPackages = t.SpecialPackages.Select(s => new SpecialPackageReadDTO
                    {
                        ShippingCost = s.ShippingCost,
                        City = s.City.Name,
                        State = s.State.Name
                    })
                });
            return result;
        }

        public async Task<TraderReadDTO> GetByApplicationUserIdAsync(string id)
        {
            var trader = _repository.GetAllAsync(new[] { "City", "State", "ApplicationUser", "Branch" }).Result
                                    .Include(t => t.SpecialPackages)
                                    .ThenInclude(sp => sp.City)
                                    .ThenInclude(sp => sp.State)
                                    .Where(t => t.ApplicationUserId == id)
                                    .FirstOrDefault();

            var specialPackage = new List<SpecialPackageReadDTO>();

            if (trader.SpecialPackages != null)
            {
                specialPackage = trader.SpecialPackages.Select(s => new SpecialPackageReadDTO
                {
                    ShippingCost = s.ShippingCost,
                    City = s.City.Name,
                    State = s.State.Name

                }).ToList();
            }

            TraderReadDTO result = new()
            {
                Id = trader.Id,
                UserName = trader.ApplicationUser.UserName,
                FullName = trader.ApplicationUser.FullName,
                Email = trader.ApplicationUser.Email,
                PhoneNumber = trader.ApplicationUser.PhoneNumber,
                Address = trader.ApplicationUser.Address,
                Branch = new() { Id = trader.BranchId, Name = trader.Branch.Name},
                Status = trader.ApplicationUser.Status,
                Date = trader.Date,
                RejectedOrderlossRatio = trader.RejectedOrderlossRatio,
                StoreName = trader.StoreName,
                City = new() { Id = trader.CityId, Name = trader.City.Name },
                State = new() { Id = trader.StateId, Name = trader.State.Name },
                SpecialPackages = specialPackage
            };
            return result;
        }

        public async Task<TraderReadDTO> GetByIdAsync(string id)
        {
            var trader = _repository.GetAllAsync(new[] { "City", "State", "ApplicationUser", "Branch" }).Result
                                    .Include(t => t.SpecialPackages)
                                    .ThenInclude(sp => sp.City)
                                    .ThenInclude(sp => sp.State)
                                    .Where(t => t.Id == id)
                                    .FirstOrDefault();

            var specialPackage = new List<SpecialPackageReadDTO>();

            if(trader.SpecialPackages!= null)
            {
                specialPackage = trader.SpecialPackages.Select(s => new SpecialPackageReadDTO
                {
                    ShippingCost = s.ShippingCost,
                    City = s.City.Name,
                    State = s.State.Name

                }).ToList();
            }

            TraderReadDTO result = new()
            {
                Id = trader.Id,
                UserName = trader.ApplicationUser.UserName,
                FullName = trader.ApplicationUser.FullName,
                Email = trader.ApplicationUser.Email,
                PhoneNumber = trader.ApplicationUser.PhoneNumber,
                Address = trader.ApplicationUser.Address,
                Branch = new() { Id = trader.BranchId, Name = trader.Branch.Name },
                Status = trader.ApplicationUser.Status,
                Date = trader.Date,
                RejectedOrderlossRatio = trader.RejectedOrderlossRatio,
                StoreName = trader.StoreName,
                City = new() { Id = trader.CityId, Name = trader.City.Name },
                State = new() { Id = trader.StateId, Name = trader.State.Name },
                SpecialPackages = specialPackage
            };
            return result;
        }

        public async Task<double> GetShippingCostAsync(string Traderid, int Cityid)
        {
            var CitySpecialPackage = await _sprepository.GetByCriteriaAsync(t => t.TraderId == Traderid && t.CityId == Cityid);
            if(CitySpecialPackage is null) { return 0.0; }
            return CitySpecialPackage.ShippingCost;
        }

        public async Task<TraderUpdateStatusDTO> UpdateStatusAsync(TraderUpdateStatusDTO entity)
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

        public async Task<TraderUpdateDTO> UpdateAsync(TraderUpdateDTO entity)
        {
            var oldApplicationUser = await _userManager.FindByIdAsync(entity.Id);

            if (oldApplicationUser == null)
            {
                throw new Exception("Failed to find user");
            }

            oldApplicationUser.FullName= entity.FullName;
            oldApplicationUser.UserName = entity.UserName;
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

            Trader updatedTrader = await _repository.GetByCriteriaAsync(r => r.Id == entity.Id);

            _sprepository.DeleteRange(updatedTrader.SpecialPackages.ToList());

            _sprepository.AddRange(entity.SpecialPackages.Select(s => new SpecialPackage
            {
                TraderId = entity.Id,
                StateId = s.StateId,
                CityId = s.CityId,
                ShippingCost = s.ShippingCost
            }).ToList());

            updatedTrader.BranchId = entity.BranchId;
            updatedTrader.StateId = entity.StateId;
            updatedTrader.CityId = entity.CityId;
            updatedTrader.RejectedOrderlossRatio = entity.RejectedOrderlossRatio;
            updatedTrader.StoreName = entity.StoreName;

            #region update claims 

            var existingClaims = await _userManager.GetClaimsAsync(oldApplicationUser);

            var existingUserDataClaim = (await _userManager.GetClaimsAsync(oldApplicationUser)).FirstOrDefault(c => c.Type == ClaimTypes.UserData);

            await _userManager.ReplaceClaimAsync(oldApplicationUser, existingUserDataClaim, new Claim(ClaimTypes.UserData, oldApplicationUser.UserName.ToString()));

            #endregion

            await _repository.UpdateAsync(updatedTrader);
            _repository.SaveChanges();

            return entity;
        }


    }
}







