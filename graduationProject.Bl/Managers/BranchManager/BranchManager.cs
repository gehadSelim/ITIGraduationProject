using graduationProject.Bl.DTOs;
using graduationProject.Bl.DTOs.CityDTO;
using graduationProject.DAL.Data.Models;
using graduationProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public class BranchManager : IBranchManager
    {

        private readonly IRepository<Branch> _repository;

        public BranchManager(IRepository<Branch> repository)
        {
            _repository = repository;
        }
        public async Task<BranchWriteDTO> AddAsync(BranchWriteDTO entity)
        {
            Branch newBranch = new()
            {
                Name = entity.Name
            };
            await _repository.AddAsync(newBranch);
            _repository.SaveChanges();
            return entity;
        }

        public void Delete(byte id)
        {
            var entity = _repository.GetByCriteriaAsync(b => b.Id == id).Result;
            _repository.DeleteById(entity);
            _repository.SaveChanges();
        }

        public async Task<IEnumerable<BranchReadDTO>> GetAllActiveAsync()
        {
            var branches = await _repository.GetAllAsync();
            var result = branches.Where(b => b.Status == true).Select(b => new BranchReadDTO
            {
                Id = b.Id,
                Name = b.Name,
                Date = b.Date,
                Status = b.Status
            });
            return result;
        }

        public async Task<IEnumerable<BranchReadDTO>> GetAllAsync()
        {
            var branches = await _repository.GetAllAsync();
            var result = branches.Select(b => new BranchReadDTO
            {
                Id = b.Id,
                Name = b.Name,
                Date = b.Date,
                Status = b.Status
            });
            return result;
        }

        public async Task<BranchReadDTO> GetByIdAsync(byte id)
        {
            Branch branch = await _repository.GetByCriteriaAsync(b => b.Id == id);

            BranchReadDTO branchRead = new()
            {
                Id = branch.Id,
                Name = branch.Name,
                Date = branch.Date,
                Status = branch.Status
            };

            return branchRead;
        }

        public async Task<BranchUpdateDTO> UpdateAsync(BranchUpdateDTO entity)
        {
            Branch updatedEntity = new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.Status
            };
            await _repository.UpdateAsync(updatedEntity);
            _repository.SaveChanges();
            return entity;
        }
    }
}