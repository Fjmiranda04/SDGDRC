using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class MenuRolRepository : GenericRepository<MenuRol>, IMenuRolRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public MenuRolRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task DeleteMenuRol(string codMnu, string idRol)
        {
            var menuRol = await (from menuR in contex.MenuRoles
                                 where menuR.CodMnu == codMnu && menuR.idRol == idRol
                                 select new MenuRol
                                 {
                                     Id = menuR.Id,
                                     CodMnu = menuR.CodMnu,
                                     idRol = menuR.idRol,
                                     delmrk = menuR.delmrk
                                 }
                                ).FirstOrDefaultAsync();

            contex.Set<MenuRol>().Remove(menuRol);
            await contex.SaveChangesAsync();
        }

        public async Task<MenuRol> InsertMenuRol(string codMnu, string idRol)
        {
            var menuRol = new MenuRol
            {
                CodMnu = codMnu,
                idRol = idRol,
                delmrk = "1"
            };

            await contex.Set<MenuRol>().AddAsync(menuRol);
            await contex.SaveChangesAsync();

            return menuRol;
        }
    }
}