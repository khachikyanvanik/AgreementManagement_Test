using AgreementManagement.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Domain.Entities
{
	public class Product : BaseEntity<long>, IDeletable
	{
		public long ProductGroupId { get; set; }

		public decimal Price { get; set; }

		public string Description { get; set; }

		public string Code { get; set; }

		public bool IsActive { get; set; }

		public bool IsDeleted { get; set; }

		public virtual ProductGroup ProductGroup { get; set; }

		public virtual ICollection<Agreement> Agreements { get; set; }
	}
}
