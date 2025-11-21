using Skola.Data.Entities;
using Skola.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Data.Services
{
	public interface IStudentServices
	{
		public Task<List<Student>> GetAllStudents();
		public Task<Student> GetStudentById(int id);
		public Task<string> AddAsyc(Student student);
		public Task<bool> IsNameArExist(string name);
		public Task<bool> IsNameArEXistWithSelf(string name, int id);
		public Task<bool> IsNameEnExist(string name);
		public Task<bool> IsNameEnEXistWithSelf(string name, int id);
		public Task<string> EditAsync(Student student);
		public Task<string> DeleteAsync(Student student);
		public IQueryable<Student> GetStudentQuerable();
		public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderby,string search);
		public IQueryable<Student> GetStudentByDepartmentIdQuerable(int id );

	}
}
