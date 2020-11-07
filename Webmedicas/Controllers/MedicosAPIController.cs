using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace Webmedicas.Controllers
{
    public class MedicosAPIController : ApiController
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
        /// OBTIENE LA LISTA MEDICOS
        /// </summary>
        /// <returns></returns>
        public IList<Models.MedicoDTO> GetDataMedicos()
        {
            IList<Models.MedicoDTO> Medicos = new List<Models.MedicoDTO>();

            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_DatosMedicos", connection))
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
                                Models.MedicoDTO BD = new Models.MedicoDTO();
                                BD.IdMedico = reader.GetInt32(reader.GetOrdinal("idMedico"));
                                BD.NombreMedico = reader.GetString(reader.GetOrdinal("nombreMedico"));
                                BD.Colegiado = reader.GetString(reader.GetOrdinal("Colegiado"));
                                BD.Especialidad = reader.GetString(reader.GetOrdinal("Especialidad"));
                                BD.Sexo = reader.GetString(reader.GetOrdinal("sexo"));
                                BD.FechaNacimiento = DateTime.Parse( reader.GetString(reader.GetOrdinal("fechaNacimiento")));
                                Medicos.Add(BD);
                            }
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
                return Medicos;
            }
        }

        /// <summary>
        /// CREAR MEDICO
        /// </summary>
        /// <param name="value">LLEVA LOS DATOS OBTENIDOS DEL CONTROLADOR POR MEDIO DE LA VISTA</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/MedicosAPI/CrearRegistroMedico")]
        public Models.RespuestaDTO CrearRegistroMedico(Models.MedicoDTO value)
        {
            var respuesta = new Models.RespuestaDTO();

            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_DatosMedicos", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 2);
                cmd.Parameters.AddWithValue("param1", value.NombreMedico);
                cmd.Parameters.AddWithValue("param2", value.Colegiado);
                cmd.Parameters.AddWithValue("param3", value.Especialidad);
                cmd.Parameters.AddWithValue("param4", value.Sexo);
                cmd.Parameters.AddWithValue("param5", value.FechaNacimiento);
                cmd.Parameters.AddWithValue("param6", value.FechaCreacion);

                int a = 0;
                try
                {
                    connection.Open();
                    try
                    {
                        a = cmd.ExecuteNonQuery();
                        respuesta.Resultado = true;
                        respuesta.Mensaje = (a == 0) ? "No se pudo crear el Medico" : "Crecion exitosa";
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
        /// API OBTIENE LOS DATOS DEL MEDICOS
        /// </summary>
        /// <param name="id">IDMEDICOS</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/MedicosAPI/MedicoporID/{id}")]
        public Models.MedicoDTO MedicoporID(string id)
        {
            var Medico = new Models.MedicoDTO();
            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_DatosMedicos", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 3);
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
                                Medico.IdMedico = reader.GetInt32(reader.GetOrdinal("idMedico"));
                                Medico.NombreMedico = reader.GetString(reader.GetOrdinal("nombreMedico"));
                                Medico.Colegiado = reader.GetString(reader.GetOrdinal("Colegiado"));
                                Medico.Especialidad = reader.GetString(reader.GetOrdinal("Especialidad"));
                                Medico.Sexo = reader.GetString(reader.GetOrdinal("sexo"));
                                Medico.FechaNacimiento = DateTime.Parse(reader.GetString(reader.GetOrdinal("fechaNacimiento")));
                            }
                        }
                    }
                }
                finally { connection.Close(); }
                return Medico;
            }
        }

        /// <summary>
        /// ACTUALIUZAR DATOS POR ID MEDICOS
        /// </summary>
        /// <param name="value">ENVIA LA COLECCION DE DATOS</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/MedicosAPI/UpdateMedico")]
        public Models.RespuestaDTO UpdateMedico(Models.MedicoDTO value)
        {
            var respuesta = new Models.RespuestaDTO();

            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_DatosMedicos", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 4);                
                cmd.Parameters.AddWithValue("param1", value.IdMedico);
                cmd.Parameters.AddWithValue("param2", value.NombreMedico);
                cmd.Parameters.AddWithValue("param3", value.Colegiado);
                cmd.Parameters.AddWithValue("param4", value.Especialidad);
                cmd.Parameters.AddWithValue("param5", value.Sexo);
                cmd.Parameters.AddWithValue("param6", value.FechaNacimiento);                

                int a = 0;
                try
                {
                    connection.Open();
                    try
                    {
                        a = cmd.ExecuteNonQuery();
                        respuesta.Resultado = true;
                        respuesta.Mensaje = (a == 0) ? "No se pudo actualizar ningun registro" : "Autorizacion exitosa";
                    }
                    catch
                    {
                        respuesta.Mensaje = "No fue posible realizar la transaccion";
                    }
                }
                finally { connection.Close(); }
            }
            return respuesta;
        }

        /// <summary>
        /// INACTIVAR AL MEDICO
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/MedicosAPI/InactivarMedico")]
        public Models.RespuestaDTO InactivarMedico(Models.MedicoDTO value)
        {
            var respuesta = new Models.RespuestaDTO();

            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_DatosMedicos", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 5);
                cmd.Parameters.AddWithValue("param1", value.IdMedico);
                int a = 0;
                try
                {
                    connection.Open();
                    try
                    {
                        a = cmd.ExecuteNonQuery();
                        respuesta.Resultado = true;
                        respuesta.Mensaje = (a == 0) ? "No se pudo actualizar ningun registro" : "Autorizacion exitosa";
                    }
                    catch
                    {
                        respuesta.Mensaje = "No fue posible realizar la transaccion";
                    }
                }
                finally { connection.Close(); }
            }
            return respuesta;
        }

    }
}
