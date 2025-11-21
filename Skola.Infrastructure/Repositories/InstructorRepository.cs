using Microsoft.EntityFrameworkCore.Storage;
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
	public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
	{
		private readonly dbcontext _dbcontext;

		public InstructorRepository(dbcontext context) : base(context)
		{
	
			this._dbcontext = context;
		}

	}
}
