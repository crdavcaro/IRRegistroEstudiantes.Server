using IRRegistroEstudiantes.Model.Entities;

namespace IRRegistroEstudiantes.Business.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario, int>
    {
        public Task<Usuario> GetByUsernameAndPassword(string user, string password);
        public IQueryable<Usuario> GetByUsername(string user);
    }
}
