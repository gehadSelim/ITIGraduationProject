using graduationProject.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public interface ISettingsManager
    {
        Task<SettingsReadDTO> GetByIdAsync(byte id);
        Task<SettingsReadDTO> GetAsync();
        Task<SettingsWriteDTO> AddAsync(SettingsWriteDTO entity);
        Task<SettingsUpdateDTO> UpdateAsync(SettingsUpdateDTO entity);
        void Delete(byte id);
    }
}
