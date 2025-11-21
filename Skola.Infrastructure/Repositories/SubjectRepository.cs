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
	public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
	{
		private readonly dbcontext context;

		public SubjectRepository(dbcontext context) : base(context)
		{
			this.context = context;
		}
	}
}
