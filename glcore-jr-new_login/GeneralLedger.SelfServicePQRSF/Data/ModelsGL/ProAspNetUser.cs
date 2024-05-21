using System;

namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public class ProAspNetUser
    {
        public string Id { get; set; }
        public string NroId { get; set; }
        public string Nombre { get; set; }
        public string PriNombre { get; set; }
        public string SegNombre { get; set; }
        public string PriApellido { get; set; }
        public string SegApellido { get; set; }
        public int IdEmpresa { get; set; }
        public string NitEmpresa { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Dependencia { get; set; }
        public string UserGL { get; set; }
        public string KeyConnection { get; set; }
    }
}