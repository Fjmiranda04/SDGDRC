using System;
using System.Collections.Generic;

namespace Capa_de_Datos.Models;

public partial class Rutum
{
    public int IdRuta { get; set; }

    public DateTime Fecha { get; set; }

    public int CoordinadorAsociado { get; set; }

    public int VoluntariosAsociados { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }

    public virtual Coordinador? CoordinadorAsociadoNavigation { get; set; }

    public virtual Voluntario? VoluntariosAsociadosNavigation { get; set; }
}
