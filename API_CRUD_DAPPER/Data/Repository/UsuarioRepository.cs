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
                VALUES (:id, :nomecompleto, :email, :cpf, :senha, :situation, :usertype)";

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
        
        await _repository.ExecuteAsync(sql, parametros);

        return await _repository.GetById<Usuario>("SELECT * FROM USUARIOS WHERE ID = :id", new { id = parametros["id"]});
    }

    public async Task<Usuario> UpdateAsync(UsuarioEditarRequest request)
    {
        var sql = @"UPDATE USUARIOS SET NOMECOMPLETO = :nomecompleto, EMAIL = :email, CPF = :cpf, SENHA = :senha, SITUATION = :situation, 
                    USERTYPE = :usertype WHERE ID = :id";

        Dictionary<string, object> parametros = new Dictionary<string, object>
        {
            {"id", request.Id},
            {"nomecompleto", request.NomeCompleto},
            {"email", request.Email},
            {"cpf", request.CPF},
            {"senha", request.Senha},
            {"situation", request.Situation},
            {"usertype", request.UserType}
        };

        await _repository.ExecuteAsync(sql, parametros);

        return await _repository.GetById<Usuario>("SELECT * FROM USUARIOS WHERE ID = :id",new { id = parametros["id"] });
    }

    public async Task<List<Usuario>> DeleteAsync(Guid id)
    {
        var sql = @"DELETE FROM usuarios WHERE ID = :id";
        Dictionary<string, object> parametros = new Dictionary<string, object>
        {
            { "id", id }
        };
        await _repository.ExecuteAsync(sql, parametros);
        
        var result = await _repository.QueryAsync<Usuario>("SELECT * FROM usuarios");
        
        return result.ToList();
    }
}