using graduationProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class SpecialPackageWriteDTO
    {
        public int CityId { get; set; }
        public byte StateId { get; set; }
        public double ShippingCost { get; set; }
    }
}
