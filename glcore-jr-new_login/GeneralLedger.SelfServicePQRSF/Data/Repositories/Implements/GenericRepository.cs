using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    // Esta clase tambien es generica y hereda de la Interfaz y la entidad viene de una clase
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public GenericRepository(SelfServiceContext contex, IConfiguration configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<TEntity> InsertChangeDbContext(TEntity entity, string ConnectionString)
        {
            contex.Database.CloseConnection();
            contex.Database.SetConnectionString(ConnectionString);
            contex.Database.OpenConnection();
            await contex.Set<TEntity>().AddAsync(entity);
            await contex.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception("La entidad es nula");
            }

            contex.Set<TEntity>().Remove(entity);
            await contex.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await contex.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await contex.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await contex.Set<TEntity>().AddAsync(entity);
            await contex.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            contex.Set<TEntity>().Update(entity);
            await contex.SaveChangesAsync();
            return entity;
        }

        //RETURN AN ENTITY USING PARAMETERS
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
            contex.Database.SetCommandTimeout(4000);
            return await contex.Set<TEntity>().FromSqlRaw(Command).SingleOrDefaultAsync();
        }

        //RETURN A LIST OF ENTITY USING PARAMETERS
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
            contex.Database.SetCommandTimeout(4000);
            return await contex.Set<TEntity>().FromSqlRaw(Command).ToListAsync();
        }

        //RETURN A LIST OF ENTITY WITHOUT USING PARAMETERS
        public async Task<IEnumerable<TEntity>> ExecuteStoredProcedure(string storedProcedure)
        {
            var Command = $"EXEC {storedProcedure}";
            return await contex.Set<TEntity>().FromSqlRaw(Command).ToListAsync();
        }

        //NOT RETURN ENTITY, RETURN PA EXECUTED SUCCESSFULL OR NOT
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
            return await contex.Database.ExecuteSqlRawAsync(Command);
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

        public async Task<IEnumerable<TEntity>> ExecuteCommandSql(List<SqlParameter> parms, string sql)
        {
            contex.Database.SetCommandTimeout(700);
            var querable = await contex.Set<TEntity>().FromSqlRaw<TEntity>(sql, parms.ToArray()).ToListAsync();

            return querable;
        }

        public Task<IEnumerable<object>> ExecuteCommandSql(List<SqlParameter> parms, string storedProcedure, object type)
        {
            throw new NotImplementedException();
        }

        public Task<object> ExecuteQueryDataTable(string pTextoComando, string pTabla, object Type, CommandType CommandType, SqlParameter[] QueryParameters, SqlConnection Conn)
        {
            throw new NotImplementedException();
        }
    }
}