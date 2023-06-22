using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using graduationProject.Bl.DTOs;

namespace graduationProject.Bl.Managers
{
    public interface IStateManager
    {
        Task<IEnumerable<StateReadDTO>> GetAllAsync();
        Task<PaginationDTO<StateReadDTO>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<IEnumerable<StateReadSimpleDTO>> GetAllActiveAsync();
        Task<IEnumerable<StateReadSimpleDTO>> GetAllHavingCitiesAsync();
        Task<StateReadDTO> GetStateByIdWithCitiesAsync(int id);
        Task<StateWriteDTO> AddAsync(StateWriteDTO entity);
        Task<StateUpdateDTO> UpdateAsync(StateUpdateDTO entity);
        int GetTotalPages(int pageSize);

    }

}
