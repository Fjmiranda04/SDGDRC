using System;
using System.Collections.Generic;

namespace Capa_de_Datos.Models;

public partial class Informe
{
    public int IdInforme { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? EncargadoId { get; set; }

    public int? RegistroResiduoId { get; set; }

    public virtual Usuario? Encargado { get; set; }

    public virtual RegistroDeResiduo? RegistroResiduo { get; set; }
}
