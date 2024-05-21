using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.ServicesGL
{
    public interface IOrdenService
    {
        Task<IEnumerable<CanvasShowDTO>> GetCanvas(string usuario, string subcentro);

        Task<IEnumerable<CanvasShowDTO>> GetCanvas(string SubCentro);

        Task<IEnumerable<CanvasShowDTO>> GetOTFacturar();
    }
}