using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs.CityDTO
{
    public class CityReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double ShippingCost { get; set; }
        public StateReadSimpleDTO? State { get; set; }
    }
}
