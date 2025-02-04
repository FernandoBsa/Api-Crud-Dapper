using Domain.Entity;
using Domain.Interface;
using Domain.Request;
using Domain.Response;

namespace Data.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IGenericRepository _repository; 
 
    public UsuarioRepository(IGenericRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<Usuario>> GetAllAsync()
    {
        var sql = "SELECT * FROM usuarios";
        var result = await _repository.QueryAsync<Usuario>(sql);
        return result.ToList();
    }

    public async Task<Usuario> GetByIdAsync(Guid id)
    {
        var sql = "SELECT * FROM usuarios WHERE id = @id";

        var usuario = await _repository.GetById<Usuario>(sql, new { id = id });
        
        return usuario;
    }

    public async Task<Usuario> AddAsync(UsuarioRequest request)
    {
        var sql = @"INSERT INTO USUARIOS(ID, NOMECOMPLETO, EMAIL, CPF, SENHA, SITUATION, USERTYPE)
                VALUES (:id, :nomecompleto, :email, :cpf, :senha, :situation, :usertype) RETURNING *";

        Dictionary<string, object> parametros = new Dictionary<string, object>
        {
            {"id", Guid.NewGuid()},
            {"nomecompleto", request.NomeCompleto},
            {"email", request.Email},
            {"cpf", request.CPF},
            {"senha", request.Senha},
            {"situation", request.Situation},
            {"usertype", request.UserType}
        };

        var usuario = await _repository.GetById<Usuario>(sql, parametros);
        return usuario;
    } 
}