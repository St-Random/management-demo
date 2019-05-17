using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iTechArt.ManagementDemo.Web.Models;
using iTechArt.ManagementDemo.Web.Infrastructure.ServiceAdaptors.Interfaces;
using iTechArt.ManagementDemo.Web.Infrastructure.Filters;
using FluentValidation.AspNetCore;
using iTechArt.ManagementDemo.Querying;

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
        [RuleSetForClientSideMessages("ClientCompatible")]
        public async Task<IActionResult> Edit(int id) =>
            View(await _service.FindAsync(id));

        [HttpPost]
        [RuleSetForClientSideMessages("ClientCompatible")]
        public IActionResult Create() =>
            View(nameof(Edit), new CompanyModel());

        [HttpPost, ValidateAntiForgeryToken]
        [RuleSetForClientSideMessages("ClientCompatible")]
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

        [HttpDelete, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> List(
            [FromBody]QueryOptionsModel options) =>
            Ok(await _service.QueryAsync(options));

    }
}
