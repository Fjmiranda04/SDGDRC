using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class MenuUsuarioService : GenericService<MenuUsuario>, IMenuUsuarioService
    {
        private readonly IMenuUsuarioRepository menuUsuarioRepository;

        public MenuUsuarioService(IMenuUsuarioRepository menuUsuarioRepository) : base(menuUsuarioRepository)
        {
            this.menuUsuarioRepository = menuUsuarioRepository;
        }

        public async Task DeleteMenuUser(string codMnu, string nroId)
        {
            await menuUsuarioRepository.DeleteMenuUser(codMnu, nroId);
        }

        public async Task<MenuUsuario> InsertMenuUsuario(string codMnu, string nroId)
        {
            return await menuUsuarioRepository.InsertMenuUsuario(codMnu, nroId);
        }
    }
}