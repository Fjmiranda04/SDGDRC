using Capa_de_Datos.Models.ModelsDTO;
using Capa_de_Datos.Models;
using System.Collections.Generic; 
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Capa_de_Negocios.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace Capa_de_Negocios.Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly string _claveSecreta;
        private readonly IAuthRepository _authRepository;

        public AuthService(IConfiguration configuration, IAuthRepository authRepository)
        {
            _claveSecreta = configuration["Jwt:ClaveSecreta"]; // Obtener la clave secreta de la configuración
            _authRepository = authRepository;
        }

        public async Task<string> GenerarTokenAcceso(Usuario usuario)
        {
            var clave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_claveSecreta));
            var credenciales = new SigningCredentials(clave, SecurityAlgorithms.HmacSha512Signature);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
            new Claim(ClaimTypes.Name, usuario.Email)
            // Agregar más claims según tus necesidades (por ejemplo, roles de usuario)
        };

            var descripcionToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7), // Token expira en 7 días
                SigningCredentials = credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(descripcionToken);

            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> ValidarTokenAcceso(string token)
        {
            var parametrosValidacion = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_claveSecreta)),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, parametrosValidacion, out SecurityToken tokenValidado);
            }
            catch
            {
                // La validación del token falló
                return false;
            }

            // La validación del token fue exitosa
            return true;
        }

        public async Task<Usuario> Login(string email, string password)
        {
            var usuario = await _authRepository.Login(email, password);
            return usuario;
        }
    }


   /* public class AuthService : IAuthService
    {
        private readonly string _claveSecreta;
        private readonly IAuthRepository _authRepository;

        public AuthService(IConfiguration configuration, IAuthRepository authRepository)
        {
            _claveSecreta = configuration["Jwt:ClaveSecreta"]; // Obtener la clave secreta de la configuración
            _authRepository = authRepository;
        }

        public async Task<string> GenerarTokenAcceso(Usuario usuario)
        {
            var clave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_claveSecreta));
            var credenciales = new SigningCredentials(clave, SecurityAlgorithms.HmacSha512Signature);

            // Determinar los roles del usuario
            var roles = ObtenerRolesUsuario(usuario.Tipo);

            // Crear las reclamaciones (claims) del usuario
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
            new Claim(ClaimTypes.Name, usuario.Email),
        };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            // Configurar la descripción del token
            var descripcionToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7), // Token expira en 7 días
                SigningCredentials = credenciales
            };

            // Crear el token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(descripcionToken);

            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> ValidarTokenAcceso(string token)
        {
            var parametrosValidacion = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_claveSecreta)),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, parametrosValidacion, out SecurityToken tokenValidado);
            }
            catch
            {
                // La validación del token falló
                return false;
            }

            // La validación del token fue exitosa
            return true;
        }

        public async Task<Usuario> Login(string email, string password)
        {
            var usuario = await _authRepository.Login(email, password);
            return usuario;
        }

        private string[] ObtenerRolesUsuario(string tipoUsuario)
        {
            switch (tipoUsuario)
            {
                case "Administrador":
                    return new[] { "Administrador", "Voluntario", "Coordinador" };
                case "Voluntario":
                    return new[] { "Voluntario" };
                case "Coordinador":
                    return new[] { "Coordinador" };
                default:
                    throw new ArgumentException("Tipo de usuario no reconocido");
            }
        }
    }*/
}
