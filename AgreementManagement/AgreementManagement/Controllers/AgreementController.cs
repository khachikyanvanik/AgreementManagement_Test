using AgreementManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgreementManagement.Controllers
{
	public class AgreementController : BaseController
	{
		public AgreementController(ILogger<AgreementController> logger)
			: base(logger)
		{
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetDetails(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			return View(null);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View(new AgreementCreationViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Create(AgreementCreationViewModel model)
		{
			if (ModelState.IsValid)
			{
				var currentUserId = GetUserId();
                // TODO: set creator

				return RedirectToAction(nameof(Index));
			}

			return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AgreementUpdateViewModel model)
        {
            return View(null);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(null);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<JsonResult> GetAgreements()
        {
            return Json(null);
        }
    }
}