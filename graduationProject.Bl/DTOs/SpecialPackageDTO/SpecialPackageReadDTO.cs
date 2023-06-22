using graduationProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class SpecialPackageReadDTO
    {
        //public int Id { get; set; }
        public string? City  { get; set; }
        public string? State { get; set; }
        public double ShippingCost { get; set; }
    }
}
