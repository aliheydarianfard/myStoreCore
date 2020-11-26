using Ahf.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahf.Services
{
	public interface IUnitOfWork
	{
		SqlServerApplicationContext GetContext();
		void SaveChanges();
		Task SaveChangesAsync();
	}
}
