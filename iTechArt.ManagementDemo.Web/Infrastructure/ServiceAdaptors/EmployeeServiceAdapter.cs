using AutoMapper;
using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Models;
using iTechArt.ManagementDemo.Services.DTO;
using iTechArt.ManagementDemo.Services.Interfaces;
using iTechArt.ManagementDemo.Web.Infrastructure.ServiceAdaptors.Interfaces;
using iTechArt.ManagementDemo.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.Web.Infrastructure.ServiceAdaptors
{
    public class EmployeeServiceAdapter
        : AbstractServiceAdapter<EmployeeDTO, EmployeeModel>,
        IEmployeeServiceAdapter
    {
        private readonly IEmployeeService _service;


        public EmployeeServiceAdapter(
            IMapper mapper,
            IEmployeeService service)
            : base(mapper, service)
        {
            _service = service ?? throw new NullReferenceException();
        }


        public async Task<IQueryResult<EmployeeQueryModel>> QueryAsync(
            IQueryOptions options) =>
            await _service.QueryAsync(options);

        public async Task<IEnumerable<NamedQueryModel>>
            GetCompaniesAvailableForTransferAsync() =>
            await _service.GetCompaniesAvailableForTransferAsync();

        public async Task<IEnumerable<NamedQueryModel>>
            GetLocationsAvailableForTransferAsync(int companyId) =>
            await _service.GetLocationsAvailableForTransferAsync(companyId);

    }
}
