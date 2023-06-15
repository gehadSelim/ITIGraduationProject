using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL.Configurations
{
    public class BranchEntityTypeConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder
                .Property(b => b.Name)
                .HasColumnType("nvarchar(75)");

            builder
                .Property(b=>b.Date)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(b => b.Status)
                .HasDefaultValueSql("1");

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

        }
    }
}
