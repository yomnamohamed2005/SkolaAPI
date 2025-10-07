using Microsoft.EntityFrameworkCore;
using Skola.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Skola.Infrastructure.data
{
	public static class dbcontextseed
	{
		public static async Task SeedAsync(dbcontext dbcontext)
		{
			if (!dbcontext.Department.Any())
			{
				var departmentdata = File.ReadAllText("../Skola.Infrastructure/data/dataseeding/department.json");
				var departments = JsonSerializer.Deserialize<HashSet<Department>>(departmentdata);
				if (departments?.Count > 0)
				{
					foreach (var department in departments)
					{
						await dbcontext.Set<Department>().AddAsync(department);
					}
					await dbcontext.SaveChangesAsync();
				}
			}
			if (!dbcontext.Student.Any())
			{
				var studentdata = File.ReadAllText("../Skola.Infrastructure/data/dataseeding/student.json");
				var students = JsonSerializer.Deserialize<HashSet<Student>>(studentdata);
				if (students?.Count > 0)
				{
					foreach (var student in students)
					{
						await dbcontext.Set<Student>().AddAsync(student);
					}
					await dbcontext.SaveChangesAsync();
				}
			}
			if (!dbcontext.Subject.Any())
			{
				var subjectdata = File.ReadAllText("../Skola.Infrastructure/data/dataseeding/subject.json");
				var subjects = JsonSerializer.Deserialize<HashSet<Subject>>(subjectdata);
				if (subjects?.Count > 0)
				{
					foreach (var subject in subjects)
					{
						await dbcontext.Set<Subject>().AddAsync(subject);
					}
					await dbcontext.SaveChangesAsync();
				}
			}
			if (!dbcontext.DepartmentSubject.Any())
			{
				var departmentsubjectdata = File.ReadAllText("../Skola.Infrastructure/data/dataseeding/departmentsubject.json");
				var departmentsubjects = JsonSerializer.Deserialize<HashSet<DepartmentSubject>>(departmentsubjectdata);
				if (departmentsubjects?.Count > 0)
				{
					foreach (var departmentsubject in departmentsubjects)
					{
						await dbcontext.Set<DepartmentSubject>().AddAsync(departmentsubject);
					}
					await dbcontext.SaveChangesAsync();
				}
			}
	
			if (!dbcontext.StudentSubject.Any())
			{
				var studentsubjectdata = File.ReadAllText("../Skola.Infrastructure/data/dataseeding/studentsubject.json");
				var studentsubjects = JsonSerializer.Deserialize<HashSet<StudentSubject>>(studentsubjectdata);
				if (studentsubjects?.Count > 0)
				{
					foreach (var studentsubject in studentsubjects)
					{
						await dbcontext.Set<StudentSubject>().AddAsync(studentsubject);
					}
					await dbcontext.SaveChangesAsync();
				}
			}
			

		}
	}
    
}

