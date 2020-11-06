using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Webmedicas.Controllers
{
    public class ControlPacienteController : Controller
    {

        /// <summary>
        /// LISTA DE PACIENTES CREADOS
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListPacientes(string k)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62699/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var Clist = client
                       .GetAsync("api/PacientesAPI/GetDataPaciente/")
                       .Result
                       .Content.ReadAsAsync<IList<Models.PacienteDTO>>().Result;
                    ViewBag.Pacientes = Clist;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public ActionResult CrearPaciente(string k)
        {
            return View();
        }

        /// <summary>
        /// CREAR PACIENTE 
        /// </summary>
        /// <param name="frm">DATOS OBTENIDOS DEL FORMULARIO</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CrearControlPaciente(FormCollection frm)
        {
            var ControlPaciente = new Models.PacienteDTO();
            var respuesta = new Models.RespuestaDTO();

            ControlPaciente.NombrePaciente = frm["NombrePaciente"];
            ControlPaciente.FechaNacimiento = DateTime.Parse(frm["FechaNacimiento"]);
            ControlPaciente.Sexo = frm["Sexo"];
            ControlPaciente.DPI = frm["DPI"];
            Session["DataPaciente"] = ControlPaciente;

            if (Request.Form["Crear"] != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62699/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        respuesta = client.PostAsJsonAsync("api/PacientesAPI/PutUpdatePaciente", ControlPaciente)
                              .Result
                              .Content.ReadAsAsync<Models.RespuestaDTO>().Result;
                    }
                    catch (Exception ex)
                    {
                        respuesta.Mensaje += ex.Message.ToString();
                    }
                    if (respuesta.Resultado)
                    {
                        Session.Remove("DataPaciente");
                        TempData["Confirm"] = "Si";
                        TempData["Mensaje"] = respuesta.Mensaje;
                        return RedirectToAction("ListPacientes", "ControlPaciente");
                    }
                    else
                    {
                        TempData["Error"] = "Si";
                        TempData["Mensaje"] = respuesta.Mensaje;
                    }
                    return RedirectToAction("ListPacientes", "ControlPaciente");
                }
            }
            return View();
        }

        /// <summary>
        /// OBTIENE LOS DATOS DEL PACIENTE A MODIFICAR
        /// </summary>
        /// <param name="id">IDPACIENTE</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditarPaciente(string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62699/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var Paciente = client
                       .GetAsync("api/PacientesAPI/PacientesporID/" + id + "/")
                       .Result
                       .Content.ReadAsAsync<Models.PacienteDTO>().Result;
                    ViewBag.Paciente = Paciente;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return View();
        }

        /// <summary>
        /// ACTUALIZA LOS DATOS DEL PACIENTE
        /// </summary>
        /// <param name="act">LLEVA LA COLECCION DE DATOS </param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ActualizarPaciente(string act)
        {
            var NewObject = JsonConvert.DeserializeObject<Models.PacienteDTO>(act);
            var Respuesta = new Models.RespuestaDTO();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62699/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        Respuesta = client.PostAsJsonAsync("api/PacientesAPI/UpdatePaciente", NewObject)
                              .Result
                              .Content.ReadAsAsync<Models.RespuestaDTO>().Result;
                    }
                    catch (Exception ex)
                    {
                        Respuesta.Mensaje += ex.Message.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Respuesta.Mensaje = ex.Message;
            }
            return Json(Respuesta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// CAMBIA EL ESTADO DE ACTIVO A INACTIVO 
        /// </summary>
        /// <param name="id">IDPACIENTE</param>
        /// <returns></returns>
        public ActionResult InactivarPaciente(string id)
        {
            try
            {
                var respuesta = new Models.RespuestaDTO();
                var paciente = new Models.PacienteDTO();
                paciente.IdPaciente = int.Parse(id);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62699/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        respuesta = client.PostAsJsonAsync("api/PacientesAPI/InactivarPaciente", paciente)
                              .Result
                              .Content.ReadAsAsync<Models.RespuestaDTO>().Result;
                    }
                    catch (Exception ex)
                    {
                        respuesta.Mensaje += ex.Message.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return RedirectToAction("ListPacientes", "ControlPaciente");
        }


        public ActionResult ShowAddAnexo(int id)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62699/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var anexos = client
                       .GetAsync("api/PacientesAPI/AnexosPorId/" + id + "/")
                       .Result
                       .Content.ReadAsAsync<IList<Models.AnexoDTO>>().Result;
                    ViewBag.Anexos = anexos;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }


            ViewBag.IdPaciente = id;
            return View();
        }


        [HttpPost]
        public ActionResult AgregarAnexo(FormCollection frm)
        {
            var _pathnombre = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.ToString("Hmmss");

            var respuesta = new Models.RespuestaDTO();
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase uploadedFile = Request.Files["fileatached"];
                if (!String.IsNullOrEmpty(uploadedFile.FileName))
                {
                    var FileUpload = new Models.AnexoDTO();
                    var IdPaciente = int.Parse(frm["IdPaciente"]);
                    FileUpload.IdPaciente = IdPaciente;


                    if (uploadedFile != null && uploadedFile.ContentLength > 0)
                    {

                        var newAttchment = new Models.AnexoDTO();
                        byte[] FileByteArray = new byte[uploadedFile.ContentLength];
                        uploadedFile.InputStream.Read(FileByteArray, 0, uploadedFile.ContentLength);


                        newAttchment.IdPaciente = FileUpload.IdPaciente;
                        //newAttchment.FileName = uploadedFile.FileName;
                        newAttchment.NombreArchivo = "-ANEXO-" + _pathnombre + Path.GetExtension(uploadedFile.FileName);
                        newAttchment.Extencion = Path.GetExtension(uploadedFile.FileName);
                        newAttchment.ContentArray = FileByteArray;
                        newAttchment.ContentLength = uploadedFile.ContentLength;


                        //Forma 1 
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri("http://localhost:62699/");
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            try
                            {
                                respuesta = client.PostAsJsonAsync("api/PacientesAPI/AgregarAnexo", newAttchment).Result.Content.ReadAsAsync<Models.RespuestaDTO>().Result;
                            }
                            catch (Exception e)
                            {
                                respuesta.Mensaje = e.Message;
                            }
                        }
                    }
                    else
                    {
                        respuesta.Mensaje = "Tamaño de archivo inválido";
                    }
                }
                else
                {
                    respuesta.Mensaje = "Nombre de archivo vacio";
                }
            }
            else
            {
                respuesta.Mensaje = "No existe un documento de adjunto";
            }
            if (respuesta.Resultado)
            {
                TempData["Confirm"] = "Si";
            }
            else
            {
                TempData["Error"] = "Si";
            }
            TempData["Mensaje"] = respuesta.Mensaje;
            return Redirect(Request.UrlReferrer.ToString());
        }



    }
}