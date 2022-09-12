using AgreementManagement.Interfaces.Services;
using AgreementManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgreementManagement.Controllers
{
	public class AgreementController : BaseController
	{
        public readonly IAgreementService _agreementService;
        public readonly IProductService _productService;

        public AgreementController(
            IAgreementService agreementService,
            IProductService productService,
            ILogger<AgreementController> logger)
			: base(logger)
		{
            _agreementService = agreementService;
            _productService = productService;
        }

		public IActionResult Index()
		{
            //TODO: log requests in miidleware
			return View();
        }

		public async Task<IActionResult> GetDetails(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

            var agreement = await _agreementService.GetAgreementAsync<AgreementViewModel>(id.Value);
			if (agreement != null)
			{
                return View(agreement);
            }

            return NotFound();
        }

        [HttpGet]
		public async Task<IActionResult> Create()
		{
            return View(new AgreementCreationViewModel
			{
                Products = await _productService.GetProductsAsync(),
                ProductGroups = await _productService.GetProductGroupsAsync()
			});
		}

		[HttpPost]
		public async Task<IActionResult> Create(AgreementCreationViewModel model)
		{
			if (ModelState.IsValid)
			{
				var currentUserId = GetUserId();
                await _agreementService.CreateAgreementAsync(currentUserId, model);
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

			var agreement = await _agreementService.GetAgreementAsync<AgreementUpdateViewModel>(id.Value);
			if (agreement == null)
			{
                return NotFound();
            }

            agreement.Products = await _productService.GetProductsAsync();
            agreement.ProductGroups = await _productService.GetProductGroupsAsync();
            return View(agreement);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, AgreementUpdateViewModel model)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agreement = await _agreementService.GetAgreementAsync<AgreementUpdateViewModel>(id.Value);
            if (agreement == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
				var currentUserId = GetUserId();
                await _agreementService.UpdateAgreementAsync(currentUserId, model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agreement = await _agreementService.GetAgreementAsync<AgreementDeleteViewModel>(id.Value);
            if (agreement == null)
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
            var criteria = new DataTableCriteria<AgreementViewModel>()
            {
                Draw = Convert.ToInt32(Request.Form["draw"].First()),
                Length = Convert.ToInt32(Request.Form["length"].First()),
                SearchingValue = Request.Form["search[value]"].FirstOrDefault(),
                SortingDirection = Request.Form["order[0][dir]"].FirstOrDefault(),
                Start = Convert.ToInt32(Request.Form["start"].First())
            };

            var agreements = await _agreementService.GetAgreementListAsync(criteria);

            return Json(new
            {
                draw = agreements.Draw,
                data = agreements.Data,
                recordsFiltered = agreements.RecordsTotalCount,
                recordsTotal = agreements.RecordsTotalCount
            });
        }
    }
}