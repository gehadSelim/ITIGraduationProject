using graduationProject.Bl.DTOs;
using graduationProject.Bl.DTOs.CityDTO;
using graduationProject.DAL;
using graduationProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public class StateManager : IStateManager
    {
        private readonly IRepository<State> _repository;

        public StateManager(IRepository<State> repository)
        {
            _repository = repository;
        }

        public async Task<StateWriteDTO> AddAsync(StateWriteDTO entity)
        {
            State newState = new()
            {
                Name = entity.Name
            };
            await _repository.AddAsync(newState);
            try
            {
                _repository.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            
            return entity;
        }

        public async Task<IEnumerable<StateReadSimpleDTO>> GetAllActiveAsync()
        {
            var states = await _repository.GetAllAsync();
            var result = states.Where( s => s.Status == true).Select(s => new StateReadSimpleDTO
            {
                Id = s.Id,
                Name = s.Name,
            });
            return result;
        }

        public async Task<PaginationDTO<StateReadDTO>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var states = await _repository.GetAllAsNoTrackingAsync(pageNumber, pageSize);

            if (states == null)
            {
                return null;
            }

            int totalPages = _repository.GetTotalPages(pageSize);
            PaginationDTO<StateReadDTO> result = new()
            {
                TotalPages = totalPages,
                Data = states.Select(s => new StateReadDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Status = s.Status
                }),
            };

            return result;
        }

        public async Task<IEnumerable<StateReadDTO>> GetAllAsync()
        {
            var states = await _repository.GetAllAsync();
            var result = states.Select(s => new StateReadDTO
            {
                Id = s.Id,
                Name = s.Name,
                Status = s.Status
            });
            return result;
        }

        public async Task<IEnumerable<StateReadSimpleDTO>> GetAllHavingCitiesAsync()
        {
            var states = await _repository.GetAllAsync(new[] { "City" });
            var result = states.Where(s => s.Status == true && s.City.Count > 0 ).Select(s => new StateReadSimpleDTO
            {
                Id = s.Id,
                Name = s.Name,
            });
            return result;
        }

        public async Task<StateReadDTO> GetStateByIdWithCitiesAsync(int id)
        {
            var result = await _repository.GetByCriteriaAsync(s => s.Id == id, new[] { "City" });

            StateReadDTO stateReadDTO = new()
            {
                Id = result.Id,
                Name = result.Name,
                Status = result.Status,
                City = result.City.Select(c => new CityReadDto() {
                    Id = c.Id,
                    Name = c.Name,
                    ShippingCost = c.ShipingCost,
                    Status= c.Status
                }).ToList()
            };

            return stateReadDTO;
        }

        public int GetTotalPages(int pageSize)
        {
            return _repository.GetTotalPages(pageSize);
        }

        public async Task<StateUpdateDTO> UpdateAsync(StateUpdateDTO entity)
        {
            var oldEntity = await _repository.GetByCriteriaAsync(s => s.Id == entity.Id, new[] { "City" });

            if(oldEntity.Status != entity.Status) 
            { 
                foreach(var city in oldEntity.City)
                {
                    city.Status = entity.Status;
                }
            }
            oldEntity.Name = entity.Name;
            oldEntity.Status = entity.Status;
            
            await _repository.UpdateAsync(oldEntity);
            _repository.SaveChanges();
            return entity;
        }
    }
}
