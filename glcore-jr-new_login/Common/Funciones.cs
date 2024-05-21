using Azure;
using RestSharp;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Common
{
    public class Funciones
    {
        public static void ExecuteExe(string rutaArchivo, string[] argumentos)
        {
            // Configurar el proceso de inicio
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = rutaArchivo,
                Arguments = argumentos[0],
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            // Iniciar el proceso
            using (Process proceso = new Process())
            {
                proceso.StartInfo = startInfo;
                proceso.Start();
                proceso.WaitForExit();

                // Leer la salida del proceso si es necesario
                string salida = proceso.StandardOutput.ReadToEnd();

                // Puedes hacer algo con la salida del proceso si lo deseas
            }
            //}
        }

        public static string HideEmail(string email)
        {
            string[] partesCorreo = email.Split('@');

            // Obtener el nombre de usuario y el dominio
            string nombreUsuario = partesCorreo[0];
            string dominio = partesCorreo[1];

            // Obtener la longitud del nombre de usuario
            int longitudNombreUsuario = nombreUsuario.Length;

            // Ocultar parte del nombre de usuario (excepto el primer y último carácter) con asteriscos
            string nombreUsuarioOculto = nombreUsuario.Substring(0, 1) + new string('*', longitudNombreUsuario - 2) + nombreUsuario.Substring(longitudNombreUsuario - 1);

            // Devolver el correo electrónico oculto
            return nombreUsuarioOculto + "@" + dominio;
        }

        public static RestResponse Post(string baseUrl,string method, string json,string type, string autorizacion = null)
        {
            try
            {
                var client = new RestClient(baseUrl + method);
                var request = new RestRequest(type);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);

                if (autorizacion != null)
                {
                    request.AddHeader("Authorization", autorizacion);
                }

                RestResponse response = client.Execute(request);

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}