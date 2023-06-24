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
    public class TraderEntityTypeConfiguration : IEntityTypeConfiguration<Trader>
    {
        public void Configure(EntityTypeBuilder<Trader> builder)
        {
            builder
                .Property(t => t.Id)
                .HasColumnType("nvarchar(450)");

            builder
                .Property(t => t.Date)
                .HasDefaultValueSql("GETDATE()");

            builder
             .Property(e => e.BranchId)
             .HasDefaultValue<byte>(1);

            builder
                .Property(t => t.StoreName)
                .HasColumnType("nvarchar(85)");
        }
    }
}
