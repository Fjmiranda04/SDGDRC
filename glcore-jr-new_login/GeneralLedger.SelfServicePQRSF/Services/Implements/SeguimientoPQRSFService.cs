using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class SeguimientoPQRSFService : GenericService<SeguimientoPQRSF>, ISeguimientoPQRSFService
    {
        private readonly ISeguimientoPQRSFRepository seguimientoPQRSFRepository;

        public SeguimientoPQRSFService(ISeguimientoPQRSFRepository seguimientoPQRSFRepository) : base(seguimientoPQRSFRepository)
        {
            this.seguimientoPQRSFRepository = seguimientoPQRSFRepository;
        }

        public async Task<IEnumerable<SeguimientoPQRSFListDTO>> GetAllSeguimientoById(int? id)
        {
            return await seguimientoPQRSFRepository.GetAllSeguimientoById(id);
        }
    }
}