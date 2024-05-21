using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SelfServiceContext Context;
        private DbSet<TEntity> _entities;

        public Repository(SelfServiceContext Context)
        {
            this.Context = Context;
            _entities = Context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Any(predicate);
        }

        public async Task<DataTable> ExecuteQueryDataTable(string pTextoComando, string pTabla, CommandType Type, SqlParameter[] QueryParameters, SqlConnection Conn)
        {
            SqlCommand QueryCommand = CreateCommand(pTextoComando, Type);
            QueryCommand.Connection = Conn;
            AddParameters(QueryParameters, QueryCommand);
            DataTable dtDatos = new DataTable();
            try
            {
                if (QueryCommand.Connection.State != ConnectionState.Open)
                    QueryCommand.Connection.Open();

                SqlDataAdapter daAdapter = new SqlDataAdapter(QueryCommand);
                await Task.Run(() => daAdapter.Fill(dtDatos));
                daAdapter = null;
                return dtDatos;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                QueryCommand.Connection.Close();
            }
        }

        private SqlCommand CreateCommand(string pTextoComando, CommandType Type)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = pTextoComando;
            Command.CommandType = Type;
            Command.CommandTimeout = 180;
            return Command;
        }

        private void AddParameters(SqlParameter[] QueryParameters, SqlCommand QueryCommand)
        {
            if (QueryParameters != null)
            {
                foreach (SqlParameter parameter in QueryParameters)
                {
                    QueryCommand.Parameters.Add(parameter.ParameterName, parameter.SqlDbType).Value = parameter.Value;
                }
            }
        }

        public async Task<TEntity> ExecuteStoredProcedureEntity(SqlParameter[] parametros, string storedProcedure)
        {
            var Command = $"EXEC {storedProcedure} ";
            bool first = true;

            foreach (var item in parametros)
            {
                if (first)
                {
                    if (item.Value.GetType() == typeof(string))
                    {
                        Command += $"{item.ParameterName}='{item.Value}'";
                    }
                    else
                    {
                        Command += $"{item.ParameterName}={item.Value}";
                    }
                    first = false;
                }
                else
                {
                    if (item.Value.GetType() == typeof(string))
                    {
                        Command += $",{item.ParameterName}='{item.Value}'";
                    }
                    else
                    {
                        Command += $",{item.ParameterName}={item.Value}";
                    }
                }
            }
            Context.Database.SetCommandTimeout(4000);
            return await Context.Set<TEntity>().FromSqlRaw(Command).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> ExecuteStoredProcedure(SqlParameter[] parametros, string storedProcedure)
        {
            var Command = $"EXEC {storedProcedure} ";
            bool first = true;

            foreach (var item in parametros)
            {
                if (first)
                {
                    if (item.Value.GetType() == typeof(string))
                    {
                        Command += $"{item.ParameterName}='{item.Value}'";
                    }
                    else
                    {
                        Command += $"{item.ParameterName}={item.Value}";
                    }
                    first = false;
                }
                else
                {
                    if (item.Value.GetType() == typeof(string))
                    {
                        Command += $",{item.ParameterName}='{item.Value}'";
                    }
                    else
                    {
                        Command += $",{item.ParameterName}={item.Value}";
                    }
                }
            }
            Context.Database.SetCommandTimeout(4000);
            return await Context.Set<TEntity>().FromSqlRaw(Command).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ExecuteStoredProcedure(string storedProcedure)
        {
            var Command = $"EXEC {storedProcedure}";
            return await Context.Set<TEntity>().FromSqlRaw(Command).ToListAsync();
        }

        public async Task<int> ExecuteStoredProcedureNonQuery(SqlParameter[] parametros, string storedProcedure)
        {
            var Command = $"EXEC {storedProcedure} ";
            bool first = true;

            foreach (var item in parametros)
            {
                if (first)
                {
                    if (item.SqlDbType == System.Data.SqlDbType.VarChar || item.SqlDbType == System.Data.SqlDbType.Date)
                    {
                        Command += $"{item.ParameterName}='{item.Value}'";
                    }
                    else
                    {
                        Command += $"{item.ParameterName}={item.Value}";
                    }
                    first = false;
                }
                else
                {
                    if (item.SqlDbType == System.Data.SqlDbType.VarChar || item.SqlDbType == System.Data.SqlDbType.Date)
                    {
                        Command += $",{item.ParameterName}='{item.Value}'";
                    }
                    else
                    {
                        Command += $",{item.ParameterName}={item.Value}";
                    }
                }
            }
            return await Context.Database.ExecuteSqlRawAsync(Command);
        }

        public Task<IEnumerable<TEntity>> ExecuteCommandSql(List<SqlParameter> parms, string storedProcedure)
        {
            throw new NotImplementedException();
        }
    }
}