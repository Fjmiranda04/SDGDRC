using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<TEntity> InsertChangeDbContext(TEntity entity, string ConnectionString);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<TEntity> Insert(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task Delete(int id);

        Task<IEnumerable<TEntity>> ExecuteStoredProcedure(SqlParameter[] parametros, string storedProcedure);
    }
}