using graduationProject.Bl.DTOs;
using graduationProject.Bl.DTOs.CityDTO;
using graduationProject.DAL;
using graduationProject.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers.CityManager
{
    public class CityManger : ICityManager
    {
        private readonly IRepository<City> _repository;

        public CityManger(IRepository<City> repository)
        {
            _repository = repository;
        }
        public async Task<CityWriteDto> AddAsync(CityWriteDto entity)
        {
            City newCity = new()
            {
                Name = entity.Name,
                ShipingCost = entity.ShippingCost,
                StateId = entity.StateId
            };
            await _repository.AddAsync(newCity);
            _repository.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<CityReadSimpleDto>> GetAllAsync()
        {
            var cities = await _repository.GetAllAsync().Result.Where(c=>c.Status == true).ToListAsync();
            var result = cities.Select(c => new CityReadSimpleDto
                               {
                                   Id = c.Id,
                                   Name = c.Name,
                                   StateId = c.StateId
                               });
            return result;
        }

        public async Task<IEnumerable<CityReadDto>> GetAllWithShippingCostAsync()
        {
            var cities = await _repository.GetAllAsync(new[] { "State" });
            var result = cities.Select(c => new CityReadDto
            {
                Id = c.Id,
                Name = c.Name,
                Status = c.Status,
                ShippingCost = c.ShipingCost,
                State = new()
                {
                    Id = c.StateId,
                    Name = c.State.Name
                }
            }).ToList();
            return result;
        }

        public async Task<double> GetByIDAsync(int Cityid)
        {
            var CityShippingCost= await _repository.GetByIdAsync(Cityid);
            if(CityShippingCost == null) { return 0.0; }
            return CityShippingCost.ShipingCost;
        }

        public async Task<CityUpdateDto> UpdateAsync(CityUpdateDto entity)
        {
            City oldCity = await _repository.GetByCriteriaAsync(oc => oc.Id == entity.Id, new[] {"State"} );  

            if(entity.Status == true && oldCity.State.Status == true)
            {
                oldCity.Status = true;
            }
            else
            {
                oldCity.Status = false;
            }

            oldCity.Name = entity.Name;
            oldCity.ShipingCost = entity.ShippingCost;
            oldCity.StateId = entity.StateId;

           await _repository.UpdateAsync(oldCity);
            _repository.SaveChanges();
            return entity;
        }
    }
}
