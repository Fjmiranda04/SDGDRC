using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL
{
    public interface IOrdenRepository : IGenericRepository<Orden>
    {
        Task<IEnumerable<CanvasShowDTO>> GetCanvas(string usuario, string subcentro);

        Task<IEnumerable<CanvasShowDTO>> GetCanvas(string SubCentro);

        Task<IEnumerable<CanvasShowDTO>> GetOTFacturar();
    }
}