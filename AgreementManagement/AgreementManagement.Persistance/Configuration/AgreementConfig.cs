using AgreementManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgreementManagement.Persistance.Configuration
{
	public class AgreementConfig : IEntityTypeConfiguration<Agreement>
	{
		public void Configure(EntityTypeBuilder<Agreement> builder)
		{
			builder.HasOne(e => e.Product)
				.WithMany(e => e.Agreements)
				.HasForeignKey(e => e.ProductId)
				.HasConstraintName("FK_Product_Agreements");

			builder.HasOne(e => e.User)
				.WithMany(e => e.Agreements)
				.HasForeignKey(e => e.CreatedByUserId)
				.HasConstraintName("FK_User_Agreements");
		}
	}
}
