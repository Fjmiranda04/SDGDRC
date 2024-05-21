using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class PreguntaService : GenericService<Pregunta>, IPreguntaService
    {
        private readonly IPreguntaRepository preguntaRepository;

        public PreguntaService(IPreguntaRepository preguntaRepository) : base(preguntaRepository)
        {
            this.preguntaRepository = preguntaRepository;
        }
    }
}