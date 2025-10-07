using Microsoft.EntityFrameworkCore;
using Skola.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Infrastructure.data
{
	public class dbcontext : DbContext
	{
		public dbcontext(DbContextOptions options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
		public  DbSet<Student> Student { get; set; }
        public  DbSet<Department> Department { get; set; }
        public  DbSet<Subject> Subject{ get; set; }

        public  DbSet<Instructor> Instructor { get; set; }
        public  DbSet<StudentSubject> StudentSubject { get; set; }
		public DbSet<DepartmentSubject> DepartmentSubject { get; set; }

        public  DbSet<SubjectInstructor> subjectInstructor { get; set; }
    }
}
