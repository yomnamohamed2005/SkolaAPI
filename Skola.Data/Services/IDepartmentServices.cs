using Skola.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Data.Services
{
	public  interface IDepartmentServices
	{
       public Task<Department> GetDepartmentById(int id);

        public Task<bool> DepartmentIdIsExist(int departmentid);

    }
}
