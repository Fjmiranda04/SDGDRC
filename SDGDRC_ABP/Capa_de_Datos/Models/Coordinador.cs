using System;
using System.Collections.Generic;

namespace Capa_de_Datos.Models;

public partial class Coordinador
{
    public int IdCoordinador { get; set; }

    public string? ÁreaDeResponsabilidad { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Rutum> Ruta { get; set; } = new List<Rutum>();
}
