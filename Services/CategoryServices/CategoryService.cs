using Ahf.Core.Domain;
using Ahf.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahf.Services.CategoryServices
{
	public class CategoryService : ICategoryService
	{
		private readonly IRepository<Category> _repositoryCategory = null;

		public CategoryService(IRepository<Category> repositoryCategory)
		{
			_repositoryCategory = repositoryCategory;
		}

		public void GetCategory()
		{
		var s= _repositoryCategory.Table;
		}
	}
}
