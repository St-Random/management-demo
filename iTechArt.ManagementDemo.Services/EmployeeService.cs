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
    internal class EmployeeService
        : Service<Employee, EmployeeDTO>, IEmployeeService
    {
        private readonly IQueryHandler<Employee, EmployeeQueryModel>
            _queryHandler;
        private readonly IQueryHandler<Company, NamedQueryModel>
            _companyQueryHandler;
        private readonly IQueryHandler<Location, NamedQueryModel>
            _locationQueryHandler;


        public EmployeeService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IRepository<Employee> repository,
            IQueryHandler<Employee, EmployeeQueryModel> queryHandler,
            IQueryHandler<Company, NamedQueryModel> companyQueryHandler,
            IQueryHandler<Location, NamedQueryModel> locationQueryHandler,
            ILogger<EmployeeService> logger = null)
            : base(mapper, unitOfWork, repository, logger)
        {
            _queryHandler = queryHandler
                ?? throw new NullReferenceException();
            _companyQueryHandler = companyQueryHandler
                ?? throw new NullReferenceException();
            _locationQueryHandler = locationQueryHandler
                ?? throw new NullReferenceException();
        }


        public async Task<IQueryResult<EmployeeQueryModel>> QueryAsync(
            IQueryOptions options) =>
            await _queryHandler.QueryAsync(options);

        public async Task<IEnumerable<NamedQueryModel>>
            GetCompaniesAvailableForTransferAsync() =>
            await _companyQueryHandler.GetAsync();

        public async Task<IEnumerable<NamedQueryModel>>
            GetLocationsAvailableForTransferAsync(int companyId) =>
            await _locationQueryHandler.GetAsync(
                l => l.CompanyId == companyId);
    }
}
