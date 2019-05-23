using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.Services.Interfaces
{
    public interface ILocationService<TLocationDTO> : IService<TLocationDTO>
    {
        Task<IQueryResult<LocationEmployeeModel>> QueryEmployeesAsync(
            int locationId, IQueryOptions options);
        Task<IEnumerable<NamedQueryModel>>
            GetLocationsIndex(int companyId);

        Task<int?> TryDeleteLocationAndGetCompanyIdAsync(int id);
        Task<int?> CloneLocationAsync(
            int sourceLocationId,
            bool shouldTransferEmployeesFromSource);
        Task<bool> TryTransferAsync(
            int sourceLocationId,
            int destinationLocationId,
            bool shouldDeleteSourceAfterTransfer);
    }
}
