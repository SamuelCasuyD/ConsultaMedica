using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                                BD.NombreMedico = reader.GetString(reader.GetOrdinal("NombreMedico"));
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

    }
}
