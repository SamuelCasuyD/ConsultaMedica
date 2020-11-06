using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webmedicas.Models
{
    [Serializable]
    [JsonObject]
    public class PacienteDTO
    {
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string Sexo { get; set; }
        public string DPI { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal CostoConsulta { get; set; }
        public bool Eliminado { get; set; } //Muestra si esta activo o inactivo

        public PacienteDTO()
        {

        }
    }
}