using IRRegistroEstudiantes.Business.Repositories.Interfaces;
using IRRegistroEstudiantes.Model.Context;
using IRRegistroEstudiantes.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace IRRegistroEstudiantes.Business.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        IRRegistroEstudiantesContext _context;
        public UsuarioRepository(IRRegistroEstudiantesContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteAllAsync()
        {
            await _context.Usuarios.ExecuteDeleteAsync();
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdlAsync(int id)
        {
            Usuario Usuario = await GetByIdAsync(id);
            _context.Usuarios.Remove(Usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<Usuario> GetAll()
        {
            return _context.Usuarios.Select(e => e);
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.Where(e => e.Id == id)
                                        .Select(u => new Usuario
                                        {
                                            Id = u.Id,
                                            Username = u.Username,
                                            Role = u.Role,

                                        })
                                        .FirstOrDefaultAsync();
        }

        public IQueryable<Usuario> GetByUsername(string user)
        {
            return _context.Usuarios.Where(
                                            e => e.Username.StartsWith(user))
                                            .Select(u => new Usuario
                                            {
                                                Id = u.Id,
                                                Username = u.Username,
                                                Role = u.Role,
                                            });
        }

        public async Task<Usuario> GetByUsernameAndPassword(string user, string password)
        {
            return await _context.Usuarios.Where(
                                            e => e.Username.Equals(user) &&
                                            e.Password.Equals(password))
                                            .Select(u => new Usuario
                                            {
                                                Id = u.Id,
                                                Username = u.Username,
                                                Role = u.Role,
                                            })
                                            .FirstOrDefaultAsync();
        }

        public async Task<Usuario> InsertAsync(Usuario entity)
        {
            await _context.Usuarios.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Usuario entity)
        {
            _context.Usuarios.Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
