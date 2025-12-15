
using Skola.Data.Entities;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Skola.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace Skola.Infrastructure.data
{
	public class dbcontext : IdentityDbContext<
		User,                    
		IdentityRole<int>,        
		int,                     
		IdentityUserClaim<int>,
		IdentityUserRole<int>,
		IdentityUserLogin<int>,
		IdentityRoleClaim<int>,
		IdentityUserToken<int>>
	{
		public dbcontext()
		{

		}
		public dbcontext(DbContextOptions<dbcontext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public DbSet<Student> Student { get; set; }
		public DbSet<Department> Department { get; set; }
		public DbSet<Subject> Subject { get; set; }
		public DbSet<Instructor> Instructor { get; set; }
		public DbSet<StudentSubject> StudentSubject { get; set; }
		public DbSet<DepartmentSubject> DepartmentSubject { get; set; }
		public DbSet<SubjectInstructor> SubjectInstructor { get; set; }
        public DbSet<User> User { get; set; }
    }
}
