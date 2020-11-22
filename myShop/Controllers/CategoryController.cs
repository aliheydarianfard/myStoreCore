using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahf.Core.Domain;
using Ahf.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace myShop.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		#region Fileds
		private readonly IRepository<Category> _repositoryCategory = null;

		public CategoryController(IRepository<Category> repositoryCategory)
		{
			_repositoryCategory = repositoryCategory;
		}
		#endregion
		[HttpGet("GetAll")]
		public IActionResult TestCategory()
		{
			var s =  _repositoryCategory.TableNoTracking.ToList();
			return Ok(s);
		}
	}
}
