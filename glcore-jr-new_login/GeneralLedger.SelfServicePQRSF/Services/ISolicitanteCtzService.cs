using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services
{
    public interface ISolicitanteCtzService : IGenericService<CliOtrosContactos>
    {
        Task<IEnumerable<SolicitanteCtzListDTO>> GetSolicitantes(string filter, string nitCliente);

    }
}
