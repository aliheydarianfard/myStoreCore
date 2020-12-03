using Ahf.Services.DTO.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahf.Services.CategoryServices
{
	public interface ICategoryService
	{
		Task<IEnumerable<CategoryListDTO>> FindAllAsync(string SearchString);
		Task<CategoryListDTO> GetCategoryById(int CategoryId);
		Task<bool> IsExistCategory(int CategoryId);
		Task RegisterAsync(CategoryRegisterDTO dTO);
		Task RemoveAsync(int CategoryId);
	}
}
