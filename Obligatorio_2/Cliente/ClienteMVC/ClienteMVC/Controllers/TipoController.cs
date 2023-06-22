
using ClienteMVC.DTOs;
using ClienteMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        //-------------------------------------------------------------------------------------
        //FUNCIONES AUXILIARES-----------------------------------------------------------------------------

        private TipoViewModel FindTipoById(int id)
        {
            HttpClient cliente = new HttpClient();
            string url = URLBaseApiTipos + id;
            //cliente.DefaultRequestHeaders.Authorization =
            //    new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var tarea = cliente.GetAsync(url);
            tarea.Wait();
            string body = LeerContenido(tarea.Result);

            if (tarea.Result.IsSuccessStatusCode)
            {
                TipoViewModel tipo = JsonConvert.DeserializeObject<TipoViewModel>(body);
                return tipo;
            }
            else
            {
                throw new Exception(body);
            }
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
            HttpClient cliente = new HttpClient();
            string url = URLBaseApiTipos;
            Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
            tarea1.Wait();
            HttpResponseMessage respuesta = tarea1.Result;
            string body = LeerContenido(respuesta);


            if (respuesta.IsSuccessStatusCode)
            {
                List<TipoViewModel> tipos = JsonConvert.DeserializeObject<List<TipoViewModel>>(body);
                return View(tipos);
            }
            else
            {
                ViewBag.Error = body;
                return View(new List<TipoViewModel>());
            }
        }

        
        //-------------------------------------------------------------------------------------
        //BÚSQUEDA-----------------------------------------------------------------------------
        [HttpPost]
        public ActionResult Index(string nombre)
        {
            //if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            //{
            //    return Redirect("/Usuario/Login");
            //}
            HttpClient cliente = new HttpClient(); 
            string url = URLBaseApiTipos + "FindByNombre/" + nombre;
            Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
            tarea1.Wait();
            HttpResponseMessage respuesta = tarea1.Result;
            string body = LeerContenido(respuesta);

            if (respuesta.IsSuccessStatusCode)
            {
                TipoViewModel tipo = JsonConvert.DeserializeObject<TipoViewModel>(body);
                return View("ResultadoBusqueda", tipo);
            }
            else 
            {
                ViewBag.NotFound = body;
                return View("ResultadoBusqueda");
            }
            
        }

       

        //-------------------------------------------------------------------------------------
        //DETALLES-----------------------------------------------------------------------------
        public ActionResult Details(int id)
        {

            try
            {
                TipoViewModel vm = FindTipoById(id);
                return View(vm);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        //-------------------------------------------------------------------------------------
        //CREAR-----------------------------------------------------------------------------
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("logeado") != "registrado") return RedirectToAction("login", "usuario");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoViewModel tipo)
        {
          
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient cliente = new HttpClient();
                    cliente.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                    Task<HttpResponseMessage> tarea = cliente.PostAsJsonAsync(URLBaseApiTipos, tipo);
                    tarea.Wait();
                    HttpResponseMessage respuesta = tarea.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {

                        ViewBag.Mensaje = LeerContenido(respuesta);
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Los datos ingresados no son válidos";
                }

                return View(tipo);

            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Oops! Ocurrió un error inesperado:" + ex.Message;
                return View(tipo);
            }
        }

        //-------------------------------------------------------------------------------------
        //EDITAR-----------------------------------------------------------------------------
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("logeado") != "registrado")
            {
                return RedirectToAction("login", "usuario");
            }
                

            try
            {
                TipoViewModel vm = FindTipoById(id);
                return View(vm);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoViewModel tipo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string url = URLBaseApiTipos + tipo.Id;
                    HttpClient cliente = new HttpClient();
                    cliente.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                    Task<HttpResponseMessage> tarea = cliente.PutAsJsonAsync(url, tipo);
                    tarea.Wait();
                    HttpResponseMessage respuesta = tarea.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    //else
                    //{
                    //    if (respuesta.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                    //        respuesta.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    //    {
                    //        return RedirectToAction("Login", "Usuarios");
                    //    }
                    //    else
                    //    {
                    //        ViewBag.Mensaje = LeerContenido(respuesta);
                    //    }
                    //}
                }
                else
                {
                    ViewBag.Error = "Los datos ingresados no son válidos";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(tipo);
            }

            return View(tipo);
        }

        //-------------------------------------------------------------------------------------
        //DELETE-----------------------------------------------------------------------------
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("logeado") != "registrado") return RedirectToAction("login", "usuario");
            try
            {
                TipoViewModel vm = FindTipoById(id);
                return View(vm);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
         
            try
            {
                HttpClient cliente = new HttpClient();
                string url = URLBaseApiTipos + id;
                TipoViewModel vm = FindTipoById(id);
                cliente.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                var tarea = cliente.DeleteAsync(url);
                tarea.Wait();

                

                HttpResponseMessage respuesta = tarea.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = LeerContenido(respuesta);
                    return View(vm);
                }
            }
            catch
            {
                ViewBag.Error = "No se pudo eliminar el tema";
                return View();
            }
        }
        
    }
}
