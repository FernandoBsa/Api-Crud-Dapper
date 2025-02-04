using Domain.Entity;
using Domain.Request;

namespace Domain.Interface;

public interface IUsuarioRepository
{
    Task<List<Usuario>> GetAllAsync();
    Task<Usuario> GetByIdAsync(Guid id);
    Task<Usuario> AddAsync(UsuarioRequest request);
}