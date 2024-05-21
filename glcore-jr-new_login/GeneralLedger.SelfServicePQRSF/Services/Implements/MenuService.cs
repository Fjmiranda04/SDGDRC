using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class MenuService : GenericService<Menu>, IMenuService
    {
        private readonly IMenuRepository menuRepository;

        public MenuService(IMenuRepository menuRepository) : base(menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public async Task<IEnumerable<MenuListDTO>> GetMenusByUser(string NroIdUsr)
        {
            return await menuRepository.GetMenusByUser(NroIdUsr);
        }

        public async Task<IEnumerable<MenuListDTO>> GetMenusByRol(string idRol)
        {
            return await menuRepository.GetMenusByRol(idRol);
        }

        public async Task<IEnumerable<MenuListDTO>> GetMenusByUser(string NroIdUsr, string idRol)
        {
            return await menuRepository.GetMenusByUser(NroIdUsr, idRol);
        }
    }
}