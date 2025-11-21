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
	public class StudentSubjectconfig : IEntityTypeConfiguration<StudentSubject>
	{
		public void Configure(EntityTypeBuilder<StudentSubject> builder)
		{
			builder.HasKey(ss => new { ss.SubjectId, ss.StudentId });

			builder.HasOne(s => s.Student)
				.WithMany(s => s.subjects)
				.HasForeignKey(s => s.StudentId);

			builder.HasOne(s => s.Subject)
				.WithMany(s => s.students)
				.HasForeignKey(s => s.SubjectId);

		}
	}
}
