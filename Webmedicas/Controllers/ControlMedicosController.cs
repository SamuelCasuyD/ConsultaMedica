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
                    ViewBag.Pacientes = Clist;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return View();
        }
    }
}