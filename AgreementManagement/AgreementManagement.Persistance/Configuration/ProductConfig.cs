using AgreementManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Persistance.Configuration
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(e => e.Number)
				.HasMaxLength(100);

			builder.HasOne(e => e.ProductGroup)
				.WithMany(e => e.Products)
				.HasForeignKey(e => e.ProductGroupId)
				.HasConstraintName("FK_ProductGroup_Products");

			builder.HasIndex(i => i.Number).IsUnique();
		}
	}
}
