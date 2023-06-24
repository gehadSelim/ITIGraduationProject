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
    public class RepresentativeEntityTypeConfiguration : IEntityTypeConfiguration<Representative>
    {
        public void Configure(EntityTypeBuilder<Representative> builder)
        {
            builder
                .Property(r => r.Id)
                .HasColumnType("nvarchar(450)");

            builder
                .Property(r => r.Date)
                .HasDefaultValueSql("GETDATE()");



            builder
                .Property(e => e.BranchId)
                .HasDefaultValue<byte>(1);
        }
    }
}
