using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class MenuRolService : GenericService<MenuRol>, IMenuRolService
    {
        private readonly IMenuRolRepository menuRolRepository;

        public MenuRolService(IMenuRolRepository menuRolRepository) : base(menuRolRepository)
        {
            this.menuRolRepository = menuRolRepository;
        }

        public async Task DeleteMenuRol(string codMnu, string idRol)
        {
            await menuRolRepository.DeleteMenuRol(codMnu, idRol);
        }

        public async Task<MenuRol> InsertMenuRol(string codMnu, string idRol)
        {
            return await menuRolRepository.InsertMenuRol(codMnu, idRol);
        }
    }
}