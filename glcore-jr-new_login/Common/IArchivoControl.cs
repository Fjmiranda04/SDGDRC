using GeneralLedger.SelfServiceCore.Data.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Common
{
    public interface IArchivoControl
    {
        Task<ArchivoCreateDTO> SaveFilesPQRSF(int id, IFormFile archivo, string url);
    }
}