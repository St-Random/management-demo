namespace iTechArt.ManagementDemo.DataAccess.Interfaces
{
    public interface ITransaction
    {
        void Commit();
        void Rollback();
    }
}
