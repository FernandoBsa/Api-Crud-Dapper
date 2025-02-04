namespace Domain.Interface;

public interface IGenericRepository
{
    Task<IEnumerable<TipoObjeto>> QueryAsync<TipoObjeto>(string query);
    Task<IEnumerable<TipoObjeto>> QueryAsync<TipoObjeto>(string query, Dictionary<string, object> parameters);
    Task<int> ExecuteAsync(string query);
    Task<int> ExecuteAsync(string query, Dictionary<string, object> parametros);
    Task<TipoObjeto> GetById<TipoObjeto>(string query, object parametros = null);
}