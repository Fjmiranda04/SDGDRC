using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Profilers.Implements
{
    public class ProApiRepository : Repository<ProApiModel>, IProApiRepository
    {
        private readonly SelfServiceContext Context;
        private readonly IConfiguration configuration;
        public ProApiRepository(SelfServiceContext Context, IConfiguration configuration) : base(Context)
        {
            this.Context = Context;
            this.configuration = configuration;
        }

        public async Task<ProApiModelPedido> AddPedido(ApiModelPedidoDTO apiModelPedidoDTO)
        {
            ProApiModelPedido pedido = new ProApiModelPedido();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "SAVE_PEDIDO"},
                new SqlParameter { ParameterName = "@CodigoPedido", Value = apiModelPedidoDTO.CodigoPedido},
                new SqlParameter { ParameterName = "@NitCliente", Value = apiModelPedidoDTO.NitCliente},
                new SqlParameter { ParameterName = "@Observacion", Value = apiModelPedidoDTO.ObservacionPedido},
                new SqlParameter { ParameterName = "@FechaPedido", Value = apiModelPedidoDTO.FechaPedido},
                new SqlParameter { ParameterName = "@dtDetallePedido", Value = Functions.ConvertToDataTable(apiModelPedidoDTO.DetallePedido)},
            };  

            var connection = new SqlConnection(configuration.GetConnectionString("API_AYB"));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_APIAYB", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            pedido = Functions.ConvertToEntity<ProApiModelPedido>(query);

            return pedido;
        }

        public async Task<ProApiModelTrackPedido> AddTrackPedido(ApiModelTrackPedidoDTO apiModelTrackPedidoDTO)
        {
            ProApiModelTrackPedido trackPedido = new ProApiModelTrackPedido();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETBANCOS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(""));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTIONHUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            trackPedido = Functions.ConvertToEntity<ProApiModelTrackPedido>(query);

            return trackPedido;
        }

        public async Task<ProApiModelTrackRemision> AddTrackRemision(ApiModelTrackRemisionDTO apiModelTrackRemisionDTO)
        {
            ProApiModelTrackRemision trackRemision = new ProApiModelTrackRemision();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETBANCOS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(""));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTIONHUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            trackRemision = Functions.ConvertToEntity<ProApiModelTrackRemision>(query);

            return trackRemision;
        }

        public async Task<ProApiModelFactura> AddTrackRemision(ApiModelFacturaDTO apiModelFacturaDTO)
        {
            ProApiModelFactura factura = new ProApiModelFactura();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETBANCOS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(""));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTIONHUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            factura = Functions.ConvertToEntity<ProApiModelFactura>(query);

            return factura;
        }

        public async Task<IEnumerable<ProApiModelTrackPedido>> GetTrackingPedidos()
        {
            List<ProApiModelTrackPedido> proApiModelTrackPedido = new List<ProApiModelTrackPedido>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_T_PEDIDOS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString("API_AYB"));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_APIAYB", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proApiModelTrackPedido = Functions.ConvertToList<ProApiModelTrackPedido>(query);

            var lista = await GetRemisiones();

           

            if (lista.Count() > 0)
            {
                foreach (var item in proApiModelTrackPedido)
                {
                    List<ProApiModelDetalleRemision> listaDetalle = new List<ProApiModelDetalleRemision>();
                    foreach (var subitem in lista)
                    {
                        if (item.NumeroPedido == subitem.NumeroPedido)
                        {
                            listaDetalle.Add
                            (
                                new ProApiModelDetalleRemision 
                                { 
                                      NumeroRemision = subitem.NumeroRemision
                                     ,FechaRemision = subitem.FechaRemision
                                     ,CodigoArticulo = subitem.CodigoArticulo
                                     ,CantidadArticulo = subitem.CantidadArticulo
                                     ,MedidaArticulo = subitem.MedidaArticulo
                                }
                            );
                        }
                    }

                    item.Remisiones = listaDetalle;
                }
            }

            

            return proApiModelTrackPedido;
        }

        private async Task<IEnumerable<ProApiModelTrackingList>> GetRemisiones()
        {
            List<ProApiModelTrackingList> proApiModelTrackingLists = new List<ProApiModelTrackingList>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_T_REMISIONES"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString("API_AYB"));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_APIAYB", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proApiModelTrackingLists = Functions.ConvertToList<ProApiModelTrackingList>(query);

            return proApiModelTrackingLists;
        }

        private async Task<IEnumerable<ProApiModelDetalleRemision>> GetDetalleRemisiones()
        {
            List<ProApiModelDetalleRemision> proApiModelDetalleRemisions = new List<ProApiModelDetalleRemision>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_DET_REMISIONES"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString("API_AYB"));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_GESTIONHUMANA", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proApiModelDetalleRemisions = Functions.ConvertToList<ProApiModelDetalleRemision>(query);

            return proApiModelDetalleRemisions;
        }

        public async Task<IEnumerable<ProApiModelCliente>> GetClientes()
        {
            List<ProApiModelCliente> proApiModelCliente = new List<ProApiModelCliente>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_CLIENTES"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString("API_AYB"));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_APIAYB", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proApiModelCliente = Functions.ConvertToList<ProApiModelCliente>(query);

            return proApiModelCliente;
        }

        public Task<ProApiModelTrackPedido> SendTrackingPedido()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProApiModelFactura>> GetFacturas()
        {
            List<ProApiModelFactura> proApiModelFacturas = new List<ProApiModelFactura>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_FACTURAS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString("API_AYB"));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_APIAYB", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proApiModelFacturas = Functions.ConvertToList<ProApiModelFactura>(query);

            return proApiModelFacturas;
        }

        public async Task<IEnumerable<ProApiModelArticulo>> GetArticulos()
        {
            List<ProApiModelArticulo> proApiModelArticulos = new List<ProApiModelArticulo>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GET_ARTS"},
            };

            var connection = new SqlConnection(configuration.GetConnectionString("API_AYB"));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_APIAYB", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            proApiModelArticulos = Functions.ConvertToList<ProApiModelArticulo>(query);

            return proApiModelArticulos;
        }
    }
}
