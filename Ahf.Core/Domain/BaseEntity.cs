using System;
using System.Collections.Generic;
using System.Text;

namespace Ahf.Core.Domain.BaseEntities
{
	public abstract class BaseEntity
	{
		public int ID { get; set; }
		public DateTime CreateOn { get; set; }
		public DateTime UpdateOn { get; set; }
	}
}
