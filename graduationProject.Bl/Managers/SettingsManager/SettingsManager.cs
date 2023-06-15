using graduationProject.Bl.DTOs;
using graduationProject.DAL.Data.Models;
using graduationProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace graduationProject.Bl.Managers
{
    public class SettingsManager : ISettingsManager
    {
        private readonly IRepository<Settings> _repository;
        public SettingsManager(IRepository<Settings> repository)
        {
            _repository = repository;
        }
        public async Task<SettingsWriteDTO> AddAsync(SettingsWriteDTO entity)
        {
            Settings newSetting = new()
            {
                DefaultWeight = entity.DefaultWeight,
                OverCostPerKG= entity.OverCostPerKG,
                VillageShipingCost = entity.VillageShipingCost,
            };
            await _repository.AddAsync(newSetting);
            _repository.SaveChanges();
            return entity;
        }

        public void Delete(byte id)
        {
            var entity = _repository.GetByCriteriaAsync(s => s.Id == id).Result;
            _repository.DeleteById(entity);
            _repository.SaveChanges();
        }

        public async Task<SettingsReadDTO> GetAsync()
        {
            var Settings = await _repository.GetAllAsync();
            var result = Settings.Select(s => new SettingsReadDTO
            {
                Id = s.Id,
                DefaultWeight = s.DefaultWeight,
                OverCostPerKG = s.OverCostPerKG,
                VillageShipingCost = s.VillageShipingCost
            });
            return result.FirstOrDefault();
        }

        public async Task<SettingsReadDTO> GetByIdAsync(byte id)
        {
            Settings setting = await _repository.GetByCriteriaAsync(s => s.Id == id);

            SettingsReadDTO SettingsRead = new()
            {
                Id = setting.Id,
                DefaultWeight = setting.DefaultWeight,
                OverCostPerKG = setting.OverCostPerKG,
                VillageShipingCost = setting.VillageShipingCost

            };

            return SettingsRead;
        }

        public async Task<SettingsUpdateDTO> UpdateAsync(SettingsUpdateDTO entity)
        {
            Settings updatedEntity = new()
            {
                Id = entity.Id,
                DefaultWeight = entity.DefaultWeight,
                OverCostPerKG = entity.OverCostPerKG,
                VillageShipingCost = entity.VillageShipingCost

            };
            await _repository.UpdateAsync(updatedEntity);
            _repository.SaveChanges();
            return entity;
        }
    }
}
