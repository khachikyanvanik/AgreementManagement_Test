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
		}
	}
}
