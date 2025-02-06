using AutoMapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Interface;
using Domain.Request;
using Domain.Response;
using Service.Interface;

namespace Service.Serivce;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<UsuarioListarDTO>> AddAsync(UsuarioRequest request)
    {
        try
        {
            ResponseModel<UsuarioListarDTO> response = new ResponseModel<UsuarioListarDTO>();
            var usuarioGuid = await _repository.AddAsync(request);

            if (usuarioGuid == Guid.Empty)
            {
                response.Mensagem = "Ocorreu um erro ao realizar o registro!";
                response.Status = false;
                return response;
            }
            
            var usuario = await _repository.GetByIdAsync(usuarioGuid);
            var usuarioDto = _mapper.Map<UsuarioListarDTO>(usuario);

            response.Dados = usuarioDto;
            response.Mensagem = "Usuario criado com sucesso";
            return response;
            
        }
        catch (Exception ex)
        { 
            throw new Exception(ex.Message);
        }
    }

    public async Task<ResponseModel<List<UsuarioListarDTO>>> GetAllAsync()
    {
        try
        {
            ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();

            var usuariosBanco = await _repository.GetAllAsync();
            if (usuariosBanco == null)
            {
                response.Mensagem = "Nenhum usuario encontrado";
                response.Status = false;
                return response;
            }

            var usuariosDTO = _mapper.Map<List<UsuarioListarDTO>>(usuariosBanco);

            response.Dados = usuariosDTO;
            response.Mensagem = "Usuarios localizados com sucesso";
            return response;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ResponseModel<UsuarioListarDTO>> GetByIdAsync(Guid id)
    {
        try
        {
            ResponseModel<UsuarioListarDTO> response = new ResponseModel<UsuarioListarDTO>();

            var usuariosBanco = await _repository.GetByIdAsync(id);
            if (usuariosBanco == null)
            {
                response.Mensagem = "Nenhum usuario encontrado";
                response.Status = false;
                return response;
            }
            
            var usuarioDTO = _mapper.Map<UsuarioListarDTO>(usuariosBanco);

            response.Dados = usuarioDTO;
            response.Mensagem = "Usuario localizado com sucesso";
            return response;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ResponseModel<UsuarioListarDTO>> UpdateAsync(UsuarioEditarRequest request)
    {
        try
        {
            ResponseModel<UsuarioListarDTO> response = new ResponseModel<UsuarioListarDTO>();

            var usuario = await _repository.UpdateAsync(request);
            if(usuario == 0)
            {
                response.Mensagem = "Ocorreu um erro ao realizar a edição!";
                response.Status = false;
                return response;
            }
            
            var novoUsuario = await _repository.GetByIdAsync(request.Id);
            var usuarioDTO = _mapper.Map<UsuarioListarDTO>(novoUsuario);

            response.Dados = usuarioDTO;
            response.Mensagem = "Usuarios editado com sucesso";
            return response;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ResponseModel<List<UsuarioListarDTO>>> DeleteAsync(Guid id)
    {
        try
        {
            ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>> ();

            var usuariosBanco = await _repository.DeleteAsync(id);
            if(usuariosBanco == 0)
            {
                response.Mensagem = "Ocorreu um erro ao realizar o delete!";
                response.Status = false;
                return response;
            }
            
            var usuarios = await _repository.GetAllAsync();
            var usuarioDTO = _mapper.Map<List<UsuarioListarDTO>>(usuarios);

            response.Dados = usuarioDTO;
            response.Mensagem = "Usuarios removido com sucesso";
            return response;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}