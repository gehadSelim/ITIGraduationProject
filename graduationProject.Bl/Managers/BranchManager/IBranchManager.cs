using graduationProject.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public interface IBranchManager
    {
        Task<BranchReadDTO> GetByIdAsync(byte id);
        Task<IEnumerable<BranchReadDTO>> GetAllAsync();
        Task<IEnumerable<BranchReadDTO>> GetAllActiveAsync();
        Task<PaginationDTO<BranchReadDTO>?> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<BranchWriteDTO> AddAsync(BranchWriteDTO entity);
        Task<BranchUpdateDTO> UpdateAsync(BranchUpdateDTO entity);
        void Delete(byte id);

    }
}
