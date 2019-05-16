using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.Services.Interfaces
{
    public interface IService<T>
    {
        Task<T> FindAsync(int id);
        Task<int> SaveAsync(T item);
        Task DeleteAsync(int id);
    }
}
