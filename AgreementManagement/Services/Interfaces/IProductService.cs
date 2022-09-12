using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Interfaces.Services
{
	public interface IProductService
	{
		Task<List<SelectListItem>> GetProductsAsync();
		Task<List<SelectListItem>> GetProductGroupsAsync();
	}
}
