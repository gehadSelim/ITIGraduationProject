using System.ComponentModel.DataAnnotations.Schema;

namespace graduationProject.DAL.Data.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double ShipingCost { get; set; }

        [ForeignKey("State")]
        public byte StateId { get; set; }
        public virtual State? State { get; set; }
    }
}