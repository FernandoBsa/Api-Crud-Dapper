using System.Data;
using Dapper;
using Domain.Interface;
using Domain.Request;

namespace Data.Repository;

public class GenericRepository : IGenericRepository
{
    private readonly IDbConnection _connection;

    public GenericRepository(IDbConnection connection)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
    }

    public async Task<IEnumerable<TipoObjeto>> QueryAsync<TipoObjeto>(string query)
    {
        return await _connection.QueryAsync<TipoObjeto>(query);
    }
    public async Task<IEnumerable<TipoObjeto>> QueryAsync<TipoObjeto>(string query, Dictionary<string, object> parametros)
    {
        return await _connection.QueryAsync<TipoObjeto>(query, parametros);
    }
    public async Task<int> ExecuteAsync(string query)
    {
        return await _connection.ExecuteAsync(query);
    }
    public async Task<int> ExecuteAsync(string query, Dictionary<string, object> parametros)
    {
        return await _connection.ExecuteAsync(query, parametros);
    }
    public async Task<TipoObjeto> GetById<TipoObjeto>(string query, object parametros = null)
    {
        return await _connection.QuerySingleOrDefaultAsync<TipoObjeto>(query, parametros);
    }
    
    
}