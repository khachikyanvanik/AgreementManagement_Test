using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AgreementManagement.Models
{
	public class AgreementCreationViewModel
	{
		public AgreementCreationViewModel()
		{
			Products = new List<SelectListItem>();
			ProductGroups = new List<SelectListItem>();
		}

		[Required]
		public int ProductGroupId { get; set; }

		[Required]
		public int ProductId { get; set; }

		[Required]
		public DateTime EffectiveDate { get; set; }

		[Required]
		public DateTime ExpireDate { get; set; }

		[Required]
		public long NewPrice { get; set; }

		[Required]
		public bool IsActive { get; set; }

		public List<SelectListItem> Products { get; set; }

		public List<SelectListItem> ProductGroups { get; set; }
	}
}
