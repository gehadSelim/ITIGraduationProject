using graduationProject.DAL.Data.Models;
using graduationProject.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class EmployeeReadDTO
    {
        public string Id { get; set; } = string.Empty;
        public RoleSimpleDTO? Role { get; set; } 
        public string FullName { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public BranchReadSimpleDTO? Branch { get; set; }
        public string? Address { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
