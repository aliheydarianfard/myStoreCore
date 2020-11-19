using Ahf.Core.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahf.Data.Repositories
{
	public partial interface IRepository<TEntity> where TEntity:BaseEntity
	{


		TEntity GetById(params object[] ids);

		void Insert(TEntity entity);

		void Update(TEntity entity);

		void Delete(TEntity entity);

		IQueryable<TEntity> Table { get; }

		IQueryable<TEntity> TableNoTracking { get; }

		TEntity GetByIdAsNoTracking(params object[] ids);
		System.Threading.Tasks.Task DeleteAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
		System.Threading.Tasks.Task InsertAsync(TEntity entity);
		System.Threading.Tasks.Task<TEntity> GetByIdAsync(params object[] ids);
		System.Threading.Tasks.Task<TEntity> GetByIdAsNoTrackingAsync(params object[] ids);
	}
}
