using graduationProject.Bl.DTOs;
using graduationProject.Bl.DTOs.CityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public interface IEmployeeManager
    {
        Task<EmployeeReadDTO> GetByIdAsync(string id);
        Task<EmployeeReadDTO> GetByApplicationUserIdAsync(string id);
        Task<IEnumerable<EmployeeReadDTO>> GetAllAsync();
        Task<PaginationDTO<EmployeeReadDTO>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<IEnumerable<EmployeeReadDTO>> GetAllActiveAsync();
        Task<EmployeeWriteDTO> AddAsync(EmployeeWriteDTO entity);
        Task<EmployeeUpdateStatusDTO> UpdateStatusAsync(EmployeeUpdateStatusDTO entity);
        Task<EmployeeUpdateDTO> UpdateAsync(EmployeeUpdateDTO entity);
        Task<IEnumerable<RolePrivilegesValidateDTO>> GetRolePrivilegesByUserId(string userId);
        Task<Dictionary<string, List<bool>>> GetPermissionsByUserId(string userId);

    }
}
