using Domain.DTO;
using Domain.Request;
using Domain.Response;

namespace Service.Interface;

public interface IUsuarioService
{
    Task<ResponseModel<List<UsuarioListarDTO>>> GetAllAsync();
    Task<ResponseModel<UsuarioListarDTO>> GetByIdAsync(Guid id);
    Task<ResponseModel<UsuarioListarDTO>> AddAsync(UsuarioRequest request);
}