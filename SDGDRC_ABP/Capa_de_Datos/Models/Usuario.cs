using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Capa_de_Datos.Models;

public partial class Usuario 
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Email { get; set; }

    public string Tipo { get; set; }

    public virtual ICollection<Administrador> Administradors { get; set; } = new List<Administrador>();

    public virtual ICollection<Coordinador> Coordinadors { get; set; } = new List<Coordinador>();

    public virtual ICollection<Informe> Informes { get; set; } = new List<Informe>();

    public virtual ICollection<Voluntario> Voluntarios { get; set; } = new List<Voluntario>();
}
