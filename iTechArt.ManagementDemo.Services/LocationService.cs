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
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.Services
{
    internal class LocationService
        : Service<Location, LocationDTO>, ILocationService
    {
        private readonly IQueryHandler<Employee, LocationEmployeeModel>
            _employeeQueryHandler;
        private readonly IQueryHandler<Location, NamedQueryModel>
            _locationQueryHandler;


        public LocationService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IRepository<Location> repository,
            IQueryHandler<Employee, LocationEmployeeModel>
                employeeQueryHandler,
            IQueryHandler<Location, NamedQueryModel> locationQueryHandler,
            ILogger<LocationService> logger = null)
            : base(mapper, unitOfWork, repository, logger)
        {
            _employeeQueryHandler = employeeQueryHandler
                ?? throw new NullReferenceException();
            _locationQueryHandler = locationQueryHandler
                ?? throw new NullReferenceException();
        }


        public async Task<IQueryResult<LocationEmployeeModel>>
            QueryEmployeesAsync(int locationId, IQueryOptions options) =>
            await _employeeQueryHandler.QueryAsync(
                options, e => e.LocationId == locationId);

        public async Task<IEnumerable<NamedQueryModel>>
            GetLocationsAvailableForTransferAsync(int sourceLocationId)
        {
            var sourceLocation = await _repository.FindAsync(sourceLocationId);

            if (sourceLocation == null)
            {
                return Enumerable.Empty<NamedQueryModel>();
            }

            var companyId = sourceLocation.CompanyId;

            return await _locationQueryHandler
                .GetAsync(l => l.CompanyId == companyId
                    && l.Id != sourceLocationId);
        }


        public async Task<int?> CloneLocationAsync(
            int sourceLocationId, bool shouldTransferEmployeesFromSource)
        {
            var source = await _repository.FindAsync(sourceLocationId);

            if (source == null)
            {
                return null;
            }

            var clonedLocation = _mapper.Map<Location>(source);

            clonedLocation.Id = 0;

            var transaction = await _unitOfWork
                .BeginTransactionAsync(IsolationLevel.Serializable);

            try
            {
                await _repository.AddAsync(clonedLocation);

                if (shouldTransferEmployeesFromSource)
                {
                    foreach (var employee in source.Employees)
                    {
                        clonedLocation.Employees.Add(employee);
                    }

                    source.Employees.Clear();
                }

                await _unitOfWork.SaveChangesAsync();
                transaction.Commit();

                return clonedLocation.Id;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<bool> TryTransferAsync(
            int sourceLocationId,
            int destinationLocationId,
            bool shouldDeleteSourceAfterTransfer)
        {
            var source = await _repository
                .FindAsync(sourceLocationId);
            var destination = await _repository
                .FindAsync(destinationLocationId);

            if (source == null || destination == null
                || source.CompanyId != destination.CompanyId)
            {
                return false;
            }

            var transaction = await _unitOfWork
                .BeginTransactionAsync(IsolationLevel.Serializable);

            try
            {
                foreach (var employee in source.Employees)
                {
                    destination.Employees.Add(employee);
                }
                source.Employees.Clear();

                if (shouldDeleteSourceAfterTransfer)
                {
                    _repository.Remove(source);
                }

                await _unitOfWork.SaveChangesAsync();
                transaction.Commit();

                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
