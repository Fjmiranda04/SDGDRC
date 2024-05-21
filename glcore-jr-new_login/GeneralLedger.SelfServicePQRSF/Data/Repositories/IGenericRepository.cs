using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    // Paso una entidad donde esa entidad herede de una clase
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> InsertChangeDbContext(TEntity entity, string ConnectionString);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<TEntity> Insert(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task Delete(int id);

        Task<TEntity> ExecuteStoredProcedureEntity(SqlParameter[] parametros, string storedProcedure);

        Task<IEnumerable<TEntity>> ExecuteStoredProcedure(SqlParameter[] parametros, string storedProcedure);

        Task<IEnumerable<TEntity>> ExecuteStoredProcedure(string storedProcedure);

        Task<int> ExecuteStoredProcedureNonQuery(SqlParameter[] parametros, string storedProcedure);

        Task<DataTable> ExecuteQueryDataTable(string pTextoComando, string pTabla, CommandType Type, SqlParameter[] QueryParameters, SqlConnection Conn);

        Task<object> ExecuteQueryDataTable(string pTextoComando, string pTabla, object Type, CommandType CommandType, SqlParameter[] QueryParameters, SqlConnection Conn);

        Task<IEnumerable<TEntity>> ExecuteCommandSql(List<SqlParameter> parms, string storedProcedure);
    }
}