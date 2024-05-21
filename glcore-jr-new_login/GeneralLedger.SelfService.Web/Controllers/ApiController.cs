using Common;
using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Controllers
{
    public class ApiController : Controller
    {
        private readonly IProfilerService profilerService;
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        private string authorizationHeader = "";

        public ApiController(IProfilerService profilerService) 
        {
            this.profilerService = profilerService;
        }
        
        [Route("api/Cliente/GetClientes")]
        [HttpGet]
        public async Task<ActionResult> GetClientes()
        {
            try
            {
                authorizationHeader = Request.Headers["Authorization"];

                if (!ValidateToken(authorizationHeader))
                {
                    return Unauthorized();
                }

                var result = await profilerService.GetInstancia().ProApi.GetClientes();

                return Ok(new ApiResponseDTO<object>
                {
                    Success = true,
                    Message = "Operación exitosa",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/Cliente/SendClientes")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> SendClientes([FromBody]ApiModelClienteDTO apiModelClienteDTO)
        {
            try
            {
                authorizationHeader = Request.Headers["Authorization"];

                if (!ValidateToken(authorizationHeader))
                {
                    return Unauthorized();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponseDTO<object>
                    {
                        Success = false,
                        Message = "Modelo de datos no válido",
                        Data = new
                        {
                            errores = ModelState.Values.SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage)
                                           .ToList()
                        }
                    });
                }

                string baseurl = "",method = "", json = "",type = "",autorizacion = "";

                baseurl  = Configuration["ApiAyb:BaseUrl"].ToString();
                method = Configuration["ApiAyb:SendCliente"].ToString();
                type = Configuration["ApiAyb:TypeSendCliente"].ToString();
                type = Configuration["ApiAyb:Authorization"].ToString();

                json = JsonConvert.SerializeObject(apiModelClienteDTO);

                var response = Funciones.Post(baseurl,method,json,type,autorizacion);

                return Ok(new ApiResponseDTO<object>
                {
                    Success = true,
                    Message = "Operación exitosa",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/Pedido/AddPedido")]
        [HttpPost]
        public async Task<ActionResult> AddPedido([FromBody]ApiModelPedidoDTO apiModelPedidoDTO)
        {
            try
            {
                authorizationHeader = Request.Headers["Authorization"];

                if (!ValidateToken(authorizationHeader))
                {
                    return Unauthorized();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponseDTO<object>
                    {
                        Success = false,
                        Message = "Modelo de datos no válido",
                        Data = new {errores = ModelState.Values.SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage)
                                           .ToList()
                        }
                    });
                }

                var items = await profilerService.GetInstancia().ProApi.GetArticulos();
                string itemsError = "";

                foreach(var item in apiModelPedidoDTO.DetallePedido)
                {
                    bool existe = items.Any(x => x.CodigoArticulo == item.CodigoArticulo && x.Tipo == item.TipoArticulo);

                    if (!existe)
                    {
                        itemsError = itemsError + $"El Ítem {item.CodigoArticulo} no existe \n";
                    }
                }

                if (!string.IsNullOrEmpty(itemsError))
                {
                    return BadRequest(new ApiResponseDTO<object>
                    {
                        Success = false,
                        Message = "No se pudo generar pedido.",
                        Data = itemsError
                    });
                }

                apiModelPedidoDTO.FechaPedido = apiModelPedidoDTO.FechaPedido.Split("/")[2] + apiModelPedidoDTO.FechaPedido.Split("/")[1] + apiModelPedidoDTO.FechaPedido.Split("/")[0];
                var result = await profilerService.GetInstancia().ProApi.AddPedido(apiModelPedidoDTO);

                if (string.IsNullOrEmpty(result.NumeroPedido))
                {
                    return BadRequest(new ApiResponseDTO<object>
                    {
                        Success = false,
                        Message = "No se pudo generar pedido, intente nuevamente",
                        Data = null
                    });
                }

                return Ok(new ApiResponseDTO<object>
                {
                    Success = true,
                    Message = "Operación exitosa",
                    Data = result
                });
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [Route("api/Pedido/GetTrackingPedidos")]
        [HttpGet]
        public async Task<ActionResult> GetTrackingPedidos()
        {
            try
            {
                authorizationHeader = Request.Headers["Authorization"];

                if (!ValidateToken(authorizationHeader))
                {
                    return Unauthorized();
                }

                var result = await profilerService.GetInstancia().ProApi.GetTrackingPedidos();

                if (result == null)
                {
                    return BadRequest(new ApiResponseDTO<object>
                    {
                        Success = false,
                        Message = "No se encontraron datos",
                        Data = null
                    });
                }

                return Ok(new ApiResponseDTO<object>
                {
                    Success = true,
                    Message = "Operación exitosa",
                    Data = result
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/Pedido/SendTrackingPedidos")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> SendTrackingPedidos(ApiModelTrackPedidoDTO apiModelTrackPedidoDTO)
        {
            try
            {
                authorizationHeader = Request.Headers["Authorization"];

                if (!ValidateToken(authorizationHeader))
                {
                    return Unauthorized();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponseDTO<object>
                    {
                        Success = false,
                        Message = "Modelo de datos no válido",
                        Data = new
                        {
                            errores = ModelState.Values.SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage)
                                           .ToList()
                        }
                    });
                }

                string baseurl = "", method = "", json = "", type = "", autorizacion = "";

                baseurl = Configuration["ApiAyb:BaseUrl"].ToString();
                method = Configuration["ApiAyb:SendRemision"].ToString();
                type = Configuration["ApiAyb:TypeSendRemision"].ToString();
                type = Configuration["ApiAyb:Authorization"].ToString();

                json = JsonConvert.SerializeObject(apiModelTrackPedidoDTO);

                var response = Funciones.Post(baseurl, method, json, type, autorizacion);

                return Ok(new ApiResponseDTO<object>
                {
                    Success = true,
                    Message = "Operación exitosa",
                    Data = response
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/Factura/GetFacturas")]
        [HttpGet]
        public async Task<ActionResult> GetFacturas()
        {
            try
            {
                authorizationHeader = Request.Headers["Authorization"];

                if (!ValidateToken(authorizationHeader))
                {
                    return Unauthorized();
                }

                var result = await profilerService.GetInstancia().ProApi.GetFacturas();

                return Ok(new ApiResponseDTO<object>
                {
                    Success = true,
                    Message = "Operación exitosa",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/Factura/SendFactura")]
        [HttpPost]
        public async Task<ActionResult> SendFactura(ApiModelFacturaDTO apiModelFacturaDTO)
        {
            try
            {
                authorizationHeader = Request.Headers["Authorization"];

                if (!ValidateToken(authorizationHeader))
                {
                    return Unauthorized();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponseDTO<object>
                    {
                        Success = false,
                        Message = "Modelo de datos no válido",
                        Data = new
                        {
                            errores = ModelState.Values.SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage)
                                           .ToList()
                        }
                    });
                }

                string baseurl = "", method = "", json = "", type = "", autorizacion = "";

                baseurl = Configuration["ApiAyb:BaseUrl"].ToString();
                method = Configuration["ApiAyb:SendFactura"].ToString();
                type = Configuration["ApiAyb:TypeSendFactura"].ToString();
                type = Configuration["ApiAyb:Authorization"].ToString();

                json = JsonConvert.SerializeObject(apiModelFacturaDTO);

                var response = Funciones.Post(baseurl, method, json, type, autorizacion);

                return Ok(new ApiResponseDTO<object>
                {
                    Success = true,
                    Message = "Operación exitosa",
                    Data = response
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        private bool ValidateToken(string jwtToken)
        {
            try
            {
                if (string.IsNullOrEmpty(jwtToken))
                {
                    return false; // Retorna 401 Unauthorized si el encabezado está ausente
                }

                // Dividir el encabezado de autorización para obtener el token Bearer
                string[] parts = jwtToken.Split(' ');
                if (parts.Length != 2 || !parts[0].Equals("Bearer"))
                {
                    return false; // Retorna 401 Unauthorized si el encabezado no tiene el formato correcto
                }

                // Obtener el token Bearer
                string token = parts[1];

                // Validar el token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Configuration["ApiAyb:llavejwt"].ToString());
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        
    }
}
