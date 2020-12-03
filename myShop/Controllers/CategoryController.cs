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
		private readonly ICategoryService _categoryService = null;

		#endregion
		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		#region Get

		[HttpGet("GetAll/{SrarchString?}")]
		public async Task<IActionResult> GetAllCategoryAsync(string? SrarchString)
		{
			var Caregories = await _categoryService.FindAllAsync(SrarchString);
			return Ok(Caregories);
		}
		#endregion
		#region Insert
		[HttpPost("Insert")]
		public async Task<IActionResult> InsertCategoryAsync([FromBody] CategoryRegisterDTO dTO)
		{
			await _categoryService.RegisterAsync(dTO);
			if (dTO.Id != 0)
				return SuccessMessageHandler.EditCategory();
			else
					return SuccessMessageHandler.InsertCategory();
			}
			#endregion
			#region Delete
			[HttpDelete("Delete/{CategoryId}")]
			public async Task<IActionResult> DeleteCategoryAsync(int CategoryId)
			{
				await _categoryService.RemoveAsync(CategoryId);
				return SuccessMessageHandler.DeleteCategory();
			}
			#endregion
			#region IsExistCategory
			[HttpGet("IsExistCategory/{CategoryId}")]
			public async Task<IActionResult> IsExistCategory(int CategoryId)
			{
				var isExist = await _categoryService.IsExistCategory(CategoryId);
				return Ok(isExist);
			}
			#endregion
			#region IsExistCategory
			[HttpGet("GetCategoryById/{CategoryId}")]
			public async Task<IActionResult> GetCategoryById(int CategoryId)
			{
				var category = await _categoryService.GetCategoryById(CategoryId);
				return Ok(category);
			}
			#endregion
		}
	}

