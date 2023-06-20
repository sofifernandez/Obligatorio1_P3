
using ClienteMVC.DTOs;
using ClienteMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ClienteMVC.Controllers
{
    public class TipoController : Controller
    {
        public IConfiguration Conf { get; set; }
        public string URLBaseApiTipos { get; set; }

        public TipoController(IConfiguration conf)
        {
            Conf = conf;
            URLBaseApiTipos = Conf.GetValue<string>("ApiTipos");
        }

        private string LeerContenido(HttpResponseMessage respuesta)
        {
            HttpContent contenido = respuesta.Content;
            Task<string> tarea2 = contenido.ReadAsStringAsync();
            tarea2.Wait();
            return tarea2.Result;
        }

        //-------------------------------------------------------------------------------------
        //LISTADO-----------------------------------------------------------------------------
        public ActionResult Index()
        {
            //if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            //{
            //    return Redirect("/Usuario/Login");
            //}


            HttpClient cliente = new HttpClient();
            string url = URLBaseApiTipos;
            Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
            tarea1.Wait();
            HttpResponseMessage respuesta = tarea1.Result;
            string body = LeerContenido(respuesta);


            if (respuesta.IsSuccessStatusCode)
            {
                List<TipoViewModel> cabanas = JsonConvert.DeserializeObject<List<TipoViewModel>>(body);
                return View(cabanas);
            }
            else
            {
                ViewBag.Error = body;
                return View(new List<TipoViewModel>());
            }
        }

        /*
        //-------------------------------------------------------------------------------------
        //BÚSQUEDA-----------------------------------------------------------------------------
        [HttpPost]
        public ActionResult Index(string nombre)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            Tipo tipo = RepositorioTipo.FindTipoByNombre(nombre);
           
            if (tipo == null)
            {
                ViewBag.Error = "No existe un tipo de cabaña con ese nombre";
                return View("ResultadoBusqueda");
            }
            else 
            {
                return View("ResultadoBusqueda", tipo);
            }
            
        }

       

        //-------------------------------------------------------------------------------------
        //DETALLES-----------------------------------------------------------------------------
        public ActionResult Details(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            Tipo tipo= RepositorioTipo.FindById(id);
            return View(tipo);
        }

        //-------------------------------------------------------------------------------------
        //CREAR-----------------------------------------------------------------------------
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tipo tipo)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            try
            {
                AltaTipo.Alta(tipo);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.ErrorInfo = ex.Message;
                return View();
            }
        }

        //-------------------------------------------------------------------------------------
        //EDITAR-----------------------------------------------------------------------------
        public ActionResult Edit(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            Tipo tipo = RepositorioTipo.FindById(id);
            return View(tipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tipo tipo)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            try
            {

                EditarTipo.Editar(tipo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorInfo = ex.Message;
                return View();
            }
        }

        //-------------------------------------------------------------------------------------
        //DELETE-----------------------------------------------------------------------------
        public ActionResult Delete(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            Tipo tipo=RepositorioTipo.FindById(id);
            return View(tipo);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            try
            {
                RepositorioTipo.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch  (Exception ex)
            {
                Tipo tipo = RepositorioTipo.FindById(id);
                ViewBag.ErrorInfo = ex.Message;
                return View(tipo);
            }
        }
        */
    }
}
