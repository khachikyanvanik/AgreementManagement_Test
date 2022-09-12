using AgreementManagement.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Domain.Entities
{
	public class ProductGroup : BaseEntity<long>, IDeletable
	{
		public string Description { get; set; }

		public string Code { get; set; }

		public bool IsActive { get; set; }

		public bool IsDeleted { get; set; }

		public virtual ICollection<Product> Products  { get; set; }
	}
}
