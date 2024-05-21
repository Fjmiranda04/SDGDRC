using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface ITratamientoPQRSFService : IGenericService<TratamientoPQRSF>
    {
        Task<IEnumerable<TratamientoPQRSFListDTO>> GetAllTratamientoById(int? id);

        Task<IEnumerable<TratamientoPQRSFListDTO>> GetAllTratamientoByAgente(string NroIdAge);
    }
}