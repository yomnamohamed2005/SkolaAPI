using Microsoft.EntityFrameworkCore;
using Skola.Data.Entities;
using Skola.Data.Repositories;
using Skola.Infrastructure.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Infrastructure.Repositories
{
	public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
	{
		private readonly dbcontext _dbcontext;
		private readonly DbSet<Department> _dbset;
		public DepartmentRepository(dbcontext dbcontext) : base(dbcontext)
		{
			_dbcontext = dbcontext;
			_dbset = _dbcontext.Set<Department>();
		}
	}
}
