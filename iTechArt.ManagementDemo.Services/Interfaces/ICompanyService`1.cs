using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.Services.Interfaces
{
    /* This services were extracted to simplify implementation
     * of service adapters (this is not smth I would typically do,
     * but felt reasonable for a project like this) */
    public interface ICompanyService<TCompanyDTO> : IService<TCompanyDTO>
    {
        Task<IQueryResult<CompanyQueryModel>> QueryAsync(
            IQueryOptions options);
        Task<IQueryResult<CompanyLocationModel>> QueryLocationsAsync(
            int companyId, IQueryOptions options);
        Task<IQueryResult<CompanyEmployeeModel>> QueryEmployeesAsync(
            int companyId, IQueryOptions options);
        Task<IEnumerable<NamedQueryModel>>
            GetCompaniesIndex();
    }
}
