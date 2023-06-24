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
    public class ShippingTypeEntityTypeConfiguration : IEntityTypeConfiguration<ShippingType>
    {
        public void Configure(EntityTypeBuilder<ShippingType> builder)
        {
            builder
                .Property(s => s.Name)
                .HasColumnType("nvarchar(75)");


            builder
               .HasIndex(st => st.Name)
               .IsUnique();

            builder
                .Property(s => s.Id)
                .UseIdentityColumn();
        }
    }
}
