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
    public class PrivilegeEntityTypeConfiguration : IEntityTypeConfiguration<Privilege>
    {
        public void Configure(EntityTypeBuilder<Privilege> builder)
        {
            builder
                .Property(p => p.Name)
                .HasColumnType("nvarchar(75)");

            builder
                .Property(p => p.ArabicName)
                .HasColumnType("nvarchar(75)")
                ;

            builder
               .Property(p => p.Id)
               .UseIdentityColumn();
        }
    }
}
