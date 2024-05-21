using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class TratamientoPQRSFRepository : GenericRepository<TratamientoPQRSF>, ITratamientoPQRSFRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public TratamientoPQRSFRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.contex = contex;
        }

        public async Task<IEnumerable<TratamientoPQRSFListDTO>> GetAllTratamientoById(int? id)
        {
            return await (from tratamiento in contex.TratamientoPQRSFs
                          join agente in contex.Agentes on tratamiento.NroIdResponsable equals agente.NroId
                          where tratamiento.IdPQRSF == id
                          select new TratamientoPQRSFListDTO
                          {
                              Id = tratamiento.Id,
                              Actividad = tratamiento.Actividad,
                              FechaCumplimiento = tratamiento.FechaCumplimiento,
                              NombreResponsable = agente.NombreCompleto
                          }).ToListAsync();
        }

        public async Task<IEnumerable<TratamientoPQRSFListDTO>> GetAllTratamientoByAgente(string NroIdAge)
        {
            return await (from tratamiento in contex.TratamientoPQRSFs
                          join agente in contex.Agentes on tratamiento.NroIdResponsable equals agente.NroId
                          where tratamiento.NroIdResponsable == NroIdAge
                          orderby tratamiento.Checked ascending, tratamiento.FechaCumplimiento ascending
                          select new TratamientoPQRSFListDTO
                          {
                              Id = tratamiento.Id,
                              Actividad = tratamiento.Actividad,
                              FechaCumplimiento = tratamiento.FechaCumplimiento,
                              Observaciones = tratamiento.Observaciones,
                              Checked = tratamiento.Checked,
                              FechaCheck = tratamiento.FechaCheck,
                              NombreResponsable = agente.NombreCompleto,
                          }).ToListAsync();
        }
    }
}