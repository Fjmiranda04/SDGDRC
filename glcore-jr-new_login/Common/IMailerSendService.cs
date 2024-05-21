using Common.Model;
using RestSharp;

namespace Common
{
    public interface IMailerSendService
    {
        void SetRequestHeaders(RestRequest request);

        string SendMailerSendEmail(SendEmailRequest sendEmailRequest, string token);

        Data CheckEmail(string id, string token);
    }
}