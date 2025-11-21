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
	public class Studentconf : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.Property(s => s.NameEn).IsRequired().HasMaxLength(100);
			builder.Property(s => s.NameAr).IsRequired().HasMaxLength(100);
			builder.Property(s => s.Address).IsRequired().HasMaxLength(200);
			builder.Property(s => s.PhoneNumber).HasMaxLength(200);

			builder.HasOne(s => s.Department)
				.WithMany(d=>d.Student)
				.HasForeignKey(s => s.DepartmentId);
	

		

		}
	}
}
