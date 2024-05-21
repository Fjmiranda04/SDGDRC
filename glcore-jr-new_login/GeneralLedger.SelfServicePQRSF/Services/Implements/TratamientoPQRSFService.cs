using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class TratamientoPQRSFService : GenericService<TratamientoPQRSF>, ITratamientoPQRSFService
    {
        private readonly ITratamientoPQRSFRepository tratamientoPQRSFRepository;

        public TratamientoPQRSFService(ITratamientoPQRSFRepository tratamientoPQRSFRepository) : base(tratamientoPQRSFRepository)
        {
            this.tratamientoPQRSFRepository = tratamientoPQRSFRepository;
        }

        public async Task<IEnumerable<TratamientoPQRSFListDTO>> GetAllTratamientoById(int? id)
        {
            return await tratamientoPQRSFRepository.GetAllTratamientoById(id);
        }

        public async Task<IEnumerable<TratamientoPQRSFListDTO>> GetAllTratamientoByAgente(string NroIdAge)
        {
            return await tratamientoPQRSFRepository.GetAllTratamientoByAgente(NroIdAge);
        }
    }
}