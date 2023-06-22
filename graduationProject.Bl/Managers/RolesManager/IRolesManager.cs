using graduationProject.Bl.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public interface IRolesManager
    {
        IEnumerable<RoleReadDTO> GetAll();
        IEnumerable<RoleSimpleDTO> GetAllSimple();
        Task<RoleWriteDTO> AddAsync(RoleWriteDTO entity);
        Task<RoleUpdateDTO> UpdateAsync(RoleUpdateDTO entity);
        Task<IdentityResult> DeleteAsync(string id);
    }
}
