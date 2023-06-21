using graduationProject.DAL.Data.Models;
using graduationProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class EmployeeUpdateDTO
    {
        public string Id { get; set; } = string.Empty;
        public string RoleId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public byte BranchId { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
