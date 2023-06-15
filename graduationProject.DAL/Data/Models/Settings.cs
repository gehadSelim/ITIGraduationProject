using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL.Data.Models
{
    public class Settings
    {
        public byte Id { get; set; } = 1;

        public double DefaultWeight { get; set; } = 0;

        public double OverCostPerKG { get; set; } = 0;

        public double VillageShipingCost { get; set; } = 0;

    }
}
