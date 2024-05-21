using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class SeguimientoPQRSFRepository : GenericRepository<SeguimientoPQRSF>, ISeguimientoPQRSFRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public SeguimientoPQRSFRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<SeguimientoPQRSFListDTO>> GetAllSeguimientoById(int? id)
        {
            return await (from seguimiento in contex.SeguimientoPQRSFs
                          where seguimiento.IdPQRSF == id
                          select new SeguimientoPQRSFListDTO
                          {
                              Id = seguimiento.Id,
                              IdPQRSF = seguimiento.IdPQRSF,
                              Observaciones = seguimiento.Observaciones,
                              Fecha = seguimiento.Fecha,
                          }).ToListAsync();
        }
    }
}