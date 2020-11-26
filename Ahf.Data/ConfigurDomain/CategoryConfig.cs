using Ahf.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahf.Data.ConfigurDomain
{
	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasMany(p => p.Children).WithOne(p => p.ParentCategory).
			   HasForeignKey(p => p.ParentId).OnDelete(DeleteBehavior.NoAction);
		}
	}

}
