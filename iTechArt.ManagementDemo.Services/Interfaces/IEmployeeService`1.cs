using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.Services.Interfaces
{
    public interface IEmployeeService<TEmployeeDTO> : IService<TEmployeeDTO>
    {
        Task<IQueryResult<EmployeeQueryModel>> QueryAsync(
            IQueryOptions options);
    }
}
