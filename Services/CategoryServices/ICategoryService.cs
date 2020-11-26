using Ahf.Services.DTO.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahf.Services.CategoryServices
{
	public interface ICategoryService
	{
		Task<IEnumerable<CategoryListDTO>> FindAllAsync();
		Task RegisterAsync(CategoryRegisterDTO dTO);
	}
}
