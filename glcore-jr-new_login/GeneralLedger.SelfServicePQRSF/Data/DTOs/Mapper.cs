using AutoMapper;
using GeneralLedger.SelfServiceCore.Data.Models;

namespace GeneralLedger.SelfServiceCore.Data.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //MAPPERS PQRSF
            CreateMap<PQRSFCreateDTO, PQRSF>();
            CreateMap<PQRSF, PQRSFCreateDTO>();

            CreateMap<PQRSFListDTO, PQRSFListDTO>();
            CreateMap<PQRSF, PQRSFListDTO>();

            CreateMap<PQRSFShowDTO, PQRSF>();
            CreateMap<PQRSF, PQRSFShowDTO>();

            CreateMap<PQRSFShowDTO, PQRSFCreateDTO>();
            CreateMap<PQRSFCreateDTO, PQRSFShowDTO>();

            CreateMap<PQRSFProfilerDTO, PQRSF>();
            CreateMap<PQRSF, PQRSFProfilerDTO>();

            //MAPPERS CLIENTES
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<Cliente, ClienteDTO>();

            //MAPPERS SITUACIONES
            CreateMap<SituacionDTO, Situacion>();
            CreateMap<Situacion, SituacionDTO>();

            //MAPPERS COntactos Clientes
            CreateMap<ContactoClienteDTO, ContactoCliente>();
            CreateMap<ContactoCliente, ContactoClienteDTO>();

            CreateMap<ContactoCliente, ContactoClienteCreateDTO>();
            CreateMap<ContactoClienteCreateDTO, ContactoCliente>();

            CreateMap<ArchivoCreateDTO, Archivo>();
            CreateMap<Archivo, ArchivoCreateDTO>();

            //MAPPERS AGENTES
            CreateMap<AgenteShowDTO, Agente>();
            CreateMap<Agente, AgenteShowDTO>();

            //MAPPERS EMPLEADOS
            CreateMap<EmpleadoShowDTO, Empleado>();
            CreateMap<Empleado, EmpleadoShowDTO>();

            //MAPPERS PROCESOS
            CreateMap<ProcesoShowDTO, Proceso>();
            CreateMap<Proceso, ProcesoShowDTO>();

            //MAPPERS TRATAMIENTO
            CreateMap<TratamientoPQRSFCreateDTO, TratamientoPQRSF>();
            CreateMap<TratamientoPQRSF, TratamientoPQRSFCreateDTO>();

            //MAPPERS ELEMENTO
            CreateMap<ElementoListDTO, Elemento>();
            CreateMap<Elemento, ElementoListDTO>();

            //MAPPERS SEGUIMIENTO PQRSF
            CreateMap<SeguimientoPQRSFCreateDTO, SeguimientoPQRSF>();
            CreateMap<SeguimientoPQRSF, SeguimientoPQRSFCreateDTO>();

            //MAPPERS RESPUESTA CIERRE PQRSF
            CreateMap<RespuestaCreateDTO, Respuesta>();
            CreateMap<Respuesta, RespuestaCreateDTO>();

            //MAPPERS TRAZABILIDAD PQRSF
            CreateMap<NotaPQRSFListDTO, NotaPQRSF>();
            CreateMap<NotaPQRSF, NotaPQRSFListDTO>();

            //MAPPER EMAILCONFIGURACION
            CreateMap<EmailConfiguracionDTO, EmailConfiguracion>();
            CreateMap<EmailConfiguracion, EmailConfiguracionDTO>();

            //MAPPER TERCERO
            CreateMap<TerceroCreateDTO, Tercero>();
            CreateMap<Tercero, TerceroCreateDTO>();

            //MAPPER SOLICITUDCLIENTE
            CreateMap<SolicitudClienteCreateDTO, SolicitudCliente>();
            CreateMap<SolicitudCliente, SolicitudClienteCreateDTO>();

            //MAPPER PEDIDO
            CreateMap<PedidoCreateDTO, Pedido>();
            CreateMap<Pedido, PedidoCreateDTO>();

            CreateMap<PedidoListDTO, Pedido>();
            CreateMap<Pedido, PedidoListDTO>();

            //MAPPER USUARIOEMPRESA
            CreateMap<UsuarioEmpresaCreateDTO, UsuarioEmpresa>();
            CreateMap<UsuarioEmpresa, UsuarioEmpresaCreateDTO>();

            //MAPPER ANALISIS VENCIMIENTO
            CreateMap<AnalisisVencimientoListDTO, AnalisisVencimiento>();
            CreateMap<AnalisisVencimiento, AnalisisVencimientoListDTO>();

            //MAPPER FICHATECNICA
            CreateMap<FichaTecnicaShowDTO, FichaTecnica>();
            CreateMap<FichaTecnica, FichaTecnicaShowDTO>();
        }
    }
}