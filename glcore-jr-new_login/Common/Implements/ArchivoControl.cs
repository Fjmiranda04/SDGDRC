using GeneralLedger.SelfServiceCore.Data.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Common.Implements
{
    public class ArchivoControl : IArchivoControl
    {
        public async Task<ArchivoCreateDTO> SaveFilesPQRSF(int id, IFormFile archivo, string url)
        {
            ArchivoCreateDTO archivoCreateDTO = null;
            try
            {
                string pathF = (Directory.GetCurrentDirectory() + "/Temp/Trash/").Replace("\\", "/");
                string extensionArchivo = Path.GetExtension(archivo.FileName);
                var contentType = archivo.ContentType;
                var guid = Guid.NewGuid();
                string nombreArchivo = $"{id + DateTime.Now.ToString("yyyyMMddHHmmss") + guid}{extensionArchivo}";
                string archivoPath = Path.Combine(pathF, nombreArchivo);

                var filename = ContentDispositionHeaderValue.Parse(archivo.ContentDisposition)
                                            .FileName
                                            .TrimStart().ToString();

                filename = archivoPath;
                using (var fs = System.IO.File.Create(filename))
                {
                    await archivo.CopyToAsync(fs);
                    await fs.FlushAsync();
                    await fs.DisposeAsync();
                }

                archivoCreateDTO = new ArchivoCreateDTO
                {
                    CodPQRSF = id,
                    Nombre = nombreArchivo,
                    Ruta = archivoPath,
                    ContentType = contentType,
                    Url = url + nombreArchivo,
                    delmrk = "1"
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return archivoCreateDTO;
        }
    }
}