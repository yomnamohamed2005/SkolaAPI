using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using Skola.Data.Repositories;
using Skola.Infrastructure.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Infrastructure.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly dbcontext _dbcontext;

		public GenericRepository(dbcontext dbcontext)
        {
			this._dbcontext = dbcontext;
		}
        public async Task<T> AddEntity(T entity)
		{
			await _dbcontext.Set<T>().AddAsync(entity);
		 await	_dbcontext.SaveChangesAsync();
			return entity;
		}

		public async Task AddRangeEntity(ICollection<T> entities)
		{
			await _dbcontext.Set<T>().AddRangeAsync(entities);
			await _dbcontext.SaveChangesAsync();
		}

		public IDbContextTransaction BeginTransaction()
		{
			 return _dbcontext.Database.BeginTransaction();
		}

		public void Commit()
		{
			 _dbcontext.Database.CommitTransaction();
		}

		public async Task DeleteEntity(T entity)
		{
			_dbcontext.Set<T>().Remove(entity);
			await _dbcontext.SaveChangesAsync();
		}

		public async Task DeleteRangeEntity(ICollection<T> entity)
		{
			_dbcontext.Set<T>().RemoveRange(entity);
			await _dbcontext.SaveChangesAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			 var entity = await _dbcontext.Set<T>().FindAsync(id);
			return entity;

		}

		public IQueryable<T> GetNoTracking()
		{
		return	_dbcontext.Set<T>().AsNoTracking().AsQueryable();
		}

		public IQueryable<T> GetTracking()
		{
			return _dbcontext.Set<T>().AsQueryable();
		}

		public void RollBack()
		{
			_dbcontext.Database.RollbackTransaction();
		}

		public async Task SaveChangesAsync()
		{
			await _dbcontext.SaveChangesAsync();
		}

		public async Task UpdateEntity(T entity)
		{
			_dbcontext.Set<T>().Update(entity);
			await _dbcontext.SaveChangesAsync();
		}

		public async Task UpdateRangeEntity(ICollection<T> entities)
		{
			_dbcontext.UpdateRange(entities);
			await _dbcontext.SaveChangesAsync();
		}
	}
}
