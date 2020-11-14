using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Services.UnitOfWork
{
	public class UnitOfWork:IUnitOfWork
	{
		#region Fields
		private readonly IConfiguration _configuration;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IHostEnvironment _environment;
		//private readonly IPermissionsCache _permissionsCache;
		#endregion
		public UnitOfWork(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IHostEnvironment environment)
		{
			_configuration = configuration;
			_httpContextAccessor = httpContextAccessor;
			_environment = environment;
		}
	}
}
