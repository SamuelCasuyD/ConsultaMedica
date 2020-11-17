using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Webmedicas.Controllers
{
    public class CitasMedicasController : Controller
    {
        // GET: CitasMedicas
        [HttpGet]
        public ActionResult CrearCitas(string id)
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

                var Estados = client
                    .GetAsync("api/CitasAPI/GetEstados/")
                    .Result
                    .Content.ReadAsAsync<IList<Models.CitasDTO>>().Result;
                ViewBag.Estado = Estados;

                var consulta = client
                    .GetAsync("api/CitasAPI/GetTipoConsulta/")
                    .Result
                    .Content.ReadAsAsync<IList<Models.CitasDTO>>().Result;
                ViewBag.Consulta = consulta;

                var Clist = client
                    .GetAsync("api/MedicosAPI/GetDataMedicos/")
                    .Result
                    .Content.ReadAsAsync<IList<Models.MedicoDTO>>().Result;
                ViewBag.Medicos = Clist;
            }
            return View();
        }

        /// <summary>
        /// CREAR CITAS MEDICAS
        /// </summary>
        /// <param name="frm"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CrearCitas(FormCollection frm)
        {
            var Consultas = new Models.PacienteDTO();
            var respuesta = new Models.RespuestaDTO();

            Consultas.IdPaciente = int.Parse(frm["IdPaciente"]);
            Consultas.IdMedico = int.Parse(frm["IdMedico"]);
            Consultas.HoraCita = DateTime.Parse(frm["HoraCita"]);
            Consultas.FechaCita = DateTime.Parse(frm["FechaCita"]);
            Consultas.IdConsulta = int.Parse(frm["IdConsulta"]);
            Consultas.IdEstado = int.Parse(frm["IdEstado"]);
            //Consultas.FechaFinalizacion = DateTime.Parse(frm["FechaFinalizacion"]);
            //Consultas.FechaNuevaCita = DateTime.Parse(frm["FechaNuevaCita"]);
            Consultas.Comentario = frm["Comentario"];
            Consultas.FechaCreacion = DateTime.Now;
            Consultas.Eliminado = false;

            Session["DataCrearConsulta"] = Consultas;

            if (Request.Form["Crear"] != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62699/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        respuesta = client.PostAsJsonAsync("api/CitasAPI/CrearCitasPacientes", Consultas)
                              .Result
                              .Content.ReadAsAsync<Models.RespuestaDTO>().Result;
                    }
                    catch (Exception ex)
                    {
                        respuesta.Mensaje += ex.Message.ToString();
                    }
                    if (respuesta.Resultado)
                    {
                        Session.Remove("DataCrearConsulta");
                        TempData["Confirm"] = "Si";
                        TempData["Mensaje"] = respuesta.Mensaje;
                        return RedirectToAction("ListPacientes", "ControlPaciente");
                    }
                    else
                    {
                        TempData["Error"] = "Si";
                        TempData["Mensaje"] = respuesta.Mensaje;
                        return Redirect(Request.UrlReferrer.ToString());
                    }
                }
            }
            return View();
        }

        /// <summary>
        /// OBTIENE LA LISTA DE LOS PACIENTES POR MEDIO DEL IDMEDICO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListCitasPorMedico(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62699/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var Citas = client
                   .GetAsync("api/CitasAPI/ObtenerListaCitas/" + id + "/")
                   .Result
                   .Content.ReadAsAsync<IList<Models.CitasDTO>>().Result;
                ViewBag.ListCita = Citas;
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditarCitaPciente(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62699/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var DetalleCita = client
                   .GetAsync("api/CitasAPI/GetDetalleCita/" + id + "/")
                   .Result
                   .Content.ReadAsAsync<Models.CitasDTO>().Result;
                ViewBag.Detalle = DetalleCita;

                var Estados = client
                    .GetAsync("api/CitasAPI/GetEstados/")
                    .Result
                    .Content.ReadAsAsync<IList<Models.CitasDTO>>().Result;
                Session["Estados"] = Estados;

                var consulta = client
                    .GetAsync("api/CitasAPI/GetTipoConsulta/")
                    .Result
                    .Content.ReadAsAsync<IList<Models.CitasDTO>>().Result;
                Session["consulta"] = consulta;
            }
            return View();
        }

        [HttpPost]
        public JsonResult UpdateDetalleCita(string act)
        {
            var NewObject = JsonConvert.DeserializeObject<Models.CitasDTO>(act);
            var Respuesta = new Models.RespuestaDTO();
            NewObject.FechaModificacion = DateTime.Now;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62699/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        Respuesta = client.PostAsJsonAsync("api/CitasAPI/UpdateCita", NewObject)
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
            if (Respuesta.Resultado)
            {
                TempData["Confirm"] = "Si";
                TempData["Mensaje"] = Respuesta.Mensaje;
                return Json(Respuesta, JsonRequestBehavior.AllowGet);
            }
            else
            {
                TempData["Error"] = "Si";
                TempData["Mensaje"] = Respuesta.Mensaje;
                return Json(Respuesta, JsonRequestBehavior.AllowGet);
            }            
        }

    }
}