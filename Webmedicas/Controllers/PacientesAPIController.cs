using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Webmedicas.Controllers
{
    public class PacientesAPIController : ApiController
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
        /// API LISTAR PACIENTES
        /// </summary>
        /// <returns></returns>
        public IList<Models.PacienteDTO> GetDataPaciente()
        {
            IList<Models.PacienteDTO> BUSCARDOC = new List<Models.PacienteDTO>();

            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_DatosPacientes", connection))
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
                                Models.PacienteDTO BDOCA = new Models.PacienteDTO();
                                BDOCA.IdPaciente = reader.GetInt32(reader.GetOrdinal("IdPaciente"));
                                BDOCA.NombrePaciente = reader.GetString(reader.GetOrdinal("nombrePaciente"));
                                BDOCA.FechaNacimiento = DateTime.Parse(reader.GetString(reader.GetOrdinal("FechaNacimiento")));
                                BDOCA.Sexo = reader.GetString(reader.GetOrdinal("Sexo"));
                                BDOCA.DPI = reader.GetString(reader.GetOrdinal("DPI"));
                                BUSCARDOC.Add(BDOCA);
                            }
                        }
                    }
                }
                finally { connection.Close(); }
                return BUSCARDOC;
            }
        }

        /// <summary>
        /// CREAR PACIENTE
        /// </summary>
        /// <param name="value">LLEVA LOS DATOS OBTENIDOS DEL CONTROLADOR POR MEDIO DE LA VISTA</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/PacientesAPI/PutUpdatePaciente")]
        public Models.RespuestaDTO PutUpdatePaciente(Models.PacienteDTO value)
        {
            var respuesta = new Models.RespuestaDTO();

            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_DatosPacientes", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 2);
                cmd.Parameters.AddWithValue("param1", value.NombrePaciente);
                cmd.Parameters.AddWithValue("param2", value.FechaNacimiento);
                cmd.Parameters.AddWithValue("param3", value.Sexo);
                cmd.Parameters.AddWithValue("param4", value.DPI);

                int a = 0;
                try
                {
                    connection.Open();
                    try
                    {
                        a = cmd.ExecuteNonQuery();
                        respuesta.Resultado = true;
                        respuesta.Mensaje = (a == 0) ? "No se pudo crear el paciente" : "Crecion exitosa";
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
        /// ACTUALIUZAR DATOS POR ID PACIENTE
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/PacientesAPI/UpdatePaciente")]
        public Models.RespuestaDTO UpdatePaciente(Models.PacienteDTO value)
        {
            var respuesta = new Models.RespuestaDTO();

            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_DatosPacientes", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 3);
                cmd.Parameters.AddWithValue("param1", value.IdPaciente);
                cmd.Parameters.AddWithValue("param2", value.NombrePaciente);
                cmd.Parameters.AddWithValue("param3", value.FechaNacimiento);
                cmd.Parameters.AddWithValue("param4", value.Sexo);
                cmd.Parameters.AddWithValue("param5", value.DPI);

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
        /// API OBTIENE LOS DATOS DEL PACIENTE
        /// </summary>
        /// <param name="id">IDPACIENTE</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/PacientesAPI/PacientesporID/{id}")]
        public Models.PacienteDTO PacientesporID(string id)
        {
            var paciente = new Models.PacienteDTO();
            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_DatosPacientes", connection))
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

                                paciente.IdPaciente = reader.GetInt32(reader.GetOrdinal("IdPaciente"));
                                paciente.NombrePaciente = reader.GetString(reader.GetOrdinal("nombrePaciente"));
                                paciente.FechaNacimiento = DateTime.Parse(reader.GetString(reader.GetOrdinal("FechaNacimiento")));
                                paciente.Sexo = reader.GetString(reader.GetOrdinal("sexo"));
                                paciente.DPI = reader.GetString(reader.GetOrdinal("DPI"));
                            }
                        }
                    }
                }
                finally { connection.Close(); }
                return paciente;
            }
        }

        /// <summary>
        /// INACTIVAR AL PACIENTE
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/PacientesAPI/InactivarPaciente")]
        public Models.RespuestaDTO InactivarPaciente(Models.PacienteDTO value)
        {
            var respuesta = new Models.RespuestaDTO();

            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_DatosPacientes", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 5);
                cmd.Parameters.AddWithValue("param1", value.IdPaciente);
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
        /// CREAR REGISTRO DEL ANEXO ALMACENADO EN CARPETA MBConfig
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/PacientesAPI/AgregarAnexo")]
        public Models.RespuestaDTO AgregarAnexo(Models.AnexoDTO value)
        {
            var respuesta = new Models.RespuestaDTO();
            var ruta = @"C:\\MBConfig";
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            string FileName = value.NombreArchivo;
            //Agregar en Directorio
            string pathNewFile = System.IO.Path.Combine(ruta, System.IO.Path.GetFileName(FileName));
            File.WriteAllBytes(pathNewFile, value.ContentArray);

            ///ir a la base de datos a crear el registro
            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_DatosPacientes", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 6);
                cmd.Parameters.AddWithValue("param1", value.IdPaciente);
                cmd.Parameters.AddWithValue("param2", pathNewFile);
                cmd.Parameters.AddWithValue("param3", value.Extencion);
                cmd.Parameters.AddWithValue("param4", value.NombreArchivo);

                int a = 0;
                try
                {
                    connection.Open();
                    try
                    {
                        a = cmd.ExecuteNonQuery();
                        respuesta.Resultado = true;
                        respuesta.Mensaje = (a == 0) ? "No se pudo crear el paciente" : "Crecion exitosa";
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
        /// LISTAR REGISTORS DE LA TABLA ANEXOS
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/PacientesAPI/AnexosPorId/{id}")]
        public IList<Models.AnexoDTO> AnexosPorId(string id)
        {
            var Anexos = new List<Models.AnexoDTO>();
            using (SqlConnection connection = new SqlConnection(cnString()))
            using (SqlCommand cmd = new SqlCommand("SP_DatosPacientes", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NumConsulta", 7);
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
                                var anexo = new Models.AnexoDTO();
                                anexo.idAnexo = reader.GetInt32(reader.GetOrdinal("idAnexo"));
                                anexo.IdPaciente = reader.GetInt32(reader.GetOrdinal("IdPaciente"));
                                anexo.NombreArchivo = reader.GetString(reader.GetOrdinal("NombreArchivo"));
                                anexo.FechaCreacion = DateTime.Parse(reader.GetString(reader.GetOrdinal("FechaCreacion")));
                                anexo.Extencion = reader.GetString(reader.GetOrdinal("Extencion"));
                                anexo.ruta = reader.GetString(reader.GetOrdinal("ruta"));
                                anexo.ruta = reader.GetString(reader.GetOrdinal("ruta"));
                                Anexos.Add(anexo);
                            }
                        }
                    }
                }
                finally { connection.Close(); }                
            }
            return Anexos;
        }

    }
}
