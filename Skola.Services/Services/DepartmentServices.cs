using Microsoft.EntityFrameworkCore;
using Skola.Data.Entities;
using Skola.Data.Repositories;
using Skola.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Services.Services
{
	public class DepartmentServices : IDepartmentServices
	{
		private readonly IDepartmentRepository _departmentrepo;

		public DepartmentServices(IDepartmentRepository departmentrepo)
        {
			_departmentrepo = departmentrepo;
		}

		public async Task<bool> DepartmentIdIsExist(int departmentid)
		{
			return await _departmentrepo.GetNoTracking().AnyAsync(d => d.Id == departmentid);
		}

		public async Task<Department> GetDepartmentById(int id)
		{
			var result = await _departmentrepo.GetNoTracking().Where(x => x.Id == id)
				.Include(x => x.Instructors)
				.Include(x => x.DepartmentManager)
				.Include(x => x.Student)
				.Include(x => x.Subjects).ThenInclude(x=>x.Subject)
				.FirstOrDefaultAsync();

			return result;

		}

		
	}
}
