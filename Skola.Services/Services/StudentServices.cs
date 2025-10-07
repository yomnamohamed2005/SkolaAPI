using Microsoft.EntityFrameworkCore;
using Skola.Data.Entities;
using Skola.Data.Helper;
using Skola.Data.Repositories;
using Skola.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Skola.Services.Services
{
	public class StudentServices : IStudentServices
	{
		private readonly IStudentRepository _studentrepo;

		public StudentServices(IStudentRepository studentrepo)
		{
			this._studentrepo = studentrepo;
		}

		public async Task<List<Student>> GetAllStudents()
		{
			return await _studentrepo.GetStudentsAsync();
		}
		public async Task<Student> GetStudentById(int id)
		{
			var student = await _studentrepo.GetNoTracking()
									   .Include(s => s.Department)
									   .Where(s => s.Id == id)
									   .FirstOrDefaultAsync();
			return student;
		}
		public async Task<string> AddAsyc(Student student)
		{
			
			await _studentrepo.AddEntity(student);
			return "Success";
		}

		public  async Task<bool> IsNameEnExist(string name)
		{
			var Student = await _studentrepo.GetNoTracking().Where(s => s.NameEn == name).FirstOrDefaultAsync();
			if (Student == null) return false;
				return true;
		}

		public async Task<bool> IsNameEnEXistWithSelf(string name, int id)
		{

			var Student =  _studentrepo.GetNoTracking().Where(s => s.NameEn == name && s.Id!= id).FirstOrDefault();
			if (Student == null) return false;
			return true;
		}


		public async Task<bool> IsNameArExist(string name)
		{
			var Student = await _studentrepo.GetNoTracking().Where(s => s.NameAr == name).FirstOrDefaultAsync();
			if (Student == null) return false;
			return true;
		}
		public async Task<bool> IsNameArEXistWithSelf(string name, int id)
		{

			var Student = _studentrepo.GetNoTracking().Where(s => s.NameAr == name && s.Id != id).FirstOrDefault();
			if (Student == null) return false;
			return true;
		}
		public async Task<string> EditAsync(Student student)
		{
			await _studentrepo.UpdateEntity(student);
			return "Success";
		}

		public async Task<string> DeleteAsync(Student student)
		{
			try 
			{  _studentrepo.BeginTransaction();
				await _studentrepo.DeleteEntity(student);
				_studentrepo.Commit();
				return "Success";

			}
			catch
			{
				_studentrepo.RollBack();
				return "Failure";
			}
			
		}

		public IQueryable<Student> GetStudentQuerable()
		{
			return _studentrepo.GetNoTracking().Include(s => s.Department).AsQueryable();
			
		}

		public IQueryable<Student?> FilterStudentPaginatedQuerable(StudentOrderingEnum orderby, string search)
		{
			var query = _studentrepo.GetNoTracking().Include(s => s.Department).AsQueryable();
			if (search != null) { 
				query = query.Where(s => s.NameEn.Contains(search) || s.Address.Contains(search)); }
			switch (orderby)
			{
				case StudentOrderingEnum.StudID:
					query = query.OrderBy(s => s.Id);
					break;
				case StudentOrderingEnum.Address:
					query = query.OrderBy(s => s.Address);
					break;
				case StudentOrderingEnum.Name:
					query = query.OrderBy(s => s.NameEn);
					break;
				case StudentOrderingEnum.DepartmentName:
					query = query.OrderBy(s => s.Department.NameEn);
					break;
				
			}
			
			return query;
		}

		

	
	}
}