using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class SpecialPackageUpdateDTO
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public byte StateId { get; set; }
        public double ShippingCost { get; set; }
    }
}
