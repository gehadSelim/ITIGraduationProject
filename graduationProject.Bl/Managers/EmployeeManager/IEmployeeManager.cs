using graduationProject.Bl.DTOs;
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
        Task<IEnumerable<EmployeeReadDTO>> GetAllActiveAsync();
        Task<EmployeeWriteDTO> AddAsync(EmployeeWriteDTO entity);
        Task<EmployeeUpdateDTO> UpdateAsync(EmployeeUpdateDTO entity);
        Task<IEnumerable<RolePrivilegesValidateDTO>> GetRolePrivilegesByUserId(string userId);

    }
}
