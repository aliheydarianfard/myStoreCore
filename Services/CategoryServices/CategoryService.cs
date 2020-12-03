using Ahf.Core.Domain;
using Ahf.Data.Repositories;
using Ahf.Services.DTO.Categories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahf.Services.CategoryServices
{
	public class CategoryService : ICategoryService
	{
		private readonly IRepository<Category> _repositoryCategory = null;
		private readonly IMapper _mapper = null;
		public CategoryService(IRepository<Category> repositoryCategory, IMapper mapper)
		{
			_repositoryCategory = repositoryCategory;
			_mapper = mapper;
		}

		public async Task<IEnumerable<CategoryListDTO>> FindAllAsync(string SearchString)
		{
			if (SearchString == null) SearchString = "";
			var categories = await _repositoryCategory.TableNoTracking.Where(p => p.Name.Contains(SearchString)).Select(p => new CategoryListDTO
			{
				Id = p.Id,
				ParentId = p.ParentId,
				Name = p.Name,
				ParentName = p.ParentCategory.Name != null ? p.ParentCategory.Name : "دسته والد ندارد",
				Description = p.Description != null ? p.Description : "توضیحاتی ندارد",
			}).ToListAsync();
			return categories;
		}
		public async Task RegisterAsync(CategoryRegisterDTO dTO)
		{
			var category = new Category();
			_mapper.Map(dTO, category);
			if (dTO.Id == null)
				await _repositoryCategory.InsertAsync(category);
			else
				await _repositoryCategory.UpdateAsync(category);

		}
		public async Task RemoveAsync(int CategoryId)
		{
			var category = _repositoryCategory.GetById(CategoryId);
			await _repositoryCategory.DeleteAsync(category);

		}
		public async Task<bool> IsExistCategory(int CategoryId)
		{
			var category = await _repositoryCategory.GetByIdAsync(CategoryId);
			if (category == null)
				return false;
			else
				return true;

		}
		public async Task<CategoryListDTO> GetCategoryById(int CategoryId)
		{
			var category = await _repositoryCategory.GetByIdAsync(CategoryId);
			var dTO = new CategoryListDTO
			{
				Description = category.Description,
				Name = category.Name,
				ParentId = category.ParentId,
				Id=category.Id
				
			};
			return dTO;

		}
	}
}

