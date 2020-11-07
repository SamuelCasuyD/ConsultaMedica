using System;

namespace Webmedicas.Models
{
    public class MedicoDTO
    {
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; }
        public string Colegiado { get; set; }
        public string Especialidad { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}