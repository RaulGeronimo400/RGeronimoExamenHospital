using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string? Nombre { get; set; }
        public string? AP { get; set; }
        public string? AM { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? FechaIngreso { get; set; }
        public TipoSangre? Tipo { get; set; }
        public string? Sexo { get; set; }
        public string? Sintomas { get; set; }
        public List<object>? Pacientes { get; set; }
    }
}
