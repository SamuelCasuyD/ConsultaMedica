using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Webmedicas.Controllers
{
    public class ControlMedicosController : Controller
    {

        [HttpGet]
        public ActionResult ListMedicos(string k)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62699/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var Clist = client
                       .GetAsync("api/MedicosAPI/GetDataMedicos/")
                       .Result
                       .Content.ReadAsAsync<IList<Models.MedicoDTO>>().Result;
                    ViewBag.Medicos = Clist;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return View();
        }

        /// <summary>
        /// CREAR MEDICO 
        /// </summary>
        /// <param name="frm">DATOS OBTENIDOS DEL FORMULARIO</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CrearRegistroMedico(FormCollection frm)
        {
            var Rmedicos = new Models.MedicoDTO();
            var respuesta = new Models.RespuestaDTO();

            Rmedicos.NombreMedico = frm["NombreMedico"];
            Rmedicos.Colegiado = frm["Colegiado"];
            Rmedicos.Especialidad = frm["Especialidad"];
            Rmedicos.Sexo = frm["Sexo"];
            Rmedicos.FechaNacimiento = DateTime.Parse(frm["FechaNacimiento"]);
            Rmedicos.FechaCreacion = DateTime.Now;            
            Session["DataMedicos"] = Rmedicos;

            if (Request.Form["Crear"] != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62699/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        respuesta = client.PostAsJsonAsync("api/MedicosAPI/CrearRegistroMedico", Rmedicos)
                              .Result
                              .Content.ReadAsAsync<Models.RespuestaDTO>().Result;
                    }
                    catch (Exception ex)
                    {
                        respuesta.Mensaje += ex.Message.ToString();
                    }
                    if (respuesta.Resultado)
                    {
                        Session.Remove("DataMedicos");
                        TempData["Confirm"] = "Si";
                        TempData["Mensaje"] = respuesta.Mensaje;
                        return RedirectToAction("ListMedicos", "ControlMedicos");
                    }
                    else
                    {
                        TempData["Error"] = "Si";
                        TempData["Mensaje"] = respuesta.Mensaje;
                    }
                    return RedirectToAction("ListMedicos", "ControlMedicos");
                }
            }
            return View();
        }

        /// <summary>
        /// OBTIENE LOS DATOS DEL MEDICOS A MODIFICAR
        /// </summary>
        /// <param name="id">IDPACIENTE</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditarMedico(string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62699/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var m = client
                       .GetAsync("api/MedicosAPI/MedicoporID/" + id + "/")
                       .Result
                       .Content.ReadAsAsync<Models.MedicoDTO>().Result;
                    ViewBag.Medico = m;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return View();
        }

        /// <summary>
        /// ACTUALIZA LOS DATOS DEL MEDICO
        /// </summary>
        /// <param name="act">LLEVA LA COLECCION DE DATOS </param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ActualizarMedico(string act)
        {
            var NewObject = JsonConvert.DeserializeObject<Models.MedicoDTO>(act);
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
                        Respuesta = client.PostAsJsonAsync("api/MedicosAPI/UpdateMedico", NewObject)
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
        /// <param name="id">IDMEDICO</param>
        /// <returns></returns>
        public ActionResult InactivarMedico(string id)
        {
            try
            {
                var respuesta = new Models.RespuestaDTO();
                var medico = new Models.MedicoDTO();
                medico.IdMedico = int.Parse(id);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62699/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        respuesta = client.PostAsJsonAsync("api/MedicosAPI/InactivarMedico", medico)
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
            return RedirectToAction("ListMedicos", "ControlMedicoS");
        }

    }
}