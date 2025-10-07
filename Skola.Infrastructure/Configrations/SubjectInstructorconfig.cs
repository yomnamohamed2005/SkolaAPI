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
	public class SubjectInstructorconfig : IEntityTypeConfiguration<SubjectInstructor>
	{
		public void Configure(EntityTypeBuilder<SubjectInstructor> builder)
		{
			
			builder.HasKey(si => new { si.SubjectId, si.InstructorId });

		
			builder.HasOne(si => si.Subject)
				   .WithMany(s => s.Instructors)
				   .HasForeignKey(si => si.SubjectId);

			builder.HasOne(si => si.Instructor)
				   .WithMany(i => i.Subjects)
				   .HasForeignKey(si => si.InstructorId);
		}
	}
}
