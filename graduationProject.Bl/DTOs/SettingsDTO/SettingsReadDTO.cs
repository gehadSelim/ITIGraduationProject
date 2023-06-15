using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class SettingsReadDTO
    {
        public byte Id { get; set; } = 1;

        public double DefaultWeight { get; set; }

        public double OverCostPerKG { get; set; }

        public double VillageShipingCost { get; set; }
    }
}
