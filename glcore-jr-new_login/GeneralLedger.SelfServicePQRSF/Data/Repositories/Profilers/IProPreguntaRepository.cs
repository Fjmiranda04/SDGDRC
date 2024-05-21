using GeneralLedger.SelfServiceCore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers
{
    public interface IProPreguntaRepository : IRepository<Pregunta>
    {
        Task<IEnumerable<Pregunta>> GetPreguntas(string search, string keyConnection);

        Task<Pregunta> SavePregunta(string pregunta, string keyConnection);

        Task<Pregunta> EditPregunta(string pregunta, int id, string keyConnection);

        Task<Pregunta> DeletePregunta(int id, string keyConnection);
    }
}