using graduationProject.Bl.DTOs;
using graduationProject.Bl.Managers;
using graduationProject.DAL;
using graduationProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public class ShippingTypeManager : IShippingTypeManager
    {
        private readonly IRepository<ShippingType> _repository;
        public ShippingTypeManager(IRepository<ShippingType> repository) 
        { 
            _repository = repository;
        }
        public async Task<ShippingTypeWriteDTO> AddAsync(ShippingTypeWriteDTO entity)
        {
            ShippingType newShippingType = new()
            {
                Name = entity.Name,
                Cost= entity.Cost,
            };
            await _repository.AddAsync(newShippingType);
            _repository.SaveChanges();
            return entity;
        }

        public void Delete(byte id)
        {
            var entity = _repository.GetByCriteriaAsync(sh => sh.Id == id).Result;
            if(id == 1)
            {
                throw new Exception("this type can't be deleted");
            }
            _repository.DeleteById(entity);
            _repository.SaveChanges();
        }

        public async Task<IEnumerable<ShippingTypeReadDTO>> GetAllAsync()
        {
            var shippingTypes = await _repository.GetAllAsync();
            var result = shippingTypes.Select(s => new ShippingTypeReadDTO
            {
                Id = s.Id,
                Name = s.Name,
                Cost = s.Cost
            });
            return result;
        }

        public async Task<ShippingTypeReadDTO> GetByIdAsync(byte id)
        {
            ShippingType shippingType = await _repository.GetByCriteriaAsync(sh=>sh.Id ==id);

            ShippingTypeReadDTO shippingTypeRead = new()
            {
                Id = shippingType.Id,
                Name = shippingType.Name,
                Cost = shippingType.Cost,
            };

            return shippingTypeRead;
        }

        public async Task<ShippingTypeUpdateDTO> UpdateAsync(ShippingTypeUpdateDTO entity)
        {
            ShippingType updatedEntity = new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Cost = entity.Cost
            };
            await _repository.UpdateAsync(updatedEntity);
            _repository.SaveChanges();
            return entity;
        }
    }
}

