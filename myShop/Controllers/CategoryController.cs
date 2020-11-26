using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahf.Core.Domain;
using Ahf.Data.Repositories;
using Ahf.Services.CategoryServices;
using Ahf.Services.DTO.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myShop.Utilities;
using Newtonsoft.Json;
namespace myShop.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CategoryController : Controller
	{
		#region Fileds
		private readonly ICategoryService _categoryService=null;

		#endregion
		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		#region Get
		
		[HttpGet("GetAll")]
		public async Task<IActionResult> TestCategoryAsync()
		{
			var Caregories = await _categoryService.FindAllAsync();
			return Ok(Caregories);
		}
		#endregion
		#region Insert
		[HttpPost("Insert")]
		public IActionResult InsertCategory([FromBody] CategoryRegisterDTO dTO)
		{
			var Caregories = _categoryService.RegisterAsync(dTO);
			return SuccessMessageHandler.InsertCategory();
		}
		#endregion
	}
}
