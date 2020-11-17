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
        public int IdMedico { get; set; }
        public int IdConsulta { get; set; }
        public int IdEstado { get; set; }
        public string NombrePaciente { get; set; }
        public string Sexo { get; set; }
        public string DPI { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public DateTime FechaCita { get; set; }
        public DateTime FechaNuevaCita { get; set; }
        public DateTime HoraCita { get; set; }
        public decimal CostoConsulta { get; set; }
        public string Comentario { get; set; }
        public bool Eliminado { get; set; } //Muestra si esta activo o inactivo

        public PacienteDTO()
        {
            //HoraCita = DateTime.Now.ToShortTimeString();
        }
    }
}