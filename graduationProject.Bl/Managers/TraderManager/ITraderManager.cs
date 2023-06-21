using graduationProject.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public interface ITraderManager
    {
        Task<TraderReadDTO> GetByIdAsync(string id);
        Task<TraderReadDTO> GetByApplicationUserIdAsync(string id);
        Task<double> GetShippingCostAsync(string Traderid,int Cityid);
        Task<IEnumerable<TraderReadDTO>> GetAllAsync();
        Task<IEnumerable<TraderReadDTO>> GetAllActiveAsync();
        Task<TraderWriteDTO> AddAsync(TraderWriteDTO entity);
        Task<TraderUpdateStatusDTO> UpdateStatusAsync(TraderUpdateStatusDTO entity);
        Task<TraderUpdateDTO> UpdateAsync(TraderUpdateDTO entity);
        void DeleteTraderSpecialPackages(int specialPackageId);
    }
}
