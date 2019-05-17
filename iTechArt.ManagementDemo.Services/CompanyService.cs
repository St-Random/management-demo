using AutoMapper;
using iTechArt.ManagementDemo.DataAccess.Interfaces;
using iTechArt.ManagementDemo.Entities;
using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Models;
using iTechArt.ManagementDemo.Services.DTO;
using iTechArt.ManagementDemo.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.Services
{
    internal class CompanyService
        : Service<Company, CompanyDTO>, ICompanyService
    {
        private readonly IQueryHandler<Company, CompanyQueryModel>
            _queryHandler;
        private readonly IQueryHandler<Company, NamedQueryModel>
            _namedQueryHandler;
        private readonly IQueryHandler<Location, CompanyLocationModel>
            _locationQueryHandler;
        private readonly IQueryHandler<Employee, CompanyEmployeeModel>
            _employeeQueryHandler;


        public CompanyService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IRepository<Company> repository,
            IQueryHandler<Company, CompanyQueryModel> queryHandler,
            IQueryHandler<Company, NamedQueryModel> namedQueryHandler,
            IQueryHandler<Location, CompanyLocationModel> locationQueryHandler,
            IQueryHandler<Employee, CompanyEmployeeModel> employeeQueryHandler,
            ILogger<CompanyService> logger = null)
            : base(mapper, unitOfWork, repository, logger)
        {
            _queryHandler = queryHandler
                ?? throw new NullReferenceException();
            _namedQueryHandler = namedQueryHandler
                ?? throw new NullReferenceException();
            _employeeQueryHandler = employeeQueryHandler
                ?? throw new NullReferenceException();
            _locationQueryHandler = locationQueryHandler
                ?? throw new NullReferenceException();
        }


        public async Task<IQueryResult<CompanyQueryModel>> QueryAsync(
            IQueryOptions options) =>
            await _queryHandler.QueryAsync(options ?? new QueryOptions());

        public async Task<IQueryResult<CompanyLocationModel>>
            QueryLocationsAsync(int companyId, IQueryOptions options) =>
            await _locationQueryHandler.QueryAsync(
                options, l => l.Id == companyId);

        public async Task<IQueryResult<CompanyEmployeeModel>>
            QueryEmployeesAsync(int companyId, IQueryOptions options) =>
            await _employeeQueryHandler.QueryAsync(
                options, e => e.Location.CompanyId == companyId);

        public async Task<IEnumerable<NamedQueryModel>> GetCompaniesIndex() =>
            await _namedQueryHandler.GetAsync();
    }
}
