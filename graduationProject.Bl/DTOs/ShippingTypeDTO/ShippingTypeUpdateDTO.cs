using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class ShippingTypeUpdateDTO
    {
        public byte Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Cost { get; set; }
    }
}
