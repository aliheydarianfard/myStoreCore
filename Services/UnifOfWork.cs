using Ahf.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahf.Services
{
	public class UnifOfWork:IUnitOfWork
	{
		private readonly SqlServerApplicationContext _context;
		private readonly IConfiguration _configuration;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IHostEnvironment _environment;
		public UnifOfWork(SqlServerApplicationContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IHostEnvironment environment)
		{
			_context = context;
			_configuration = configuration;
			_httpContextAccessor = httpContextAccessor;
			_environment = environment;
		}
        #region SaveChanges
        public void SaveChanges()
        {
            //_context.ApplyCorrectYeKe();
            _context.SaveChanges();
        }
        #endregion
        #region SaveChangesAsync
        public async Task SaveChangesAsync()
        {
            //context.ApplyCorrectYeKe();
            await _context.SaveChangesAsync();
        }
        #endregion
        #region GetContext
        public SqlServerApplicationContext GetContext()
        {
            return _context;
        }
        #endregion
    }

}
