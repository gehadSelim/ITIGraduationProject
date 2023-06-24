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
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .Property(e => e.Id)
                .HasColumnType("nvarchar(450)");

            builder
                .Property(e => e.Date)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(e => e.RoleId)
                .IsRequired(false);

            builder
                .Property(e => e.BranchId)
                .HasDefaultValue<byte>(1);
        }
    }
}
