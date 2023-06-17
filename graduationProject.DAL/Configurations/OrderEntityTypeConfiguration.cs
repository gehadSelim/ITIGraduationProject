using graduationProject.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL.Configurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(o => o.ReceivedCost)
                .HasDefaultValue(0.0);

            builder
               .Property(o => o.ReceivedShipingCost)
               .HasDefaultValue(0.0);

            builder
                .Property(o => o.RepresentativeID)
                .IsRequired(false);

            builder
                .Property(o => o.Comments)
                .IsRequired(false);
        }
    }
}
