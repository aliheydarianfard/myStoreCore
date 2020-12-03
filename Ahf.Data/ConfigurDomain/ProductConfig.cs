using Ahf.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahf.Data.ConfigurDomain
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(p => p.ProductName).IsRequired().HasMaxLength(400);
			builder.Property(p => p.Sku).IsRequired().HasMaxLength(50);
			builder.Property(p => p.Price).IsRequired();
		}
	}
}
