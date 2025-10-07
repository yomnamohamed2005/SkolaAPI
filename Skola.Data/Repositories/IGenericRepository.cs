using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Data.Repositories
{
	public interface IGenericRepository<T> where T :class 
	{
		Task<T> GetByIdAsync(int id);
		Task<T> AddEntity(T entity);
		Task AddRangeEntity(ICollection<T> entities);
		Task UpdateEntity(T entity);
		Task UpdateRangeEntity(ICollection<T> entities);
		Task DeleteEntity(T entity);
		Task DeleteRangeEntity(ICollection<T> entity);
		Task SaveChangesAsync();
		void Commit();
		void RollBack();
		IDbContextTransaction BeginTransaction();
		IQueryable<T> GetTracking();
		IQueryable<T> GetNoTracking();


	}
}
