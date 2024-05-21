using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class PerfilService : GenericService<Perfil>, IPerfilService
    {
        private readonly IPerfilRepository perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository) : base(perfilRepository)
        {
            this.perfilRepository = perfilRepository;
        }

        public async Task<PerfilListDTO> GetPerfilByUser(string CodPerfil)
        {
            return await perfilRepository.GetPerfilByUser(CodPerfil);
        }
    }
}