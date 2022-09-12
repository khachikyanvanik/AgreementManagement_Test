using AgreementManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AgreementManagement.Controllers
{
	public abstract class BaseController : Controller
	{
		protected readonly ILogger Logger;

		public BaseController(ILogger logger)
		{
			Logger = logger;
		}

		protected Guid GetUserId()
		{
			return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
		}
	}
}