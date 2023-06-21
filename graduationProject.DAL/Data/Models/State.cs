using Microsoft.EntityFrameworkCore;

namespace graduationProject.DAL.Data.Models
{
    public class State
    {
        public byte Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
        public virtual ICollection<City>? City { get; set; }
        public virtual ICollection<RepresentativeState>? RepresentativeStates { get; set; } = new HashSet<RepresentativeState>();


    }
}