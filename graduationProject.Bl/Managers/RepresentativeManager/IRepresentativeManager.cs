using graduationProject.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public interface IRepresentativeManager
    {
        Task<RepresentativeReadDTO> GetByIdAsync(string id);
        Task<RepresentativeReadDTO> GetByApplicationUserIdAsync(string id);
        Task<IEnumerable<RepresentativeReadDTO>> GetAllAsync();
        Task<IEnumerable<RepresentativeReadDTO>> GetAllActiveAsync();
        Task<IEnumerable<RepresentativeSimpleReadDTO>> GetAllActiveByStateIdAsync(int StateId);
        Task<RepresentativeWriteDTO> AddAsync(RepresentativeWriteDTO entity);
        Task<RepresentativeUpdateDTO> UpdateAsync(RepresentativeUpdateDTO entity);
    }
}
