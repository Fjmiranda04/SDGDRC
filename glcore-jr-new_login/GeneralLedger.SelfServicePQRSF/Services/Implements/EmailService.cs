using GeneralLedger.SelfServiceCore.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace GeneralLedger.SelfServiceCore.Services.Implements
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(PQRSFShowDTO pqrsf, List<AgenteShowDTO> agentes)
        {
            #region ConfiguracionInfoCorreoCliente

            string emailBodyCliente = $"Cordial saludo Sr(a). {pqrsf.NombreCliente}. \n\n" +
                               $"Usted ha enviado una nueva PQRSF con la siguiente información: \n\n" +
                               $"Fecha de radicación: {pqrsf.Fecha}\n" +
                               $"PQRSF Nro: {pqrsf.Id}\n" +
                               $"Tipo de PQRSF: {pqrsf.TipoSituacion}\n\n" +
                               $"Descripción: {pqrsf.DescripcionSituacion} \n\n" +
                               $"Unos de nuestros agentes atendera su PQRSF en la brevedad posible.\n\n¡Felíz día!";
            string emailToCliente = pqrsf.Email;
            string emailHeaderCliente = $"Nueva PQRSF de tipo ({pqrsf.TipoSituacion}) enviada";

            #endregion ConfiguracionInfoCorreoCliente

            #region ConfiguracionInfoCorreoAgente

            string emailBodyAgente = $"Cordial saludo Agente de General Ledger. \n\n" +
                               $"Hay una nueva PQRSF enviada por el cliente {pqrsf.NombreCliente} con la siguiente información: \n\n" +
                               $"Fecha de radicación: {pqrsf.Fecha}\n" +
                               $"PQRSF Nro: {pqrsf.Id}\n" +
                               $"Tipo de PQRSF: {pqrsf.TipoSituacion}\n\n" +
                               $"Descripción: {pqrsf.DescripcionSituacion}";
            string emailToAgente = "";
            foreach (var item in agentes)
            {
                if (emailToAgente == "")
                {
                    emailToAgente += item.Email;
                }
                else
                {
                    emailToAgente = emailToAgente + "," + item.Email;
                }
            }

            string emailHeaderAgente = $"Nueva PQRSF enviada - El cliente {pqrsf.NombreCliente} ha enviado una {pqrsf.TipoSituacion}";

            #endregion ConfiguracionInfoCorreoAgente

            #region ConfiguracionDeCorreo

            string displayName = "General Ledger";
            string smtpClient = "smtp.office365.com";
            int smtpPort = 587;
            string passwordEmail = "jerh_jairo1923";
            string emailFrom = "jairo142014@hotmail.com";
            List<string> emailAttachments = new List<string>();
            foreach (var item in pqrsf.ListArchivos)
            {
                emailAttachments.Add(item.Ruta);
            }
            //string emailAttachments = pqrsf.Ruta;

            #endregion ConfiguracionDeCorreo

            bool emailSend = false;
            //CONFIGURACION DE ENVIO DE CORREO PARA LOS CLIENTES

            #region EmailCliente

            emailSend = Send(emailHeaderCliente, emailBodyCliente, emailAttachments, emailFrom, displayName, emailToCliente, smtpClient, smtpPort, passwordEmail);

            #endregion EmailCliente

            #region EmailAgentes

            emailSend = Send(emailHeaderAgente, emailBodyAgente, emailAttachments, emailFrom, displayName, emailToAgente, smtpClient, smtpPort, passwordEmail);

            #endregion EmailAgentes

            return emailSend;
        }

        public bool Send(string emailHeader, string emailBody, List<string> emailAttachments, string emailFrom, string displayName, string emailTo, string smtpClient, int smtpPort, string passwordEmail)
        {
            bool sendMail = false;

            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.Subject = emailHeader;
                mailMessage.Body = emailBody;
                mailMessage.From = new MailAddress(emailFrom, displayName);
                mailMessage.To.Add(emailTo);
                mailMessage.IsBodyHtml = false;

                if (emailAttachments.Count > 0)
                {
                    foreach (var item in emailAttachments)
                    {
                        mailMessage.Attachments.Add(new Attachment(item));
                    }
                }
                /*if(emailAttachments != null && emailAttachments != ""){
                    mailMessage.Attachments.Add(new Attachment(emailAttachments));
                }*/

                SmtpClient smtp = new SmtpClient(smtpClient, smtpPort);
                smtp.Credentials = new NetworkCredential(emailFrom, passwordEmail);
                smtp.EnableSsl = true;
                smtp.Send(mailMessage);
                sendMail = true;
            }
            catch (Exception ex)
            {
                sendMail = false;
                throw new Exception(ex.ToString());
            }

            return sendMail;
        }
    }
}