using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL.Data.Models
{
    public class Trader
    {
        public string Id { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;

        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City? City { get; set; }

        [ForeignKey("State")]
        public byte StateId { get; set; }
        public virtual State? State { get; set; }
        public double RejectedOrderlossRatio { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; } = string.Empty;
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey("Branch")]
        public byte BranchId { get; set; }
        public virtual Branch? Branch { get; set; }
        public virtual ICollection<SpecialPackage>? SpecialPackages { get; set; }
    }
}
