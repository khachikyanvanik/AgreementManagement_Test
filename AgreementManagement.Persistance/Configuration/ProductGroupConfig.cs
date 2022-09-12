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
	public class ProductGroupConfig : IEntityTypeConfiguration<ProductGroup>
	{
		public void Configure(EntityTypeBuilder<ProductGroup> builder)
		{
			builder.Property(e => e.Code)
				.HasMaxLength(100);

			builder.HasIndex(i => i.Code).IsUnique();

			#region SeedData
			builder.HasData(
				new ProductGroup
				{
					Id = 1,
					Code = "Code_1",
					IsActive = true,
					Description = "Undrstandable description"
				},
				new ProductGroup
				{
					Id = 2,
					Code = "Code_2",
					IsActive = true,
					Description = "Some group"
				}, new ProductGroup
				{
					Id = 3,
					Code = "Code_3",
					IsActive = false,
					Description = "Any Description"
				});
			#endregion
		}
	}
}
