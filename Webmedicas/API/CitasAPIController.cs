using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace Webmedicas.API
{
    public class CitasAPIController : ApiController
    {

        private String cnString()
        {
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\MBConfig\cfg.txt"))
                {
                    String line = sr.ReadToEnd();
                    return line;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// OBTIENE LA LISTA DE LOS ESTADOS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CitasAPI/GetEstados")]
        public IList<Models.CitasDTO> GetEstados()
        {
            IList<Models.CitasDTO> Cita = new List<Models.CitasDTO>();

            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_CitasMedicas", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 1);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Models.CitasDTO BD = new Models.CitasDTO();
                                BD.IdEstado = reader.GetInt32(reader.GetOrdinal("IdEstado"));
                                BD.NombreEstado = reader.GetString(reader.GetOrdinal("nombreEstado"));
                                Cita.Add(BD);
                            }
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
                return Cita;
            }
        }

        /// <summary>
        /// OBTIENE LA LISTA TICOS DE CONSULTA
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CitasAPI/GetTipoConsulta")]
        public IList<Models.CitasDTO> GetTipoConsulta()
        {
            IList<Models.CitasDTO> consulta = new List<Models.CitasDTO>();
            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_CitasMedicas", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 2);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Models.CitasDTO BD = new Models.CitasDTO();
                                BD.IdConsulta = reader.GetInt32(reader.GetOrdinal("idConsulta"));
                                BD.NombreConsulta = reader.GetString(reader.GetOrdinal("nombreConsulta"));
                                consulta.Add(BD);
                            }
                        }
                    }
                }
                finally { connection.Close(); }
            }
            return consulta;
        }

        /// <summary>
        /// CREA LA CITA DEL PACIENTE
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/CitasAPI/CrearCitasPacientes")]
        public Models.RespuestaDTO CrearCitasPacientes(Models.PacienteDTO value)
        {
            var respuesta = new Models.RespuestaDTO();

            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_CitasMedicas", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 3);
                cmd.Parameters.AddWithValue("param1", value.IdPaciente);
                cmd.Parameters.AddWithValue("param2", value.IdMedico);
                cmd.Parameters.AddWithValue("param3", value.IdConsulta);
                cmd.Parameters.AddWithValue("param4", value.FechaCita);
                //cmd.Parameters.AddWithValue("param5", value.FechaFinalizacion);                
                cmd.Parameters.AddWithValue("param5", value.HoraCita);
                //cmd.Parameters.AddWithValue("param7", value.FechaNuevaCita);
                cmd.Parameters.AddWithValue("param6", value.Comentario);
                cmd.Parameters.AddWithValue("param7", value.FechaCreacion);
                cmd.Parameters.AddWithValue("param8", value.Eliminado);
                cmd.Parameters.AddWithValue("param9", value.IdEstado);

                int a = 0;
                try
                {
                    connection.Open();
                    try
                    {
                        a = cmd.ExecuteNonQuery();
                        respuesta.Resultado = true;
                        respuesta.Mensaje = (a == 0) ? "No se pudo registrar la cita" : "Crecion exitosa";
                    }
                    catch (Exception ex)
                    {
                        respuesta.Mensaje += "Error " + ex.Message;
                    }
                }
                finally { connection.Close(); }
            }
            return respuesta;
        }

        /// <summary>
        /// OBTIENE LA LISTA DE LAS CITAS POR ID MEDICO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CitasAPI/ObtenerListaCitas/{id}")]
        public IList<Models.CitasDTO> ObtenerListaCitas(string id)
        {
            IList<Models.CitasDTO> consulta = new List<Models.CitasDTO>();
            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_CitasMedicas", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 4);
                cmd.Parameters.AddWithValue("Param1", id);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Models.CitasDTO BD = new Models.CitasDTO();
                                BD.IdCita = reader.GetInt32(reader.GetOrdinal("idCita"));
                                BD.IdPaciente = reader.GetInt32(reader.GetOrdinal("idPaciente"));
                                BD.NombrePaciente = reader.GetString(reader.GetOrdinal("nombrePaciente"));
                                BD.Sexo = reader.GetString(reader.GetOrdinal("sexo"));
                                BD.Edad = reader.GetInt32(reader.GetOrdinal("Edad"));
                                BD.IdConsulta = reader.GetInt32(reader.GetOrdinal("idConsulta"));
                                BD.NombreConsulta = reader.GetString(reader.GetOrdinal("nombreConsulta"));
                                BD.FechaCita = reader.IsDBNull(reader.GetOrdinal("fechaCita")) ? DateTime.MinValue : DateTime.Parse(reader.GetString(reader.GetOrdinal("fechaCita")));                                
                                //BD.HoraCita = DateTime.Parse(reader.GetString(reader.GetOrdinal("horaCita")));
                                BD.FechaFinalizacion = reader.IsDBNull(reader.GetOrdinal("fechaFinalizacion")) ? DateTime.MinValue : DateTime.Parse(reader.GetString(reader.GetOrdinal("fechaFinalizacion")));
                                BD.FechaNuevaCita = reader.IsDBNull(reader.GetOrdinal("fechaNuevaCita")) ? DateTime.MinValue : DateTime.Parse(reader.GetString(reader.GetOrdinal("fechaNuevaCita")));
                                BD.NombreEstado = reader.GetString(reader.GetOrdinal("nombreEstado"));
                                consulta.Add(BD);
                            }
                        }
                    }
                }
                finally { connection.Close(); }
            }
            return consulta;
        }

        /// <summary>
        /// OBTIENE EL DETALLE DE LA CITA POR MEDIO DEL IDCITA
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CitasAPI/GetDetalleCita/{id}")]
        public Models.CitasDTO GetDetalleCita(string id)
        {
            var paciente = new Models.CitasDTO();
            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_CitasMedicas", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 5);
                cmd.Parameters.AddWithValue("Param1", id);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                paciente.IdCita = reader.GetInt32(reader.GetOrdinal("idCita"));
                                paciente.IdPaciente = reader.GetInt32(reader.GetOrdinal("IdPaciente"));
                                paciente.NombrePaciente = reader.GetString(reader.GetOrdinal("nombrePaciente"));
                                paciente.IdMedico = reader.GetInt32(reader.GetOrdinal("idMedico"));
                                paciente.IdConsulta = reader.GetInt32(reader.GetOrdinal("idConsulta"));
                                paciente.FechaCita = DateTime.Parse(reader.GetString(reader.GetOrdinal("fechaCita")));
                                paciente.HoraCita = DateTime.Parse(reader.GetString(reader.GetOrdinal("horaCita")));                                
                                paciente.FechaNuevaCita = reader.IsDBNull(reader.GetOrdinal("fechaNuevaCita")) ? DateTime.MinValue : DateTime.Parse(reader.GetString(reader.GetOrdinal("fechaNuevaCita")));
                                paciente.Comentario = reader.GetString(reader.GetOrdinal("comentario"));
                                paciente.IdEstado = reader.GetInt32(reader.GetOrdinal("idEstado"));
                            }
                        }
                    }
                }
                finally { connection.Close(); }
                return paciente;
            }
        }

        [HttpPost]
        [Route("api/CitasAPI/UpdateCita")]
        public Models.RespuestaDTO UpdateCita(Models.CitasDTO value)
        {
            var respuesta = new Models.RespuestaDTO();

            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_CitasMedicas", connection))
            {                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 6);
                cmd.Parameters.AddWithValue("param1", value.IdCita);
                cmd.Parameters.AddWithValue("param2", value.IdMedico);
                cmd.Parameters.AddWithValue("param3", value.IdConsulta);
                cmd.Parameters.AddWithValue("param4", value.FechaFinalizacion);
                cmd.Parameters.AddWithValue("param5", value.HoraCita);
                cmd.Parameters.AddWithValue("param6", value.FechaNuevaCita);
                cmd.Parameters.AddWithValue("param7", value.Comentario);
                cmd.Parameters.AddWithValue("param8", value.FechaModificacion);
                cmd.Parameters.AddWithValue("param9", value.IdEstado);

                int a = 0;
                try
                {
                    connection.Open();
                    try
                    {
                        a = cmd.ExecuteNonQuery();
                        respuesta.Resultado = true;
                        respuesta.Mensaje = (a == 0) ? "No se pudo registrar la cita" : "Actualizacion exitosa";
                    }
                    catch (Exception ex)
                    {
                        respuesta.Mensaje += "Error " + ex.Message;
                    }
                }
                finally { connection.Close(); }
            }
            return respuesta;
        }

    }
}
