using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iTechArt.ManagementDemo.Web.Models;
using iTechArt.ManagementDemo.Web.Infrastructure.ServiceAdaptors.Interfaces;
using iTechArt.ManagementDemo.Web.Infrastructure.Filters;
using iTechArt.ManagementDemo.Web.Infrastructure.Validators.Attributes;

namespace iTechArt.ManagementDemo.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyServiceAdapter _service;


        public CompaniesController(ICompanyServiceAdapter service)
        {
            _service = service;
        }


        public IActionResult Index() =>
            View();

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
        public IActionResult Create() =>
            View(nameof(Edit), new CompanyModel());

        [HttpPost, ValidateAntiForgeryToken]
        [UseClientSideCompatibleValidation]
        public async Task<IActionResult> Edit(CompanyModel model)
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
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPut]
        public async Task<IActionResult> List(
            [FromBody]QueryOptionsModel options) =>
            Ok(await _service.QueryAsync(options));

        [HttpPut]
        public async Task<IActionResult> Locations(
            int id, [FromBody]QueryOptionsModel options) =>
            Ok(await _service.QueryLocationsAsync(id, options));

        [HttpPut]
        public async Task<IActionResult> Employees(
            int id, [FromBody]QueryOptionsModel options) =>
            Ok(await _service.QueryEmployeesAsync(id, options));

        [HttpGet]
        public async Task<IActionResult> Autocomplete() =>
            Ok(await _service.GetCompaniesIndex());
    }
}
