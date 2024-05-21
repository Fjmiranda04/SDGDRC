using Common.Model;
using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common.Implements
{
    public class Mail : IMail
    {
        public void SendMailPQRSF(ProPqrsf pqrsf, List<Agente> sendAgente, EmailConfiguracion emailConfiguracion, string urlCliente = "", string urlAgente = "")
        {
            var emailBodyCliente = emailConfiguracion.Cuerpo;
            emailBodyCliente = emailBodyCliente.Replace("<<NOMBRECLIENTE>>", pqrsf.NombreCliente);
            emailBodyCliente = emailBodyCliente.Replace("<<FECHA>>", pqrsf.Fecha.ToString());
            emailBodyCliente = emailBodyCliente.Replace("<<NUMERO>>", pqrsf.Codigo.ToString());
            emailBodyCliente = emailBodyCliente.Replace("<<TIPO>>", pqrsf.TipoSituacion);
            emailBodyCliente = emailBodyCliente.Replace("<<DESCRIPCION>>", pqrsf.Descripcion);
            emailBodyCliente = emailBodyCliente.Replace("<<LINK>>", urlCliente);

            List<string> destinatarios = new List<string>();
            destinatarios.Add(pqrsf.EmailCliente);

            SendMail(emailBodyCliente, destinatarios, emailConfiguracion);

            var emailBodyAgente = $"Cordial saludo Sr(a). Agente de General Ledger <br>" +
                               $"Hay una nueva PQRSF enviada por el cliente {pqrsf.NombreCliente} con la siguiente información: <br>" +
                               $"Fecha de radicación: {pqrsf.Fecha}<br>" +
                               $"PQRSF Nro: {pqrsf.Codigo}<br>" +
                               $"Tipo de PQRSF: {pqrsf.TipoSituacion}<br>" +
                               $"Descripción: {pqrsf.Descripcion}<br>" + $"<br> <a href='{urlAgente}'>Ver PQRSF</a>";

            List<string> destinatariosAgentes = new List<string>();
            foreach (var agente in sendAgente)
            {
                destinatariosAgentes.Add(agente.Email);
            }
            SendMail(emailBodyAgente, destinatariosAgentes, emailConfiguracion);
        }

        public bool SendMail(string body, List<string> destinatarios, List<Archivo> archivos, EmailConfiguracionDTO emailConfiguracion)
        {
            try
            {
                var keyValuePairs = new Dictionary<string, object>{
                    {"nombreNotificacion", emailConfiguracion.Titulo },
                    {"cuerpoNotificacion", body },
                    {"imageEmpresa", emailConfiguracion.LogoEmpresa},
                    {"webEmpresa",  emailConfiguracion.WebEmpresa},
                    {"nombreEmpresa", emailConfiguracion.NombreEmpresa}
                };

                var sendemailrequest = new SendEmailRequest
                {
                    from = new Recipient()
                    {
                        //REMITENTE
                        email = emailConfiguracion.Remitente,
                        name = emailConfiguracion.NombreRemitente
                    },

                    to = new List<Recipient>(),
                    cc = new List<Recipient>(),
                    variables = new List<Variable>(),
                    attachments = new List<Attachment>(),
                    subject = emailConfiguracion.Asunto,
                    template_id = emailConfiguracion.Template
                };

                //DESTINATARIO
                foreach (var destinatario in destinatarios)
                {
                    sendemailrequest.to.Add(new Recipient { email = destinatario, name = destinatario });
                }

                sendemailrequest.to = sendemailrequest.to.GroupBy(x => x.email).Select(y => y.First()).ToList();
                sendemailrequest.text = "";
                sendemailrequest.html = "";
                var variablesnew = new List<Variable>();

                foreach (var to in sendemailrequest.to)
                {
                    var variablenew = new Variable
                    {
                        email = to.email,
                        substitutions = new List<Substitution>()
                    };

                    foreach (var keyValuePair in keyValuePairs)
                    {
                        variablenew.substitutions.Add(new Substitution
                        {
                            var = keyValuePair.Key,
                            value = keyValuePair.Value.ToString()
                        });
                    }
                    variablesnew.Add(variablenew);
                }

                if (archivos.Count > 0)
                {
                    List<Model.Attachment> attachments = new List<Model.Attachment>();

                    foreach (var archivo in archivos)
                    {
                        var attachment = new Model.Attachment
                        {
                            filename = archivo.Nombre,
                            content = Convert.ToBase64String(File.ReadAllBytes(archivo.Ruta)),
                        };
                        attachments.Add(attachment);
                    }

                    sendemailrequest.attachments = new List<Model.Attachment>();
                    sendemailrequest.attachments.AddRange(attachments);
                }

                var emailReply = emailConfiguracion.ReplyTo;
                var emailReplyCfg = emailConfiguracion.ReplyTo;

                sendemailrequest.variables.AddRange(variablesnew);
                sendemailrequest.to.AddRange(sendemailrequest.cc);

                sendemailrequest.reply_to = new Recipient
                {
                    email = string.IsNullOrWhiteSpace(emailReply) ? emailReplyCfg.Split(Convert.ToChar(";")).First() : emailReply.Split(Convert.ToChar(";")).First(),
                    name = emailReply
                };

                var mailersendservice = new MailerSendService();
                var mailId = mailersendservice.SendMailerSendEmail(sendemailrequest, emailConfiguracion.Token);

                //HandleInvoiceEmailResponse(mailId, sendemailrequest.To, documento, Database, usuario, "VC");

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public bool SendMail(string body, List<string> destinatarios, EmailConfiguracion emailConfiguracion, List<Attachment> attachments = null)
        {
            try
            {
                if (attachments == null)
                {
                    attachments = new List<Attachment>();
                }

                var keyValuePairs = new Dictionary<string, object>{
                    {"nombreNotificacion", emailConfiguracion.Titulo },
                    {"cuerpoNotificacion", body },
                    {"imageEmpresa", emailConfiguracion.LogoEmpresa},
                    {"webEmpresa",  emailConfiguracion.WebEmpresa},
                    {"nombreEmpresa", emailConfiguracion.NombreEmpresa}
                };

                var sendemailrequest = new SendEmailRequest
                {
                    from = new Recipient()
                    {
                        //REMITENTE
                        email = emailConfiguracion.Remitente,
                        name = emailConfiguracion.NombreRemitente
                    },

                    to = new List<Recipient>(),
                    cc = new List<Recipient>(),
                    variables = new List<Variable>(),
                    attachments = attachments,
                    subject = emailConfiguracion.Asunto,
                    template_id = emailConfiguracion.Template
                };

                //DESTINATARIO
                foreach (var destinatario in destinatarios)
                {
                    sendemailrequest.to.Add(new Recipient { email = destinatario, name = destinatario });
                }

                sendemailrequest.to = sendemailrequest.to.GroupBy(x => x.email).Select(y => y.First()).ToList();
                sendemailrequest.text = "";
                sendemailrequest.html = "";
                var variablesnew = new List<Variable>();

                foreach (var to in sendemailrequest.to)
                {
                    var variablenew = new Variable
                    {
                        email = to.email,
                        substitutions = new List<Substitution>()
                    };

                    foreach (var keyValuePair in keyValuePairs)
                    {
                        variablenew.substitutions.Add(new Substitution
                        {
                            var = keyValuePair.Key,
                            value = keyValuePair.Value.ToString()
                        });
                    }
                    variablesnew.Add(variablenew);
                }
                var emailReply = emailConfiguracion.ReplyTo;
                var emailReplyCfg = emailConfiguracion.ReplyTo;

                sendemailrequest.variables.AddRange(variablesnew);
                sendemailrequest.to.AddRange(sendemailrequest.cc);

                sendemailrequest.reply_to = new Recipient
                {
                    email = string.IsNullOrWhiteSpace(emailReply) ? emailReplyCfg.Split(Convert.ToChar(";")).First() : emailReply.Split(Convert.ToChar(";")).First(),
                    name = emailReply
                };

                var mailersendservice = new MailerSendService();
                /*var mailId = */
                mailersendservice.SendMailerSendEmail(sendemailrequest, emailConfiguracion.Token);

                //HandleInvoiceEmailResponse(mailId, sendemailrequest.To, documento, Database, usuario, "VC");

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}