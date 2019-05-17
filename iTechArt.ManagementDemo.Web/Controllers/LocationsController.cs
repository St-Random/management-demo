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
        [RuleSetForClientSideMessages("ClientCompatible")]
        public async Task<IActionResult> Edit(int id) =>
            View(await _service.FindAsync(id));

        [HttpPost]
        [RuleSetForClientSideMessages("ClientCompatible")]
        public IActionResult Create() =>
            View(nameof(Edit), new CompanyModel());

        [HttpPost, ValidateAntiForgeryToken]
        [RuleSetForClientSideMessages("ClientCompatible")]
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

        [HttpDelete, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
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

        [HttpGet]
        public async Task<IActionResult> Employees(
            int id, QueryOptions options) =>
            Ok(await _service.QueryEmployeesAsync(id, options));

        [HttpGet]
        public async Task<IActionResult> Autocomplete(int companyId) =>
            Ok(await _service.GetLocationsIndex(companyId));
    }
}
