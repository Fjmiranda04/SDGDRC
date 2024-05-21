namespace GeneralLedger.SelfServiceCore.Data.ModelsGL
{
    public class ProConfiguracion
    {
    }

    public class ProPermisos
    {
        public int Id { get; set; }
        public string Permiso { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
    }

    public class ProPermisosUsuarios
    {
        public string IdUsuario { get; set; }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Permiso { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }

    public class ProRolesUsuarios
    {
        public string IdRol { get; set; }
        public string IdUsuario { get; set; }
        public string NombreRol { get; set; }
        public bool Activo { get; set; }
    }
}