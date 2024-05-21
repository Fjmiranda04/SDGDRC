using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class NotaPQRSFRepository : GenericRepository<NotaPQRSF>, INotaPQRSFRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public NotaPQRSFRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<NotaPQRSFListDTO>> GetAllNotasByAgente(int? idPQRSF)
        {
            return await (from notas in contex.NotasPQRSFs
                          join autor in contex.accglTer on notas.NroIdeAutor equals autor.Ternit
                          where notas.IdPQRSF == idPQRSF
                          orderby notas.Fecha ascending
                          select new NotaPQRSFListDTO
                          {
                              Id = notas.Id,
                              Fecha = notas.Fecha,
                              Tipo = notas.Tipo,
                              Nota = notas.Nota,
                              Autor = autor.Ternom
                          }).ToListAsync();
        }

        public async Task<IEnumerable<NotaPQRSFListDTO>> GetAllNotasByCliente(int? idPQRSF)
        {
            return await (from notas in contex.NotasPQRSFs
                          join autor in contex.accglTer on notas.NroIdeAutor equals autor.Ternit
                          where notas.Tipo == "Nota"
                          orderby notas.Fecha ascending
                          select new NotaPQRSFListDTO
                          {
                              Id = notas.Id,
                              Fecha = notas.Fecha,
                              Nota = notas.Nota,
                              Autor = autor.Ternom
                          }).ToListAsync();
        }
    }
}