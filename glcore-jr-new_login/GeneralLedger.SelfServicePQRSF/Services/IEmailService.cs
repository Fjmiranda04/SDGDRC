using GeneralLedger.SelfServiceCore.Data.DTOs;
using System.Collections.Generic;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface IEmailService
    {
        bool SendEmail(PQRSFShowDTO pqrsf, List<AgenteShowDTO> agentes);
    }
}