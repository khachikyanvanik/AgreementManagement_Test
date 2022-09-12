using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Models
{
	public class AgreementDeleteViewModel
	{
		[Required]
		public long Id { get; set; }

		public long ProductGroupId { get; set; }

		public long ProductId { get; set; }

		public DateTime EffectiveDate { get; set; }

		public DateTime ExpireDate { get; set; }

		public decimal NewPrice { get; set; }

		public bool IsActive { get; set; }
	}
}
