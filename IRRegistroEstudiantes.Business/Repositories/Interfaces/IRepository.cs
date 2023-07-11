
namespace IRRegistroEstudiantes.Business.Repositories.Interfaces
{
    public interface IRepository<T,TId>
    {
        Task<T> InsertAsync(T entity);
        Task<T> GetByIdAsync(TId id);
        IQueryable<T> GetAll();
        Task<bool> DeleteByIdlAsync(TId id);
        Task<bool> DeleteAllAsync();
        Task UpdateAsync(T entity);
    }
}
