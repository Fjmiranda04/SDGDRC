using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class NotaPQRSFService : GenericService<NotaPQRSF>, INotaPQRSFService
    {
        private readonly INotaPQRSFRepository notaPQRSFRepository;

        public NotaPQRSFService(INotaPQRSFRepository notaPQRSFRepository) : base(notaPQRSFRepository)
        {
            this.notaPQRSFRepository = notaPQRSFRepository;
        }

        public async Task<IEnumerable<NotaPQRSFListDTO>> GetAllNotasByAgente(int? idPQRSF)
        {
            return await notaPQRSFRepository.GetAllNotasByAgente(idPQRSF);
        }

        public async Task<IEnumerable<NotaPQRSFListDTO>> GetAllNotasByCliente(int? idPQRSF)
        {
            return await notaPQRSFRepository.GetAllNotasByCliente(idPQRSF);
        }
    }
}