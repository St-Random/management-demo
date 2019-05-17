using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.Services.Interfaces
{
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
