using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.Repositories.Implements;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.RepositoriesGL.Implements
{
    public class OrdenRepository : GenericRepository<Orden>, IOrdenRepository
    {
        private readonly SelfServiceContext context;
        private readonly IConfiguration configuration;

        public OrdenRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.context = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<CanvasShowDTO>> GetCanvas(string usuario, string subcentro)
        {
            return await (
                            from orden in context.Ordenes
                            join cotizacion in context.AccglCotiza on orden.Ordnro equals cotizacion.CotOt into ord_cot
                            from cot in ord_cot.DefaultIfEmpty()
                            join pedido in context.AccPedidos on orden.Ordnro equals pedido.Otnumero into ord_ped
                            from ped in ord_ped.DefaultIfEmpty()
                            join cliente in context.Clientes on orden.Ordcli equals cliente.Clicod into ord_cli
                            from cli in ord_cli.DefaultIfEmpty()
                            where orden.Ordest != "2" && orden.Ordest != "3" && orden.OrdUser == ((usuario.Equals("all")) ? orden.OrdUser : usuario) && orden.OrdCco == ((subcentro.Equals("all")) ? orden.OrdCco : subcentro)
                            orderby cot.DateLastUpd descending, ped.DateLastUpd descending, orden.DateLastUpd descending
                            select new CanvasShowDTO
                            {
                                NroOrden = orden.Ordnro,
                                OrdenCliente = cli.Clinom,
                                OrdenLastUpdate = orden.DateLastUpd,
                                OrdenDias = (DateTime.Now - orden.DateLastUpd).Days,

                                Cotizacion = (cot.Cotnum == null) ? "" : cot.Cotnum,
                                CotizacionCliente = (cli.Clinom == null) ? "" : cli.Clinom,
                                CotizacionLastUpdate = (cot.DateLastUpd == null) ? Convert.ToDateTime("01/01/1900") : cot.DateLastUpd,
                                CotizacionDias = (DateTime.Now - ((cot.DateLastUpd == null) ? Convert.ToDateTime("01/01/1900") : cot.DateLastUpd)).Days,

                                Pedido = (ped.Nrofac == null) ? "" : ped.Nrofac,
                                PedidoCliente = (cli.Clinom == null) ? "" : cli.Clinom,
                                PedidoLastUpdate = (ped.DateLastUpd == null) ? Convert.ToDateTime("01/01/1900") : ped.DateLastUpd,
                                PedidoDias = (DateTime.Now - ((ped.DateLastUpd == null) ? Convert.ToDateTime("01/01/1900") : ped.DateLastUpd)).Days
                            }).ToListAsync();
        }

        public async Task<IEnumerable<CanvasShowDTO>> GetCanvas(string SubCentro)
        {
            return await (
                            from orden in context.Ordenes
                            join cotizacion in context.AccglCotiza on orden.Ordnro equals cotizacion.CotOt into ord_cot
                            from cot in ord_cot.DefaultIfEmpty()
                            join pedido in context.AccPedidos on orden.Ordnro equals pedido.Otnumero into ord_ped
                            from ped in ord_ped.DefaultIfEmpty()
                            join cliente in context.Clientes on orden.Ordcli equals cliente.Clicod into ord_cli
                            from cli in ord_cli.DefaultIfEmpty()
                            where orden.Ordest != "2" && orden.Ordest != "3" && orden.OrdCco == SubCentro
                            orderby cot.DateLastUpd descending, ped.DateLastUpd descending, orden.DateLastUpd descending
                            select new CanvasShowDTO
                            {
                                NroOrden = orden.Ordnro,
                                OrdenCliente = cli.Clinom,
                                OrdenLastUpdate = orden.DateLastUpd,

                                Cotizacion = (cot.Cotnum == null) ? "" : cot.Cotnum,
                                CotizacionCliente = (cli.Clinom == null) ? "" : cli.Clinom,
                                CotizacionLastUpdate = (cot.DateLastUpd == null) ? Convert.ToDateTime("01/01/1900") : cot.DateLastUpd,

                                Pedido = (ped.Nrofac == null) ? "" : ped.Nrofac,
                                PedidoCliente = (cli.Clinom == null) ? "" : cli.Clinom,
                                PedidoLastUpdate = (ped.DateLastUpd == null) ? Convert.ToDateTime("01/01/1900") : ped.DateLastUpd,
                            }).ToListAsync();
        }

        public async Task<IEnumerable<CanvasShowDTO>> GetOTFacturar()
        {
            return await (from orden in context.Ordenes
                          join cliente in context.Clientes on orden.Ordcli equals cliente.Clicod into ord_cli
                          from cli in ord_cli.DefaultIfEmpty()
                          where orden.Ordest == "3"
                          orderby orden.DateLastUpd descending
                          select new CanvasShowDTO
                          {
                              NroOrden = orden.Ordnro,
                              OrdenCliente = cli.Clinom,
                              OrdenLastUpdate = orden.DateLastUpd
                          }).ToListAsync();
        }
    }
}