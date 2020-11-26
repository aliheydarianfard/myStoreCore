using System;
using System.Collections.Generic;
using System.Text;

namespace Ahf.Services.DTO.Categories
{
	public class CategoryRegisterDTO
	{
		public string Name { get; set; }
		public int? ParentId { get; set; }
		public string Description { get; set; }
	}
}
