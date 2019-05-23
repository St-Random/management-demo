using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iTechArt.ManagementDemo.Web.Models;
using iTechArt.ManagementDemo.Web.Infrastructure.ServiceAdaptors.Interfaces;
using iTechArt.ManagementDemo.Web.Infrastructure.Filters;
using iTechArt.ManagementDemo.Web.Infrastructure.Validators.Attributes;

namespace iTechArt.ManagementDemo.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeServiceAdapter _service;


        public EmployeesController(IEmployeeServiceAdapter service)
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
        public IActionResult Create(
            int companyId = 0,
            string companyName = null,
            int locationId = 0,
            string locationName = null) =>
            View(
                nameof(Edit),
                new EmployeeModel
                {
                    CompanyId = companyId,
                    CompanyName = companyName,
                    LocationId = locationId,
                    LocationName = locationName
                });

        [HttpPost, ValidateAntiForgeryToken]
        [UseClientSideCompatibleValidation]
        public async Task<IActionResult> Edit(EmployeeModel model)
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

    }
}
