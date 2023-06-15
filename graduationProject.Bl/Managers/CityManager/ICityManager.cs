using graduationProject.Bl.DTOs;
using graduationProject.Bl.DTOs.CityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers.CityManager
{
    public interface ICityManager
    {
        Task<IEnumerable<CityReadDto>> GetAllAsync(string stateName);
        Task<double> GetByIDAsync(int Cityid);

        Task<CityWriteDto> AddAsync(CityWriteDto entity);
        Task<CityUpdateDto> UpdateAsync(CityUpdateDto entity);
    }
}
