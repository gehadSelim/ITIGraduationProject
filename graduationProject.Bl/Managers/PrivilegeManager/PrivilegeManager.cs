using graduationProject.Bl.DTO;
using graduationProject.Bl.DTOs;
using graduationProject.DAL;
using graduationProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public class PrivilegeManager : IPrivilegeManger
    {
        private readonly IRepository<Privilege> _repository;

        public PrivilegeManager(IRepository<Privilege> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PrivilegeReadDTO>> GetAllAsync()
        {
            var privileges = await _repository.GetAllAsync();
            var result = privileges.Select(p => new PrivilegeReadDTO
            {
                Id = p.Id,
                Name = p.ArabicName
            });
            return result;
        }
    }
}
