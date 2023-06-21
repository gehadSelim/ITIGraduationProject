using graduationProject.Bl.DTOs.CityDTO;
using graduationProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class StateReadDTO
    {
        public byte Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
        public ICollection<CityReadSimpleDto>? City { get; set; }
    }
}
