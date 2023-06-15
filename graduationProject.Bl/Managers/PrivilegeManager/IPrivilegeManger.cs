using graduationProject.Bl.DTO;
using graduationProject.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public interface IPrivilegeManger
    {
        Task<IEnumerable<PrivilegeReadDTO>> GetAllAsync();

    }
}
