using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Models
{
	public class AgreementUpdateViewModel
	{
		public AgreementUpdateViewModel()
		{
			Products = new List<SelectListItem>();
			ProductGroups = new List<SelectListItem>();
		}

		[Required]
		public long Id { get; set; }

		[Required]
		public long ProductGroupId { get; set; }

		[Required]
		public long ProductId { get; set; }

		[Required]
		public DateTime EffectiveDate { get; set; }

		[Required]
		public DateTime ExpireDate { get; set; }

		[Required]
		public decimal NewPrice { get; set; }

		[Required]
		public bool IsActive { get; set; }

		public List<SelectListItem> Products { get; set; }

		public List<SelectListItem> ProductGroups { get; set; }
	}
}
