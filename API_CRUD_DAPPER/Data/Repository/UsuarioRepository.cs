using Domain.Entity;
using Domain.Interface;
using Domain.Request;
using Domain.Response;
using Npgsql;

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
        try
        {
            var sql = "SELECT * FROM usuarios";
            var result = await _repository.QueryAsync<Usuario>(sql);
            return result.ToList();
        }
        catch (NpgsqlException ex)
        {
            throw new NpgsqlException(ex.Message);
        }
        
    }

    public async Task<Usuario> GetByIdAsync(Guid id)
    {
        try
        {
            var sql = "SELECT * FROM usuarios WHERE id = @id";

            var usuario = await _repository.GetById<Usuario>(sql, new { id = id });
        
            return usuario;
        }
        catch (NpgsqlException e)
        {
            throw new NpgsqlException(e.Message);
        }
    }

    public async Task<Guid> AddAsync(UsuarioRequest request)
    {
        try
        {
            var sql = @"INSERT INTO USUARIOS(ID, NOMECOMPLETO, EMAIL, CPF, SENHA, SITUATION, USERTYPE)
                          VALUES (:id, :nomecompleto, :email, :cpf, :senha, :situation, :usertype) RETURNING ID";
            
            var usuarioGuid = Guid.NewGuid(); 
            Dictionary<string, object> parametros = new Dictionary<string, object>
            {
                {"id", usuarioGuid},
                {"nomecompleto", request.NomeCompleto},
                {"email", request.Email},
                {"cpf", request.CPF},
                {"senha", request.Senha},
                {"situation", request.Situation},
                {"usertype", request.UserType}
            };
        
            var linhasAfetadas = await _repository.ExecuteAsync(sql, parametros);
       
            if (linhasAfetadas > 0)
            {
                return usuarioGuid;
            }
            else
            {
                return Guid.Empty; 
            }
        }
        catch (NpgsqlException ex)
        {
            throw new NpgsqlException(ex.Message);
        }
    }

    public async Task<int> UpdateAsync(UsuarioEditarRequest request)
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

        return await _repository.ExecuteAsync(sql, parametros);
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        try
        {
            var sql = @"DELETE FROM usuarios WHERE ID = :id";
            Dictionary<string, object> parametros = new Dictionary<string, object>
            {
                { "id", id }
            };
             return await _repository.ExecuteAsync(sql, parametros);
        }
        catch (NpgsqlException e)
        {
            throw new NpgsqlException(e.Message);
        }
    }
}