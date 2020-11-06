using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webmedicas.Models
{
    [Serializable()]
    [JsonObject]
    public class RespuestaDTO
    {
        public bool Resultado { get; set; }
        public string Mensaje { get; set; }
        public int DocEntry { get; set; }
        public string MensajeAux { get; set; }

        public RespuestaDTO()
        {
            Resultado = false;
            Mensaje = String.Empty;           
        }
    }
}