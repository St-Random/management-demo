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
    public class CompanyServiceAdapter
        : AbstractServiceAdapter<CompanyDTO, CompanyModel>,
        ICompanyServiceAdapter
    {
        private readonly ICompanyService _service;


        public CompanyServiceAdapter(
            IMapper mapper,
            ICompanyService service)
            : base(mapper, service)
        {
            _service = service ?? throw new NullReferenceException();
        }


        public async Task<IQueryResult<CompanyQueryModel>> QueryAsync(
            IQueryOptions options) =>
            await _service.QueryAsync(options);

        public async Task<IQueryResult<CompanyEmployeeModel>>
            QueryEmployeesAsync(int companyId, IQueryOptions options) =>
            await _service.QueryEmployeesAsync(companyId, options);

        public async Task<IQueryResult<CompanyLocationModel>>
            QueryLocationsAsync(int companyId, IQueryOptions options) =>
            await _service.QueryLocationsAsync(companyId, options);

        public async Task<IEnumerable<NamedQueryModel>> GetCompaniesIndex() =>
            await _service.GetCompaniesIndex();
    }
}
