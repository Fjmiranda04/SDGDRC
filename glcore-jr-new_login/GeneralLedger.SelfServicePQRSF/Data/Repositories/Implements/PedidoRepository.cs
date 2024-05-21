using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class PedidoRepository : GenericRepository<AccPedido>, IPedidoRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public PedidoRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<Consecutivo> GetConsecutivo()
        {
            string Command = "DECLARE @Consecutivo VARCHAR(10) = DBO.GETCONSECUTIVO('44',2) SELECT dbo.getConsecutivo_con_Fuente(@Consecutivo) AS consecutivo";
            var result = await contex.Set<Consecutivo>().FromSqlRaw(Command).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<PedidoCreateDTO> PreparePedidoToCreate(string NroId)
        {
            //var infoCliente = await(from cliente in contex.Clientes
            //                        where cliente.Clinit == NroId
            //                        select cliente).FirstOrDefaultAsync();

            //var sucursales = await (from sucursal in contex.Sucursales
            //                        where sucursal.Codcli == NroId
            //                        select new SucursalShowDTO
            //                        {
            //                            Id = sucursal.IdSucursal,
            //                            Direccion = sucursal.Direccion,
            //                            Contacto = sucursal.Contacto,
            //                            CodigoCiudad = sucursal.Ciudad,
            //                            CodigoCliente = sucursal.Codcli,
            //                            CodigoPais = sucursal.Pais,
            //                            Email = sucursal.Email,
            //                            Telefono = sucursal.Telefono
            //                        }).ToListAsync();

            var newDataPedido = new PedidoCreateDTO
            {
                //codCliente = infoCliente.Clicod,
                //codEscala = infoCliente.Cliesc,
                //Sucursales = sucursales,
                //TipoCliente = infoCliente.CliTipoCli
            };
            return newDataPedido;
        }

        public async Task<PedidoCreateDTO> SavePedido(PedidoCreateDTO pedido)
        {
            PedidoCreateDTO result = new PedidoCreateDTO();
            DataTable dtDetalles = new DataTable();

            dtDetalles = Functions.ConvertToDataTable<DetallePedido>(pedido.detalles);

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVEPEDIDO"},
                new SqlParameter { ParameterName = "@Fecha", Value = pedido.Fecha},
                new SqlParameter { ParameterName = "@FechaRequerido", Value = pedido.FechaRequerido},
                new SqlParameter { ParameterName = "@NitCliente", Value = pedido.NitCliente},
                new SqlParameter { ParameterName = "@CodigoCliente", Value = pedido.CodigoCliente},
                new SqlParameter { ParameterName = "@CodigoEscala", Value = pedido.CodigoEscala},
                new SqlParameter { ParameterName = "@CodigoVendedor", Value = pedido.CodigoVendedor},
                new SqlParameter { ParameterName = "@TipoCliente", Value = pedido.TipoCliente},
                new SqlParameter { ParameterName = "@Direccion", Value = pedido.Direccion},
                new SqlParameter { ParameterName = "@CodigoPostal", Value = pedido.CodigoPostal},
                new SqlParameter { ParameterName = "@CodigoCiudad", Value = pedido.CodigoCiudad},
                new SqlParameter { ParameterName = "@CodigoPais", Value = pedido.CodigoPais},
                new SqlParameter { ParameterName = "@CodigoSucursal", Value = pedido.CodigoSucursal},
                new SqlParameter { ParameterName = "@Detalle", Value = pedido.Detalle},
                new SqlParameter { ParameterName = "@SubTotal", Value = pedido.SubTotal},
                new SqlParameter { ParameterName = "@ValorIva", Value = pedido.ValorIva},
                new SqlParameter { ParameterName = "@Total", Value = pedido.Total},
                new SqlParameter { ParameterName = "@IvaIncluido", Value = pedido.IvaIncluido},
                new SqlParameter { ParameterName = "@TServicios", Value = dtDetalles},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PEDIDOS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            result = Functions.ConvertToEntity<PedidoCreateDTO>(query);

            return result;
        }

        public async Task<IEnumerable<PedidoListDTO>> GetPedidosByCliente(string NroId)
        {
            return await (from pedido in contex.AccPedidos
                          join cliente in contex.Clientes on pedido.Codcli equals cliente.Clicod into pedcli
                          from cli in pedcli.DefaultIfEmpty()
                          join ciudad in contex.Prociudades on cli.CliCodCiud equals ciudad.Ciucod into ciucli
                          from ciu in ciucli.DefaultIfEmpty()
                          where cli.Clinit == NroId
                          select new PedidoListDTO
                          {
                              NumeroPedido = pedido.Nrofac,
                              Fecha = pedido.Fecfac,
                              FechaRequerido = pedido.FechaReq,
                              Cliente = cli.Clinom,
                              SubTotal = pedido.Subtotal,
                              ValorIva = pedido.Iva,
                              Total = pedido.Vlrfac,
                              Ciudad = ciu.Ciunom,
                              Calificacion = pedido.Calificacion,
                              Direccion = pedido.Calificacion,
                              Estado = (pedido.Estado == 0) ? "GENERADO" : (pedido.Estado == 1) ? "AUTORIZADO" : (pedido.Estado == 2) ? "NO AUTORIZADO" : (pedido.Estado == 3) ? "FACTURADO" : "REMISIONADO"
                          }).ToListAsync();
        }
        public async Task<IEnumerable<PedidoListDTO>> GetPedidos(string fechaI, string fechaF, string NroIdCliente)
        {
            List<PedidoListDTO> pedidos = new List<PedidoListDTO>();

            List<SqlParameter> parms = new List<SqlParameter>
    {
        new SqlParameter { ParameterName = "@Operacion", Value = "GETPED"},
        new SqlParameter { ParameterName = "@FechaI", Value = fechaI},
        new SqlParameter { ParameterName = "@FechaF", Value = fechaF},
        new SqlParameter { ParameterName = "@NroIdCliente", Value = NroIdCliente}
    };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PEDIDOS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            pedidos = Functions.ConvertToList<PedidoListDTO>(query);


            foreach (var pedido in pedidos)
            {
                // Obtener los detalles como IEnumerable y convertirlos a List
                pedido.Detalles = (await GetDetallesPedido(pedido.NumeroPedido)).ToList();
            }


            return pedidos;
        }


        public async Task<IEnumerable<DetallePedidoDTO>> GetDetallesPedido(string numeroPedido)
        {
            List<DetallePedidoDTO> detalles = new List<DetallePedidoDTO>();

            List<SqlParameter> parms = new List<SqlParameter>
    {
        new SqlParameter { ParameterName = "@Operacion", Value = "GETDET"},
        new SqlParameter { ParameterName = "@NroFac", Value = numeroPedido}
    };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PEDIDOS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            detalles = Functions.ConvertToList<DetallePedidoDTO>(query);

            return detalles;
        }



        public async Task<PedidoCreateDTO> GetNewPedido(string nitCliente, string keyConnection)
        {
            PedidoCreateDTO pedido = new PedidoCreateDTO();
            List<SucursalShowDTO> sucursal = new List<SucursalShowDTO>();
            List<CliOtrosContactos> solictantes = new List<CliOtrosContactos>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETINFOCLIENTE"},
                new SqlParameter { ParameterName = "@NroIdCliente", Value = nitCliente}
            };

            var connection = new SqlConnection(configuration.GetConnectionString(keyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PEDIDOS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            pedido = Functions.ConvertToEntity<PedidoCreateDTO>(query);

            List<SqlParameter> parms2 = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETSUCBYCLIENTE"},
                new SqlParameter { ParameterName = "@NroIdCliente", Value = pedido.CodigoCliente}
            };

            var query2 = await ExecuteQueryDataTable("WEBGLSS_SP_PEDIDOS", "datos", CommandType.StoredProcedure, parms2.ToArray(), connection);

            pedido.Sucursales = Functions.ConvertToList<SucursalShowDTO>(query2);

            List<SqlParameter> parms3 = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETSOLIBYCLIENTE"},
                new SqlParameter { ParameterName = "@NroIdCliente", Value = pedido.CodigoCliente}
            };

            var query3 = await ExecuteQueryDataTable("WEBGLSS_SP_PEDIDOS", "datos", CommandType.StoredProcedure, parms3.ToArray(), connection);

            pedido.Solicitantes = Functions.ConvertToList<CliOtrosContactos>(query3);

            return pedido;
        }

        public async Task<IEnumerable<ArticuloShowDTO>> GetArticulos(string codigoEscala)
        {
            List<ArticuloShowDTO> articulos = new List<ArticuloShowDTO>();

            codigoEscala = (string.IsNullOrEmpty(codigoEscala) || codigoEscala == "0001") ? "ArVenta" : (codigoEscala == "0002") ? "ArDisco" : (codigoEscala == "0003") ? "ArEven" : "ArPrecio";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETARTICULOS"},
                new SqlParameter { ParameterName = "@Escala",   Value = (string.IsNullOrEmpty(codigoEscala)? "":codigoEscala)},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PEDIDOS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            articulos = Functions.ConvertToList<ArticuloShowDTO>(query);

            return articulos;
        }

        public async Task<IEnumerable<ServicioShowDTO>> GetServicios(string codigoEscala)
        {
            List<ServicioShowDTO> servicios = new List<ServicioShowDTO>();
            codigoEscala = (string.IsNullOrEmpty(codigoEscala) || codigoEscala == "0001") ? "ArVenta" : (codigoEscala == "0002") ? "ArDisco" : (codigoEscala == "0003") ? "ArEven" : "ArPrecio";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETSERVICIOS"},
                new SqlParameter { ParameterName = "@Escala",   Value = (string.IsNullOrEmpty(codigoEscala)? "":codigoEscala)},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(ConnectionTools.GetKeyConnectionString()));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PEDIDOS", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            servicios = Functions.ConvertToList<ServicioShowDTO>(query);

            return servicios;
        }

       
    }
}