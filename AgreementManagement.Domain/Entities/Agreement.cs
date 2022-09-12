using AgreementManagement.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Domain.Entities
{
	public class Agreement : BaseEntity<long>, ICreator, IDeletable
	{
		public long ProductId { get; set; }

		public DateTime EffectiveDate { get; set; }

		public DateTime ExpireDate { get; set; }

		public decimal ProductPrice { get; set; }

		public Guid CreatedByUserId { get; set; }

		public DateTime CreateDate { get; set; }

		public bool IsDeleted { get; set; }

		public Product Product { get; set; }

		public ApplicationUser User { get; set; }
	}
}
