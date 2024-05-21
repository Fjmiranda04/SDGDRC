using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface INotaPQRSFService : IGenericService<NotaPQRSF>
    {
        Task<IEnumerable<NotaPQRSFListDTO>> GetAllNotasByAgente(int? idPQRSF);

        Task<IEnumerable<NotaPQRSFListDTO>> GetAllNotasByCliente(int? idPQRSF);
    }
}