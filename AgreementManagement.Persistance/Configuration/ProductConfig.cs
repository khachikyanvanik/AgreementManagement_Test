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

			#region SeedData
			builder.HasData(
				new Product
				{
					Id = 1,
					Number = "0001",
					Price = 2000M,
					IsActive = true,
					ProductGroupId = 1,
					Description = "Very interesting description for this product"
				},
				new Product
				{
					Id = 2,
					Number = "0002",
					Price = 5000M,
					IsActive = true,
					ProductGroupId = 2,
					Description = "Some description for this product"
				}, new Product
				{
					Id = 3,
					Number = "0003",
					Price = 1200M,
					IsActive = false,
					ProductGroupId = 2,
					Description = "Short Description"
				});
			#endregion
		}
	}
}
