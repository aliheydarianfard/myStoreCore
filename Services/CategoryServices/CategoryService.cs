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
		public CategoryService(IRepository<Category> repositoryCategory,IMapper mapper)
		{
			_repositoryCategory = repositoryCategory;
			_mapper = mapper;
		}

		public async Task<IEnumerable<CategoryListDTO>> FindAllAsync()
		{
			var categories =await _repositoryCategory.TableNoTracking.Select(p => new CategoryListDTO
			{
				Id = p.Id,
				Name = p.Name,
				ParentName = p.ParentCategory.Name!=null ? p.ParentCategory.Name:"دسته والد ندارد",
				Description = p.Description!=null? p.Description:"توضیحاتی ندارد",
			}).ToListAsync();
			return categories;
		}
		public async Task RegisterAsync(CategoryRegisterDTO dTO)
		{
			var category = new Category();
			_mapper.Map(dTO, category);
		await _repositoryCategory.InsertAsync(category);
		}
	}
}
