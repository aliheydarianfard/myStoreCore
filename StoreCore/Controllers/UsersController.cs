using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity.AuthenticateHandlers;
using identity.AuthenticateHandlers.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace StoreCore.Controllers
{
		[Route("[controller]")]
	public class UsersController : Controller
	{
		#region Filed
		private readonly IJWTHandler _jWTHandler;
		#endregion

		public UsersController(IJWTHandler jWTHandler)
		{
			_jWTHandler = jWTHandler;
		}
		[HttpGet("index")]
		public IActionResult Index()
		{
			string token = null;
			var data = new JWTDTO()
			{
				admin = false,
				user_id = 12312,
				company_id = 123123,
				my_company_id = 0,
				company_min_credit = 0,
				roleId = 2,
				licenseNo = "-",
				mobile = "-",
				loginName = "094498456464",
				email = "-",
				logged_in = true,
				services = new List<int>(),
				type = "AGENT"
			};
			token = _jWTHandler.GenerateToken(data);
			return Ok(token);
		}
	}
}
