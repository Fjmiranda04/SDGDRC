using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class GestionHumanaService : GenericService<GestionHumana>, IGestionHumanaService
    {
        private readonly IGestionHumanaRepository gestionHumanaRepository;

        public GestionHumanaService(IGestionHumanaRepository gestionHumanaRepository) : base(gestionHumanaRepository)
        {
            this.gestionHumanaRepository = gestionHumanaRepository;
        }

        public async Task<List<BancosShowDTO>> GetBancos(string keyConnection)
        {
            return await gestionHumanaRepository.GetBancos(keyConnection);
        }

        public async Task<CartaBancoShowDTO> GetCartaBancos(string NumeroCedula, string Banco, string keyConnection)
        {
            return await gestionHumanaRepository.GetCartaBancos(NumeroCedula, Banco,keyConnection);
        }

        public async Task<CertificadoLaboralSShowDTO> GetCertificadoLaboral(string NumeroCedula, string Periodo, string keyConnection)
        {
            return await gestionHumanaRepository.GetCertificadoLaboral(NumeroCedula, Periodo,keyConnection);
        }

        public async Task<CertificadoLaboralSShowDTO> GetCertificadoLaboralS(string NumeroCedula, string keyConnection)
        {
            return await gestionHumanaRepository.GetCertificadoLaboralS(NumeroCedula, keyConnection);
        }

        public async Task<IEnumerable<ComprobantePagoEmpleado>> GetComprobantePago(string NumeroCedula, string FechaI, string FechaF, string keyConnection)
        {
            return await gestionHumanaRepository.GetComprobantePago(NumeroCedula, FechaI, FechaF, keyConnection);
        }

        public async Task<ContratoLaboralShowDTO> GetContratoLaboral(string NumeroCedula, string keyConnection)
        {
            return await gestionHumanaRepository.GetContratoLaboral(NumeroCedula, keyConnection);
        }

        public async Task<ExamenIngresoShowDTO> GetExamenIngreso(string NumeroCedula, string keyConnection)
        {
            return await gestionHumanaRepository.GetExamenIngreso(NumeroCedula, keyConnection);
        }

        public async Task<IEnumerable<HistorialLaboralEmpleado>> GetHistorialLaboral(string NumeroCedula, string keyConnection)
        {
            return await gestionHumanaRepository.GetHistorialLaboral(NumeroCedula, keyConnection);
        }
    }
}