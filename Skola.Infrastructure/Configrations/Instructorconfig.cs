using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skola.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Infrastructure.Configrations
{
	public class Instructorconfig : IEntityTypeConfiguration<Instructor>
	{
		public void Configure(EntityTypeBuilder<Instructor> builder)
		{
			builder.Property(i => i.NameAr).IsRequired().HasMaxLength(100);
			builder.Property(i => i.NameEn).IsRequired().HasMaxLength(100);
			builder.Property(i => i.Address).IsRequired().HasMaxLength(200);
			builder.Property(i => i.Salary).HasColumnType("decimal(18,2)");


			builder.HasOne(i => i.Department)
				.WithMany(i=>i.Instructors)
				.HasForeignKey(i => i.DepartmentId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(i => i.ManagerDepartment)
			   .WithOne(d => d.DepartmentManager)
			   .HasForeignKey<Department>(d => d.DepartmentManagerId)
			   .OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(i=>i.Instructors)
				.WithOne(i=>i.Supervisor)
				.HasForeignKey(i => i.SupervisorId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
