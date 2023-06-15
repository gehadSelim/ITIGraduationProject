using graduationProject.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public interface IRolePrivilegesManger
    {
        Task<IEnumerable<RolePrivilegesReadDTO>> GetRolePrivilegesByRoleId(string roleId);
    }
}
