using Common.Model;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using System.Collections.Generic;

namespace Common
{
    public interface IMail
    {
        bool SendMail(string body, List<string> destinatarios, EmailConfiguracion emailConfiguracion, List<Attachment> attachments = null);

        void SendMailPQRSF(ProPqrsf sendPqrsf, List<Agente> sendAgente, EmailConfiguracion emailConfiguracion, string url = "", string urlAgente = "");
    }
}