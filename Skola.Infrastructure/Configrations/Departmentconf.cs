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
	public class Departmentconf : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.Property(d => d.NameEn).IsRequired().HasMaxLength(100);
			builder.Property(d => d.NameAr).IsRequired().HasMaxLength(100);

			builder.HasMany(d => d.Student)
				.WithOne(d=>d.Department)
				.HasForeignKey(d => d.DepartmentId);

			builder.HasMany(d => d.Instructors)
				.WithOne(d=>d.Department)
				.HasForeignKey(d => d.DepartmentId);

			builder.HasOne(d => d.DepartmentManager)
				.WithOne(d=>d.ManagerDepartment)
				.HasForeignKey<Department>(d => d.DepartmentManagerId);
		}
	}
}
