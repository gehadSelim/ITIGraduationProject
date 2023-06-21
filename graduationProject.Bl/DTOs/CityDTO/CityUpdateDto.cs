using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs.CityDTO
{
    public class CityUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte StateId { get; set; }
        public double ShippingCost { get; set; }
        public bool Status { get; set; }

    }
}
