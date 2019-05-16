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
    public class LocationServiceAdapter
        : AbstractServiceAdapter<LocationDTO, LocationModel>,
        ILocationServiceAdapter
    {
        private readonly ILocationService _service;


        public LocationServiceAdapter(
            IMapper mapper,
            ILocationService service)
            : base(mapper, service)
        {
            _service = service ?? throw new NullReferenceException();
        }


        public async Task<IQueryResult<LocationEmployeeModel>>
            QueryEmployeesAsync(int locationId, IQueryOptions options) =>
            await _service.QueryEmployeesAsync(locationId, options);

        public async Task<IEnumerable<NamedQueryModel>>
            GetLocationsAvailableForTransferAsync(int sourceLocationId) =>
            await _service.GetLocationsAvailableForTransferAsync(
                sourceLocationId);

        public async Task<int?> CloneLocationAsync(
            int sourceLocationId, bool shouldTransferEmployeesFromSource) =>
            await _service.CloneLocationAsync(
                sourceLocationId, shouldTransferEmployeesFromSource);

        public async Task<bool> TryTransferAsync(
            int sourceLocationId,
            int destinationLocationId,
            bool shouldDeleteSourceAfterTransfer) =>
            await _service.TryTransferAsync(
                sourceLocationId,
                destinationLocationId,
                shouldDeleteSourceAfterTransfer);
    }
}
