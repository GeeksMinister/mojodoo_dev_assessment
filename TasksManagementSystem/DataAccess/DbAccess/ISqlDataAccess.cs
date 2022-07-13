
namespace TasksManagementSystem.DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task SaveData<T>(string query, T parameters);
        Task<IEnumerable<T>> LoadData<T, U>(string query, U parameters);
    }
}