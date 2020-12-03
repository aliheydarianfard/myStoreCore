using Ahf.Core.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahf.Core.Domain
{
	public class Product:BaseEntity
	{
		public string ProductName { get; set; }
		public int Price { get; set; }
		public string Sku { get; set; }
		public string Description { get; set; }
		public int StockQuantity { get; set; }
		public bool Deleted { get; set; }
		public virtual Category Category { get; set; }
	}
}
