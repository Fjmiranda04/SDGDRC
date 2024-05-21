using Dapper;
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
    public class PQRSFRepository : GenericRepository<PQRSF>, IPQRSFRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public PQRSFRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<PQRSFListDTO>> GetAllPQRSFByCliente(string nroId, string nitEmpresa)
        {
            return await (from pqrsf in contex.MatrizPQRSF
                          join estado in contex.PQRSFEstados on pqrsf.IdEstado equals estado.Id into pqrsfEstado
                          from est in pqrsfEstado.DefaultIfEmpty()
                          join agente in contex.Agentes on pqrsf.NroIdResponsable equals agente.NroId into pqrsfAgente
                          from age in pqrsfAgente.DefaultIfEmpty()
                          join prioridad in contex.PQRSFPrioridades on pqrsf.IdPrioridad equals prioridad.Id into pqrsfPrioridad
                          from prio in pqrsfPrioridad.DefaultIfEmpty()
                          join contacto in contex.ContactosCliente on pqrsf.IdContacto equals contacto.Id into pqrsfContacto
                          from cont in pqrsfContacto.DefaultIfEmpty()
                          join cliente in contex.accglTer on pqrsf.NroIdeCli equals cliente.Ternit into pqrsfCliente
                          from clie in pqrsfCliente.DefaultIfEmpty()
                          join situacion in contex.SituacionesNoConformes on pqrsf.IdSituacion equals situacion.Id into pqrsfSituacion
                          from situ in pqrsfSituacion.DefaultIfEmpty()
                          where pqrsf.NroIdeCli == nroId & pqrsf.NitEmpresa == nitEmpresa
                          orderby pqrsf.Fecha descending
                          select new PQRSFListDTO
                          {
                              Id = pqrsf.Id,
                              Fecha = pqrsf.Fecha,
                              Tipo = pqrsf.Tipo,
                              Asunto = pqrsf.Asunto,
                              Descripcion = pqrsf.Descripcion,
                              IdEstado = pqrsf.IdEstado,
                              Estado = est.Nombre,
                              NombreAgente = age.NombreCompleto,
                              Prioridad = prio.Nombre,
                              TipoSituacion = situ.TipoSituacion,
                              NombreCliente = clie.Ternom,
                              NombreContacto = cont.NombreContacto,
                          }).ToListAsync();
        }

        public async Task<IEnumerable<PQRSFListDTO>> GetAllPQRSF()
        {
            return await (from pqrsf in contex.MatrizPQRSF
                          join estado in contex.PQRSFEstados on pqrsf.IdEstado equals estado.Id into pqrsfEstado
                          from est in pqrsfEstado.DefaultIfEmpty()
                          join agente in contex.Agentes on pqrsf.NroIdResponsable equals agente.NroId into pqrsfAgente
                          from age in pqrsfAgente.DefaultIfEmpty()
                          join prioridad in contex.PQRSFPrioridades on pqrsf.IdPrioridad equals prioridad.Id into pqrsfPrioridad
                          from prio in pqrsfPrioridad.DefaultIfEmpty()
                          join contacto in contex.ContactosCliente on pqrsf.IdContacto equals contacto.Id into pqrsfContacto
                          from cont in pqrsfContacto.DefaultIfEmpty()
                          join cliente in contex.accglTer on pqrsf.NroIdeCli equals cliente.Ternit into pqrsfCliente
                          from cli in pqrsfCliente.DefaultIfEmpty()
                          join situacion in contex.SituacionesNoConformes on pqrsf.IdSituacion equals situacion.Id into pqrsfSituacion
                          from situ in pqrsfSituacion.DefaultIfEmpty()
                          orderby pqrsf.Fecha descending
                          select new PQRSFListDTO
                          {
                              Id = pqrsf.Id,
                              Fecha = pqrsf.Fecha,
                              Tipo = pqrsf.Tipo,
                              Asunto = pqrsf.Asunto,
                              Descripcion = pqrsf.Descripcion,
                              IdEstado = est.Id,
                              Estado = est.Nombre,
                              NroIdResponsable = pqrsf.NroIdResponsable,
                              NombreAgente = age.NombreCompleto,
                              IdPrioridad = prio.Id,
                              Prioridad = prio.Nombre,
                              IdSituacion = situ.Id,
                              IdProceso = pqrsf.IdProceso,
                              TipoSituacion = situ.TipoSituacion,
                              NombreCliente = cli.Ternom,
                              Email = cli.Termail,
                              NombreContacto = cont.NombreContacto,
                          }).ToListAsync();
        }

        public async Task<PQRSFShowDTO> GetPQRSFByCliente(int? id, string NroIdeCli)
        {
            PQRSFShowDTO pqrsfShow = new PQRSFShowDTO();
            List<Archivo> listArchivos = new List<Archivo>();
            List<NotaPQRSFListDTO> notas = new List<NotaPQRSFListDTO>();

            pqrsfShow = await (from pqrsf in contex.MatrizPQRSF
                               join estado in contex.PQRSFEstados on pqrsf.IdEstado equals estado.Id
                               join contacto in contex.ContactosCliente on pqrsf.IdContacto equals contacto.Id
                               join cliente in contex.accglTer on pqrsf.NroIdeCli equals cliente.Ternit
                               join situacion in contex.SituacionesNoConformes on pqrsf.IdSituacion equals situacion.Id
                               where pqrsf.Id == id & pqrsf.NroIdeCli == NroIdeCli
                               select new PQRSFShowDTO
                               {
                                   Id = pqrsf.Id,
                                   Fecha = pqrsf.Fecha,
                                   Tipo = pqrsf.Tipo,
                                   Estado = estado.Nombre,
                                   Asunto = pqrsf.Asunto,
                                   DescripcionSituacion = pqrsf.Descripcion,
                                   NombreContacto = contacto.NombreContacto,
                                   Telefono = contacto.Telefono,
                                   Celular = contacto.Celular,
                                   Email = contacto.Email,
                                   NombreCliente = cliente.Ternom,
                                   TipoSituacion = situacion.TipoSituacion,
                               }).FirstOrDefaultAsync();

            listArchivos = await (from archivo in contex.Archivos
                                  where archivo.CodPQRSF == id
                                  select new Archivo
                                  {
                                      Id = archivo.Id,
                                      CodPQRSF = archivo.CodPQRSF,
                                      ContentType = archivo.ContentType,
                                      Nombre = archivo.Nombre,
                                      Ruta = archivo.Ruta,
                                      Url = archivo.Url
                                  }).ToListAsync();

            notas = await (from trazabilidad in contex.NotasPQRSFs
                           join autor in contex.accglTer on trazabilidad.NroIdeAutor equals autor.Ternit
                           where trazabilidad.IdPQRSF == id & trazabilidad.Tipo == "Nota"
                           orderby trazabilidad.Fecha ascending
                           select new NotaPQRSFListDTO
                           {
                               Id = trazabilidad.Id,
                               Fecha = trazabilidad.Fecha,
                               Nota = trazabilidad.Nota,
                               Autor = autor.Ternom
                           }).ToListAsync();

            pqrsfShow.ListArchivos = listArchivos;
            pqrsfShow.ListNotas = notas;
            return pqrsfShow;
        }

        public async Task<PQRSFCreateDTO> PreparePQRSFToCreate(string nroIde)
        {
            PQRSFCreateDTO newPQRSF = new PQRSFCreateDTO();

            var contactos = await (from c in contex.ContactosCliente
                                   select new ContactoCliente()
                                   {
                                       Id = c.Id,
                                       NombreContacto = c.NombreContacto,
                                   }).ToListAsync();

            var situaciones = await (from s in contex.SituacionesNoConformes
                                     select new Situacion()
                                     {
                                         Id = s.Id,
                                         TipoSituacion = s.TipoSituacion,
                                     }).ToListAsync();

            var cliente = await (from ter in contex.accglTer
                                 where ter.Ternit == nroIde
                                 select new Models.Cliente()
                                 {
                                     Id = 0,
                                     NombreCompleto = ter.Ternom,
                                     NroId = ter.Ternit,
                                     NitEmpresa = ""
                                 }).FirstAsync();

            newPQRSF.NroIdeCli = cliente.NroId;
            newPQRSF.NombreCliente = cliente.NombreCompleto;
            newPQRSF.NitEmpresa = cliente.NitEmpresa;
            newPQRSF.ContactoClientes = contactos.ToList();
            newPQRSF.Situaciones = situaciones.ToList();

            return newPQRSF;
        }

        public async Task<PQRSFProfilerDTO> GetPQRSFToProfiler(int? id)
        {
            return await (from pqrsf in contex.MatrizPQRSF
                          join estado in contex.PQRSFEstados on pqrsf.IdEstado equals estado.Id
                          join prioridad in contex.PQRSFPrioridades on pqrsf.IdPrioridad equals prioridad.Id
                          join contacto in contex.ContactosCliente on pqrsf.IdContacto equals contacto.Id
                          join cliente in contex.accglTer on pqrsf.NroIdeCli equals cliente.Ternit
                          join situacion in contex.SituacionesNoConformes on pqrsf.IdSituacion equals situacion.Id
                          where pqrsf.Id == id
                          select new PQRSFProfilerDTO
                          {
                              Id = pqrsf.Id,
                              Fecha = pqrsf.Fecha,
                              FechaCierre = pqrsf.FechaCierre,
                              Tipo = pqrsf.Tipo,
                              Asunto = pqrsf.Asunto,
                              IdEstado = estado.Id,
                              Estado = estado.Nombre,
                              IdPrioridad = prioridad.Id,
                              Etiquetas = pqrsf.Etiquetas,
                              Descripcion = pqrsf.Descripcion,
                              Perfilacion = pqrsf.Perfilacion,
                              NroIdResponsable = pqrsf.NroIdResponsable,
                              IdProceso = pqrsf.IdProceso,
                              IdSituacion = situacion.Id,
                              TipoSituacion = situacion.TipoSituacion,
                              NroIdeCli = cliente.Ternit,
                              NombreCliente = cliente.Ternom,
                              EmailCliente = cliente.Termail,
                              IdContacto = contacto.Id,
                              NombreContacto = contacto.NombreContacto,
                              Telefono = contacto.Telefono,
                              Celular = contacto.Celular,
                              Email = contacto.Email,
                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PQRSFListDTO>> GetAllPQRSFByAgente(string NroIdAge)
        {
            return await (from pqrsf in contex.MatrizPQRSF
                          join estado in contex.PQRSFEstados on pqrsf.IdEstado equals estado.Id into pqrsfEstado
                          from est in pqrsfEstado.DefaultIfEmpty()
                          join agente in contex.Agentes on pqrsf.NroIdResponsable equals agente.NroId into pqrsfAgente
                          from age in pqrsfAgente.DefaultIfEmpty()
                          join prioridad in contex.PQRSFPrioridades on pqrsf.IdPrioridad equals prioridad.Id into pqrsfPrioridad
                          from prio in pqrsfPrioridad.DefaultIfEmpty()
                          join contacto in contex.ContactosCliente on pqrsf.IdContacto equals contacto.Id into pqrsfContacto
                          from cont in pqrsfContacto.DefaultIfEmpty()
                          join cliente in contex.accglTer on pqrsf.NroIdeCli equals cliente.Ternit into pqrsfCliente
                          from cli in pqrsfCliente.DefaultIfEmpty()
                          join situacion in contex.SituacionesNoConformes on pqrsf.IdSituacion equals situacion.Id into pqrsfSituacion
                          from situ in pqrsfSituacion.DefaultIfEmpty()
                          where pqrsf.NroIdResponsable == NroIdAge
                          orderby pqrsf.Fecha descending
                          select new PQRSFListDTO
                          {
                              Id = pqrsf.Id,
                              Fecha = pqrsf.Fecha,
                              Tipo = pqrsf.Tipo,
                              Asunto = pqrsf.Asunto,
                              Descripcion = pqrsf.Descripcion,
                              IdEstado = pqrsf.IdEstado,
                              Estado = est.Nombre,
                              NombreAgente = age.NombreCompleto,
                              Prioridad = prio.Nombre,
                              TipoSituacion = situ.TipoSituacion,
                              NombreCliente = cli.Ternom,
                              NombreContacto = cont.NombreContacto,
                              FechaCierreReal = pqrsf.FechaCierreReal,
                              NroIdCerro = pqrsf.NroIdCerro
                          }).ToListAsync();
        }

        public async Task<PQRSFReportDTO> GetPQRSFToReport(int? id)
        {
            PQRSFReportDTO pqrsfReport = new PQRSFReportDTO();
            List<TratamientoPQRSFListDTO> listTratamientos = new List<TratamientoPQRSFListDTO>();
            List<SeguimientoPQRSFListDTO> listSeguimientos = new List<SeguimientoPQRSFListDTO>();
            List<RespuestaListDTO> listRespuestasCierre = new List<RespuestaListDTO>();

            pqrsfReport = await (from pqrsf in contex.MatrizPQRSF
                                 join agente in contex.Agentes on pqrsf.NroIdResponsable equals agente.NroId
                                 join cliente in contex.accglTer on pqrsf.NroIdeCli equals cliente.Ternit
                                 join situacion in contex.SituacionesNoConformes on pqrsf.IdSituacion equals situacion.Id
                                 join contacto in contex.ContactosCliente on pqrsf.IdContacto equals contacto.Id
                                 join proceso in contex.Procesos on pqrsf.IdProceso equals proceso.codare into proce
                                 from p in proce.DefaultIfEmpty()
                                 join estado in contex.PQRSFEstados on pqrsf.IdEstado equals estado.Id
                                 join prioridad in contex.PQRSFPrioridades on pqrsf.IdPrioridad equals prioridad.Id
                                 where pqrsf.Id == id
                                 select new PQRSFReportDTO
                                 {
                                     Id = pqrsf.Id,
                                     Fecha = pqrsf.Fecha,
                                     Tipo = pqrsf.Tipo,
                                     Descripcion = pqrsf.Descripcion,
                                     Etiquetas = pqrsf.Etiquetas,
                                     Asunto = pqrsf.Asunto,
                                     FechaCierre = pqrsf.FechaCierre,
                                     AgenteResposable = agente.NombreCompleto,
                                     TipoSituacion = situacion.TipoSituacion,
                                     Proceso = p.nomare,
                                     Estado = estado.Nombre,
                                     Prioridad = prioridad.Nombre,
                                     NroIdeCli = cliente.Ternit,
                                     NombreCliente = cliente.Ternom,
                                     EmailCliente = cliente.Termail,
                                     NombreContacto = contacto.NombreContacto,
                                     TelefonoContacto = contacto.Telefono,
                                     CelularContacto = contacto.Celular,
                                     EmailContacto = contacto.Email
                                 }).FirstOrDefaultAsync();

            listTratamientos = await (from tratamiento in contex.TratamientoPQRSFs
                                      join responsable in contex.accglTer on tratamiento.NroIdResponsable equals responsable.Ternit
                                      where tratamiento.IdPQRSF == id
                                      select new TratamientoPQRSFListDTO
                                      {
                                          Actividad = tratamiento.Actividad,
                                          NombreResponsable = responsable.Ternom,
                                          FechaCumplimiento = tratamiento.FechaCumplimiento
                                      }).ToListAsync();

            listSeguimientos = await (from seguimiento in contex.SeguimientoPQRSFs
                                      where seguimiento.IdPQRSF == id
                                      select new SeguimientoPQRSFListDTO
                                      {
                                          Fecha = seguimiento.Fecha,
                                          Observaciones = seguimiento.Observaciones
                                      }).ToListAsync();

            listRespuestasCierre = await (from respuestas in contex.Respuestas
                                          join pregunta in contex.Preguntas on respuestas.IdPregunta equals pregunta.Id
                                          where respuestas.IdPQRSF == id
                                          select new RespuestaListDTO
                                          {
                                              Pregunta = pregunta.NomPregunta,
                                              Opcion = respuestas.Opcion
                                          }).ToListAsync();

            if (listTratamientos.Count > 0)
            {
                pqrsfReport.ListTratamientos = listTratamientos;
            }
            if (listSeguimientos.Count > 0)
            {
                pqrsfReport.ListSeguimientos = listSeguimientos;
            }
            if (listRespuestasCierre.Count > 0)
            {
                pqrsfReport.ListRespuestasCierre = listRespuestasCierre;
            }

            return pqrsfReport;
        }

        public async Task<IEnumerable<ProPqrsf>> GetPqrsf(FilterPQRSFDTO filter, string KeyConnection)
        {
            var parms = new DynamicParameters();

            parms.Add("Operacion", "GETPQRSFS");
            parms.Add("FechaIniC", filter.FechaCreacionIni.Replace("-", ""));
            parms.Add("FechaFinC", filter.FechaCreacionFin.Replace("-", ""));
            parms.Add("Agente", filter.Agente);
            parms.Add("Area", filter.Area);
            parms.Add("Tipo", filter.Tipo);
            parms.Add("Estado", filter.Estado);
            parms.Add("Prioridad", filter.Prioridad);
            parms.Add("Cliente", filter.Cliente);
            parms.Add("Search", filter.Search);

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            return await connection.QueryAsync<ProPqrsf>("WEBGLSS_SP_PQRSF", parms, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ProPqrsf>> GetAllPQRSFByUser(string NroId, FilterPQRSFDTO filter, string KeyConnection)
        {
            List<ProPqrsf> propqrsfs = new List<ProPqrsf>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operacion", Value = "GETPQRSFSBYUSER"},
                new SqlParameter { ParameterName = "@NroIdeCli", Value = NroId},
                new SqlParameter { ParameterName = "@FechaIniC", Value = filter.FechaCreacionIni.Replace("-","")},
                new SqlParameter { ParameterName = "@FechaFinC", Value = filter.FechaCreacionFin.Replace("-","")},
                new SqlParameter { ParameterName = "@Agente", Value = filter.Agente},
                new SqlParameter { ParameterName = "@Area", Value = filter.Area},
                new SqlParameter { ParameterName = "@Tipo", Value = filter.Tipo},
                new SqlParameter { ParameterName = "@Estado", Value = filter.Estado},
                new SqlParameter { ParameterName = "@Prioridad", Value = filter.Prioridad},
                new SqlParameter { ParameterName = "@Cliente", Value = filter.Cliente},
                new SqlParameter { ParameterName = "@Search", Value = filter.Search},
            };

            var connection = new SqlConnection(configuration.GetConnectionString(KeyConnection));

            var query = await ExecuteQueryDataTable("WEBGLSS_SP_PQRSF", "datos", CommandType.StoredProcedure, parms.ToArray(), connection);

            propqrsfs = Functions.ConvertToList<ProPqrsf>(query);

            return propqrsfs;
        }
    }
}