
namespace IRRegistroEstudiantes.Business.Services.Interfaces
{
    public interface IService<T, TId>
    {
        Task<T> InsertAsync(T entity);
        Task<T> GetByIdAsync(TId id);
        Task<List<T>> GetAll();
        Task<bool> DeleteByIdlAsync(TId id);
        Task<bool> DeleteAllAsync();
        void UpdateAsync(T entity);
    }
}
