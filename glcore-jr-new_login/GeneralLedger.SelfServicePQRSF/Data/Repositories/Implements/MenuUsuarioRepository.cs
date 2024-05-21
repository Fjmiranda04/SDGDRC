using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class MenuUsuarioRepository : GenericRepository<MenuUsuario>, IMenuUsuarioRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public MenuUsuarioRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task DeleteMenuUser(string codMnu, string nroId)
        {
            var menuUser = await (from menuU in contex.MenuUsuarios
                                  where menuU.CodMnu == codMnu && menuU.NroIdUsr == nroId
                                  select new MenuUsuario
                                  {
                                      Id = menuU.Id,
                                      CodMnu = menuU.CodMnu,
                                      NroIdUsr = menuU.NroIdUsr,
                                      delmrk = menuU.delmrk
                                  }
                                 ).FirstOrDefaultAsync();

            contex.Set<MenuUsuario>().Remove(menuUser);
            await contex.SaveChangesAsync();
        }

        public async Task<MenuUsuario> InsertMenuUsuario(string codMnu, string nroId)
        {
            var menus = await contex.MenuUsuarios.ToListAsync();
            var menuUser = new MenuUsuario
            {
                //Id = menus.Count() + 1,
                CodMnu = codMnu,
                NroIdUsr = nroId,
                delmrk = "1"
            };

            await contex.Set<MenuUsuario>().AddAsync(menuUser);
            await contex.SaveChangesAsync();

            return menuUser;
        }
    }
}