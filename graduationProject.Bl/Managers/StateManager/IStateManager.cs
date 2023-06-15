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
        Task<IEnumerable<StateReadDTO>> GetAllActiveAsync();
        Task<StateReadDTO> GetStateByIdWithCitiesAsync(int id);
        Task<StateWriteDTO> AddAsync(StateWriteDTO entity);
        Task<StateUpdateDTO> UpdateAsync(StateUpdateDTO entity);
    }

}
