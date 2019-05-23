using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iTechArt.ManagementDemo.Web.Models;
using iTechArt.ManagementDemo.Web.Infrastructure.ServiceAdaptors.Interfaces;
using iTechArt.ManagementDemo.Web.Infrastructure.Filters;
using iTechArt.ManagementDemo.Web.Infrastructure.Validators.Attributes;

namespace iTechArt.ManagementDemo.Web.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationServiceAdapter _service;


        public LocationsController(ILocationServiceAdapter service)
        {
            _service = service;
        }


        [HttpGet]
        [TreatNullAsNotFound]
        public async Task<IActionResult> Details(int id) =>
            View(await _service.FindAsync(id));

        [HttpGet]
        [TreatNullAsNotFound]
        [UseClientSideCompatibleValidation]
        public async Task<IActionResult> Edit(int id) =>
            View(await _service.FindAsync(id));

        [HttpPost]
        [UseClientSideCompatibleValidation]
        public IActionResult Create(
            int companyId = 0, string companyName = null) =>
            View(
                nameof(Edit),
                new LocationModel
                {
                    CompanyId = companyId,
                    CompanyName = companyName,
                });

        [HttpPost, ValidateAntiForgeryToken]
        [UseClientSideCompatibleValidation]
        public async Task<IActionResult> Edit(LocationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var id = await _service.SaveAsync(model);

            return RedirectToAction(
                nameof(Edit), new { id });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var companyId = await _service.
                TryDeleteLocationAndGetCompanyIdAsync(id);

            if (!companyId.HasValue)
            {
                return NotFound();
            }

            return RedirectToAction(
                nameof(CompaniesController.Details),
                "Companies",
                new { id = companyId },
                "Locations");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Clone(
            int id, bool shouldTransferEmployees)
        {
            var cloneId = await _service.CloneLocationAsync(
                id, shouldTransferEmployees);

            if (!cloneId.HasValue)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Edit), new { id = cloneId });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Transfer(
            int id, int destinationId, bool shouldDelete)
        {
            if (!await _service
                .TryTransferAsync(id, destinationId, shouldDelete))
            {
                return BadRequest();
            }

            return RedirectToAction(
                nameof(Edit), new { id = destinationId });
        }

        [HttpPut]
        public async Task<IActionResult> Employees(
            int id, [FromBody]QueryOptionsModel options) =>
            Ok(await _service.QueryEmployeesAsync(id, options));

        [HttpGet]
        public async Task<IActionResult> Autocomplete(int companyId) =>
            Ok(await _service.GetLocationsIndex(companyId));
    }
}
