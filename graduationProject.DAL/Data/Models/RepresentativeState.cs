using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL.Data.Models
{
    public class RepresentativeState
    {
        public int Id { get; set; }

        [ForeignKey("State")]
        public byte StateId { get; set; }
        public virtual State? State { get; set; }

        [ForeignKey("Representative")]
        public string RepresentativeId { get; set; } = string.Empty;
        public virtual Representative? Representative { get; set; }

    }
}
