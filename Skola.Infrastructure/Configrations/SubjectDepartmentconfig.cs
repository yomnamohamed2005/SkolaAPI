using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skola.Data.Entities;
namespace Skola.Infrastructure.Configrations
{
	public class subjectDepartmentconfig : IEntityTypeConfiguration<DepartmentSubject>
	{
		public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
		{
			builder.HasKey(sd => new { sd.DepartmentId, sd.SubjectId });

			builder.HasOne(d => d.Department)
				.WithMany(d => d.Subjects)
				.HasForeignKey(d=> d.DepartmentId);

			builder.HasOne(s => s.Subject)
				.WithMany(s=> s.departments)
				.HasForeignKey(s=> s.SubjectId);
		}
	}
}
