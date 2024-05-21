using System;
using System.Collections.Generic;

namespace Capa_de_Datos.Models;

public partial class Voluntario
{
    public int IdVoluntario { get; set; }

    public string? Ubicación { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<RegistroDeResiduo> RegistroDeResiduos { get; set; } = new List<RegistroDeResiduo>();

    public virtual ICollection<Rutum> Ruta { get; set; } = new List<Rutum>();
}
