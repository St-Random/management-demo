using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iTechArt.ManagementDemo.Web.Models;
using iTechArt.ManagementDemo.Web.Infrastructure.ServiceAdaptors.Interfaces;
using iTechArt.ManagementDemo.Web.Infrastructure.Filters;
using iTechArt.ManagementDemo.Querying;
using FluentValidation.AspNetCore;

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
        [RuleSetForClientSideMessages("ClientCompatible")]
        public async Task<IActionResult> Edit(int id) =>
            View(await _service.FindAsync(id));

        [HttpPost]
        [RuleSetForClientSideMessages("ClientCompatible")]
        public IActionResult Create() =>
            View(nameof(Edit), new CompanyModel());

        [HttpPost, ValidateAntiForgeryToken]
        [RuleSetForClientSideMessages("ClientCompatible")]
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

        [HttpDelete, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> List(QueryOptions options) =>
            Ok(await _service.QueryAsync(options));

        [HttpGet]
        public async Task<IActionResult> Locations(
            int id, QueryOptions options) =>
            Ok(await _service.QueryLocationsAsync(id, null));

        [HttpGet]
        public async Task<IActionResult> Employees(
            int id, QueryOptions options) =>
            Ok(await _service.QueryEmployeesAsync(id, null));
    }
}
