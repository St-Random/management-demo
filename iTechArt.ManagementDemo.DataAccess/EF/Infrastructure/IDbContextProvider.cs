using Microsoft.EntityFrameworkCore;

namespace iTechArt.ManagementDemo.DataAccess.EF.Infrastructure
{
    internal interface IDbContextProvider
    {
        DbContext GetDbContext();
    }
}
