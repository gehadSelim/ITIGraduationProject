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
    public class StateEntityTypeConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder
                .Property(st => st.Name)
                .HasColumnType("nvarchar(75)");
            builder.
                Property(st => st.Id)
                .UseIdentityColumn();
        }
    }
}
