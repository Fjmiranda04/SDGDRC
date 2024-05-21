using Common.Model;

using RestSharp;
using System;
using System.Text.Json;

namespace Common.Implements
{
    public class MailerSendService
    {
        public void SetRequestHeaders(RestRequest request)
        {
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
        }

        public string SendMailerSendEmail(SendEmailRequest sendEmailRequest, string token)
        {
            var client = new RestClient("https://api.mailersend.com/v1/");

            var request = new RestRequest("email");
            request.AddHeader("Authorization", token);

            SetRequestHeaders(request);
            request.AddJsonBody(sendEmailRequest);

            var response = client.ExecutePost(request);

            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                throw new Exception(response.Content);
            }

            //var idmessage = (response.Headers as List<Parameter>).Find(x => x.Name == "X-Message-Id").Value.ToString();

            return "";
        }

        public Data CheckEmail(string id, string token)
        {
            var client = new RestClient("https://api.mailersend.com/v1/");

            var request = new RestRequest($"messages/{id}");
            request.AddHeader("Authorization", token);

            SetRequestHeaders(request);
            //request.add AddJsonBody(JsonConvert.SerializeObject(sendEmailRequest));

            var response = client.ExecuteGet(request);
            return JsonSerializer.Deserialize<Data>(response.Content);
        }
    }
}