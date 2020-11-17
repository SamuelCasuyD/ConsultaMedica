using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webmedicas.Models

{
    [Serializable]
    public class CitasDTO
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdConsulta { get; set; }
        public int Edad { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCita { get; set; }
        public DateTime FechaNuevaCita { get; set; }
        public DateTime HoraCita { get; set; }
        public int UsuarioCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public bool Eliminado { get; set; } //Muestra si esta activo o inactivo
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public string NombreConsulta { get; set; }
        public string NombrePaciente { get; set; }
        public string Sexo { get; set; }
        public string Comentario { get; set; }

        public CitasDTO()
        { }

    }
}