using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skola.Data.Entities;


namespace SchoolProject.Infrustructure.Configurations
{
	public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{

			builder.HasKey(x => x.Id);
			builder.Property(x => x.NameAr).HasMaxLength(500);

			builder.HasMany(x => x.Student)
				  .WithOne(x => x.Department)
				  .HasForeignKey(x => x.DepartmentId)
				  .OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(d => d.DepartmentManager)
				.WithOne(d => d.ManagerDepartment)
				.HasForeignKey<Department>(d => d.DepartmentManagerId);



		}
	}
}

