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
	public class Subjectconf : IEntityTypeConfiguration<Subject>
	{
		public void Configure(EntityTypeBuilder<Subject> builder)
		{
			builder.Property(p => p.NameEn).IsRequired().HasMaxLength(100);
			builder.Property(p => p.NameAr).IsRequired().HasMaxLength(100);
			builder.HasKey(x => x.Id);

			
		}
	}
}
