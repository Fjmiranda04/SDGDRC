using System;
using System.Collections.Generic;

namespace Capa_de_Datos.Models;

public partial class RegistroDeResiduo
{
    public int IdRegistro { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Tipo { get; set; }

    public int? Cantidad { get; set; }

    public string? Ubicación { get; set; }

    public int? VoluntarioRegistrador { get; set; }

    public virtual ICollection<Informe> Informes { get; set; } = new List<Informe>();

    public virtual Voluntario? VoluntarioRegistradorNavigation { get; set; }
}
