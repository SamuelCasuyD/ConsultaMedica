using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webmedicas.Models
{
    public class AnexoDTO
    {
        public int idAnexo { get; set; }
        public int IdPaciente { get; set; }

        public string ruta { get; set; }

        public string Extencion { get; set; }

        public string NombreArchivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public byte[] ContentArray { get; set; }
        public int ContentLength { get; set; }
        public AnexoDTO()
        {
            FechaCreacion = DateTime.Now;

        }
    }
}