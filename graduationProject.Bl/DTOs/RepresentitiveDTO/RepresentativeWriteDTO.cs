using graduationProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class RepresentativeWriteDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public byte BranchId { get; set; }
        public List<byte> StatesId { get; set; } = new List<byte>();
        public string Password { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DiscountType DiscountType { get; set; }
        public double CompanyOrderRatio { get; set; }
    }
}
