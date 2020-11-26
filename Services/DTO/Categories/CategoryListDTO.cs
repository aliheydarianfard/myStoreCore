using System;
using System.Collections.Generic;
using System.Text;

namespace Ahf.Services.DTO.Categories
{
	public class CategoryListDTO:BaseDTO
	{
		public string Name { get; set; }
		public string ParentName { get; set; }
		public string Description { get; set; }
	}
}
