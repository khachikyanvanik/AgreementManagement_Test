using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Models
{
	public class AgreementViewModel
	{
		public long Id { get; set; }

		public string Username { get; set; }

		public string ProductGroupCode { get; set; }

		public string ProductNumber { get; set; }

		public DateTime EffectiveDate { get; set; }

		public DateTime ExpireDate { get; set; }

		public decimal ProductPrice { get; set; }

		public decimal ProductNewPrice { get; set; }
	}
}
