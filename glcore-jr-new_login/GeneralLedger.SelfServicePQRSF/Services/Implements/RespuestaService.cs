using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class RespuestaService : GenericService<Respuesta>, IRespuestaService
    {
        private readonly IRespuestaRepository respuestaRepository;

        public RespuestaService(IRespuestaRepository respuestaRepository) : base(respuestaRepository)
        {
            this.respuestaRepository = respuestaRepository;
        }
    }
}