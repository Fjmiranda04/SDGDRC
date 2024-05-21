using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public MenuRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<MenuListDTO>> GetMenusByUser(string NroIdUsr)
        {
            return await (from m in contex.Menus
                          join mu in contex.MenuUsuarios on m.CodMnu equals mu.CodMnu
                          where mu.NroIdUsr == NroIdUsr
                          orderby m.NvlMnu ascending, m.Orden ascending
                          select new MenuListDTO
                          {
                              CodMnu = m.CodMnu,
                              NomMnu = m.NomMnu,
                              TpoMnu = m.TpoMnu,
                              DepMnu = m.DepMnu,
                              Controller = m.Controller,
                              Action = m.Action,
                              IcoMnu = m.IcoMnu
                          }).ToListAsync();
        }

        public async Task<IEnumerable<MenuListDTO>> GetMenusByRol(string idRol)
        {
            return await (from m in contex.Menus
                          join mr in contex.MenuRoles on m.CodMnu equals mr.CodMnu
                          where mr.idRol == idRol
                          select new MenuListDTO
                          {
                              CodMnu = m.CodMnu,
                              NomMnu = m.NomMnu,
                              TpoMnu = m.TpoMnu,
                              DepMnu = m.DepMnu,
                              Controller = m.Controller,
                              Action = m.Action,
                              IcoMnu = m.IcoMnu
                          }).ToListAsync();
        }

        public async Task<IEnumerable<MenuListDTO>> GetMenusByUser(string NroIdUsr, string idRol)
        {
            return await (from m in contex.Menus
                          join mu in contex.MenuUsuarios on m.CodMnu equals mu.CodMnu
                          where mu.NroIdUsr == NroIdUsr
                          //orderby m.NvlMnu ascending, m.Orden ascending
                          select new MenuListDTO
                          {
                              CodMnu = m.CodMnu,
                              NomMnu = m.NomMnu,
                              TpoMnu = m.TpoMnu,
                              DepMnu = m.DepMnu,
                              Controller = m.Controller,
                              Action = m.Action,
                              IcoMnu = m.IcoMnu,
                              Orden = m.Orden
                          })
                          .Union(from m in contex.Menus
                                 join mr in contex.MenuRoles on m.CodMnu equals mr.CodMnu
                                 where mr.idRol == idRol
                                 //orderby m.NvlMnu ascending, m.Orden ascending
                                 select new MenuListDTO
                                 {
                                     CodMnu = m.CodMnu,
                                     NomMnu = m.NomMnu,
                                     TpoMnu = m.TpoMnu,
                                     DepMnu = m.DepMnu,
                                     Controller = m.Controller,
                                     Action = m.Action,
                                     IcoMnu = m.IcoMnu,
                                     Orden = m.Orden
                                 }
                          ).ToListAsync();
        }
    }
}