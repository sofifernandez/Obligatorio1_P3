
using ClienteMVC.DTOs;
using ClienteMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClienteMVC.Controllers
{
    public class MantenimientoController : Controller
    {

        public IConfiguration Conf { get; set; }
        public string URLBaseApiMantenimientos { get; set; }
        public string URLBaseApiCabanas { get; set; }

        public MantenimientoController(IConfiguration conf)
        {
            Conf = conf;
            URLBaseApiMantenimientos = Conf.GetValue<string>("ApiMantenimientos");
            URLBaseApiCabanas= Conf.GetValue<string>("ApiCabanas");
        }

        //-------------------------------------------------------------------------------------
        //FUNCIONES AUXILIARES-----------------------------------------------------------------------------
        private string LeerContenido(HttpResponseMessage respuesta)
        {
            HttpContent contenido = respuesta.Content;
            Task<string> tarea2 = contenido.ReadAsStringAsync();
            tarea2.Wait();
            return tarea2.Result;
        }

        private CabanaDTO TraerInfoCabana(int idCabana)
        {
            HttpClient cliente = new HttpClient();
            string url = URLBaseApiCabanas + idCabana;
            //cliente.DefaultRequestHeaders.Authorization =
            //    new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var tarea = cliente.GetAsync(url);
            tarea.Wait();
            string cuerpo = LeerContenido(tarea.Result);

            if (tarea.Result.IsSuccessStatusCode)
            {
                CabanaDTO cabana = JsonConvert.DeserializeObject<CabanaDTO>(cuerpo);
                return cabana;
            }
            else
            {
                throw new Exception(cuerpo);
            }
        }

        //-------------------------------------------------------------------------------------
        //LISTADO-----------------------------------------------------------------------------
        public ActionResult Index(int CabanaId)
        {
           
            HttpClient cliente = new HttpClient();
            string url = URLBaseApiMantenimientos + CabanaId;
            Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
            tarea1.Wait();
            HttpResponseMessage respuesta = tarea1.Result;
            string body = LeerContenido(respuesta);

            CabanaDTO cabana = TraerInfoCabana(CabanaId);

            if (respuesta.IsSuccessStatusCode)
            {
                List<MantenimientoViewModel> mantenimientos = JsonConvert.DeserializeObject<List<MantenimientoViewModel>>(body);
                ViewBag.Cabana = cabana;
                return View(mantenimientos);
            }
            else
            {
                //List<MantenimientoViewModel> mantenimientos = JsonConvert.DeserializeObject<List<MantenimientoViewModel>>(body);
                ViewBag.Cabana = cabana;
                ViewBag.NotFound = body;
                return View(new List<MantenimientoViewModel>());
            }
        }


        //-------------------------------------------------------------------------------------
        //BÚSQUEDA-----------------------------------------------------------------------------
        [HttpPost]
        public ActionResult MantEntreFechas(DateTime fechaIni, DateTime fechaFin, int CabanaId)
        {
        
            HttpClient cliente = new HttpClient();
            string url = URLBaseApiMantenimientos + $"start/{fechaIni.ToShortDateString()}/end/{fechaFin.ToShortDateString()}/Cabana/{CabanaId}";
            Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
            tarea1.Wait();
            HttpResponseMessage respuesta = tarea1.Result;
            string body = LeerContenido(respuesta);
            
            CabanaDTO cabana = TraerInfoCabana(CabanaId);

            if (respuesta.IsSuccessStatusCode)
            {
                List<MantenimientoViewModel> mantens = JsonConvert.DeserializeObject<List<MantenimientoViewModel>>(body);
                ViewBag.Cabana=cabana;
                return View(mantens);
            }
            else 
            {
                ViewBag.Cabana = cabana;
                ViewBag.NotFound = body;
                return View(new List<MantenimientoViewModel>());
            }
  
        }
        [HttpGet]
        public ActionResult BuscarMantPorCapacidad()
        {
            return View(new List<MantenimientoCapacidadViewModel>());
        }

        [HttpPost]
        public ActionResult BuscarMantPorCapacidad(int desde, int hasta)
        {

            HttpClient client = new HttpClient();
            string url = URLBaseApiMantenimientos + $"TotalPorCapacidad/{desde}/{hasta}";
            var tarea = client.GetAsync(url);
            tarea.Wait();
            string body = LeerContenido(tarea.Result);

            if (tarea.Result.IsSuccessStatusCode)
            {
                List<MantenimientoCapacidadViewModel> mantenimientos = JsonConvert.DeserializeObject<List<MantenimientoCapacidadViewModel>>(body);
                return View(mantenimientos);
            }
            else
            {
                ViewBag.NotFound = body;
                return View(new List<MantenimientoCapacidadViewModel>());
            }
        }



        //-------------------------------------------------------------------------------------
        //CREAR-----------------------------------------------------------------------------
        public ActionResult Create(int CabanaId)
        {
            if (HttpContext.Session.GetString("logeado") != "registrado") return RedirectToAction("login", "usuario");
            CabanaDTO cabana = TraerInfoCabana(CabanaId);
            ViewBag.Cabana=cabana;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MantenimientoViewModel mantenimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient cliente = new HttpClient();
                    cliente.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                    Task<HttpResponseMessage> tarea = cliente.PostAsJsonAsync(URLBaseApiMantenimientos, mantenimiento);
                    tarea.Wait();
                    HttpResponseMessage respuesta = tarea.Result;
                    CabanaDTO cabana = TraerInfoCabana(mantenimiento.CabanaId);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        
                        ViewBag.Cabana=cabana;
                        return RedirectToAction(nameof(Index), new { CabanaId = cabana.Id });
                    }
                    else
                    {
                        ViewBag.Cabana = cabana;
                        ViewBag.Error = LeerContenido(respuesta);
                    }
                }
                else
                {
                    //ViewBag.Cabana = cabana;
                    ViewBag.Error = "Los datos ingresados no son válidos";
                }

                return View(mantenimiento);

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Oops! Ocurrió un error inesperado:" + ex.Message;
                return View(mantenimiento);
            }




        }





        //-----------------------------------------------------------------------------------------------------------------------------------
        //NO IMPLEMENTADOS--------------------------------------------------------------------------------------------------------------------

        // GET: MantenimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MantenimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MantenimientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
    }
}
