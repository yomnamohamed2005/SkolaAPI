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
	public class StudentRepository :GenericRepository<Student> ,IStudentRepository
	{
		private readonly dbcontext _dbcontext;
		private readonly DbSet<Student> _dbset;
		public StudentRepository(dbcontext dbcontext) : base(dbcontext)
        {
			_dbset = dbcontext.Set<Student>();
		}
        public async Task<List<Student>> GetStudentsAsync()
		{
			return await _dbset.Include(s=>s.Department).ToListAsync();
		}
	}
}
