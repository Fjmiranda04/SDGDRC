using GeneralLedger.SelfServiceCore.Data.Repositories;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private IGenericRepository<TEntity> genericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<TEntity> InsertChangeDbContext(TEntity entity, string ConnectionString)
        {
            return await genericRepository.InsertChangeDbContext(entity, ConnectionString);
        }

        public async Task Delete(int id)
        {
            await genericRepository.Delete(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await genericRepository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await genericRepository.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await genericRepository.Insert(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await genericRepository.Update(entity);
        }

        public async Task<IEnumerable<TEntity>> ExecuteStoredProcedure(SqlParameter[] parametros, string storedProcedure)
        {
            return await genericRepository.ExecuteStoredProcedure(parametros, storedProcedure);
        }
    }
}