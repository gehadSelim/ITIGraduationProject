using graduationProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class TraderWriteDTO
    {
        public string FullName { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public byte BranchId { get; set; }
        public byte StateId { get; set; }
        public int CityId { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public double RejectedOrderlossRatio { get; set; }
        public ICollection<SpecialPackageWriteDTO>? SpecialPackages { get; set; }
    }
}
