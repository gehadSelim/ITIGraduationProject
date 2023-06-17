using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class TraderReadDTO
    {
        public string Id { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public BranchReadSimpleDTO? Branch { get; set; } 
        public CitySimpleDTO? City { get; set; } 
        public StateReadSimpleDTO? State { get; set; }
        public string? Address { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public double RejectedOrderlossRatio { get; set; }
        public IEnumerable<SpecialPackageReadDTO>? SpecialPackages { get; set; }

    }
}
