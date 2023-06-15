using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL.Data.Models
{
    public enum DiscountType { FixedValue  , PrecentRatio }
    public class Representative
    {
        public string Id { get; set; } = string.Empty;       
        public DiscountType DiscountType { get; set; }
        public double CompanyOrderRatio { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; } = string.Empty;
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey("Branch")]
        public byte BranchId { get; set; }
        public virtual Branch? Branch { get; set; }
        public virtual ICollection<RepresentativeState> RepresentativeStates { get; set; } = new HashSet<RepresentativeState>();
    }
}
