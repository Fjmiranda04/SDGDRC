using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories
{
    public interface IGestionHumanaRepository : IGenericRepository<GestionHumana>
    {
        Task<CertificadoLaboralSShowDTO> GetCertificadoLaboralS(string NumeroCedula,string keyConnection);

        Task<CertificadoLaboralSShowDTO> GetCertificadoLaboral(string NumeroCedula, string Periodo, string keyConnection);

        Task<ContratoLaboralShowDTO> GetContratoLaboral(string NumeroCedula, string keyConnection);

        Task<ExamenIngresoShowDTO> GetExamenIngreso(string NumeroCedula, string keyConnection);

        Task<List<BancosShowDTO>> GetBancos(string keyConnection);

        Task<CartaBancoShowDTO> GetCartaBancos(string NumeroCedula, string Banco, string keyConnection);

        Task<IEnumerable<ComprobantePagoEmpleado>> GetComprobantePago(string NumeroCedula, string FechaI, string FechaF, string keyConnection);

        Task<IEnumerable<HistorialLaboralEmpleado>> GetHistorialLaboral(string NumeroCedula, string keyConnection);

        
    }
}