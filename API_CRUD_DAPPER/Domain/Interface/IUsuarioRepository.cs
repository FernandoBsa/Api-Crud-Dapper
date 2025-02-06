using Domain.Entity;
using Domain.Request;

namespace Domain.Interface;

public interface IUsuarioRepository
{
    Task<List<Usuario>> GetAllAsync();
    Task<Usuario> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(UsuarioRequest request);
    Task<int> UpdateAsync(UsuarioEditarRequest request);
    Task<int> DeleteAsync(Guid id);
}