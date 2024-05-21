using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class ArchivoRepository : GenericRepository<Archivo>, IArchivoRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public ArchivoRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<Archivo>> GetArchivosByIdPQRSF(int idPQRSF)
        {
            return await (from ar in contex.Archivos
                          where ar.CodPQRSF == idPQRSF
                          select new Archivo
                          {
                              Id = ar.Id,
                              CodPQRSF = ar.CodPQRSF,
                              Nombre = ar.Nombre,
                              ContentType = ar.ContentType,
                              Ruta = ar.Ruta,
                              Url = ar.Url
                          }).ToListAsync();
        }
    }
}