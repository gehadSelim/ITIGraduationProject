using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL.Data.Models
{
    public class SpecialPackage
    {
        public int Id { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City? City { get; set; }

        [ForeignKey("State")]
        public byte StateId { get; set; }
        public virtual State? State { get; set; }

        public double ShippingCost { get; set; }

        [ForeignKey("Trader")]
        public string TraderId { get; set; } = string.Empty;
        public virtual Trader? Trader { get; set; }
    }

}
