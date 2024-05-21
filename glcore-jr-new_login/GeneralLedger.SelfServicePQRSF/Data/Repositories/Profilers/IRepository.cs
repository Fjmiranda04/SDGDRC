using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void RemoveRange(IEnumerable<TEntity> entities);

        bool Any(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> ExecuteStoredProcedureEntity(SqlParameter[] parametros, string storedProcedure);

        Task<IEnumerable<TEntity>> ExecuteStoredProcedure(SqlParameter[] parametros, string storedProcedure);

        Task<IEnumerable<TEntity>> ExecuteStoredProcedure(string storedProcedure);

        Task<int> ExecuteStoredProcedureNonQuery(SqlParameter[] parametros, string storedProcedure);

        Task<DataTable> ExecuteQueryDataTable(string pTextoComando, string pTabla, CommandType Type, SqlParameter[] QueryParameters, SqlConnection Conn);

        Task<IEnumerable<TEntity>> ExecuteCommandSql(List<SqlParameter> parms, string storedProcedure);
    }
}