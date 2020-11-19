using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace myShop.Controllers
{
	[Route("Admin/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		[HttpGet("first")]
		public IActionResult TestCategory()
		{
			return Ok("Suscces");
		}
	}
}
