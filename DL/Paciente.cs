using System;
using System.Collections.Generic;

namespace DL;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string? Nombre { get; set; }

    public string? Ap { get; set; }

    public string? Am { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public byte? IdTipoSangre { get; set; }

    public string? Sexo { get; set; }

    public string? Sintomas { get; set; }

    public virtual TipoSangre? IdTipoSangreNavigation { get; set; }
}
