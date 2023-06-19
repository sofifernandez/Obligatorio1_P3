using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using ClienteMVC.Models;
using ClienteMVC.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class CabanaController : Controller 
    {
        public IWebHostEnvironment WHE { set; get; }

        public string URLBaseApiCabanas { get; set; }
        public string URLBaseApiTipos { get; set; }

        public CabanaController(IConfiguration conf, IWebHostEnvironment whe)
        {
            URLBaseApiCabanas = conf.GetValue<string>("ApiCabanas");
            URLBaseApiTipos = conf.GetValue<string>("ApiTipos");
            WHE = whe;
        }

        /*
       
        HttpClient
        
                    .GetAsync (url:String) : Task<HttpResponseMessage>
                    .DeleteAsync (url:String) : Task<HttpResponseMessage>
                    .PostAsJsonAsync (url:String, obj:Object) : Task<HttpResponseMessage>
                    .PutAsJsonAsync (url:String, obj:Object) : Task<HttpResponseMessage>

        Task<T>     .Wait()
                    .Result: T

        HttpResponseMessage
                            .IsSuccessSatusCode: bool
                            .Content: HttpContent

        HttpContent
                    .ReadAsStringAsync() : Task<String> --> aca el json o el mensaje de error (no se deserializa)

        JsonConvert
                    .DesearializeObject<T>(json:string):T


        */




        //-------------------------------------------------------------------------------------
        //FUNCIONES ACCESORIAS-----------------------------------------------------------------------------

        private string FetchCabana(int id, out CabanaViewModel cabana)
        {
            string error = "";
            cabana = null;

            HttpClient client = new HttpClient();
            string urlBase = URLBaseApiCabanas;
            string url = urlBase + id;
            var tarea = client.GetAsync(url);
            tarea.Wait();

            string body = LeerContenido(tarea.Result); //aca viene como json la cabañana o como string el error

            if (tarea.Result.IsSuccessStatusCode)
            {
                cabana = JsonConvert.DeserializeObject<CabanaViewModel>(body);
            }
            else
            {
                error = body;
            }

            return error;
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
            string url = URLBaseApiCabanas;
            Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
            tarea1.Wait();
            HttpResponseMessage respuesta = tarea1.Result;
            string body = LeerContenido(respuesta);


            if (respuesta.IsSuccessStatusCode)
            {
                List<CabanaViewModel> cabanas = JsonConvert.DeserializeObject<List<CabanaViewModel>>(body);
                return View(cabanas);
            }
            else
            {
                ViewBag.Error = body;
                return View(new List<CabanaViewModel>());
            }

        }


        public ActionResult Details(int id)
        {
            CabanaViewModel c = null;
            string error = FetchCabana(id, out c);

            if (error == "")
            {
                return View(c);
            }
            else
            {
                ViewBag.Mensaje = error;
                return View();
            }
        }


        //-------------------------------------------------------------------------------------
        //BÚSQUEDAS-----------------------------------------------------------------------------
        [HttpPost]
        public ActionResult BuscarPorNombre(string nombre) 
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }

            HttpClient client = new HttpClient();
            string urlBase = URLBaseApiCabanas;
            string url = urlBase + "FindByNombre/" + nombre;
            var tarea = client.GetAsync(url);
            tarea.Wait();

            string body = LeerContenido(tarea.Result);

            if (tarea.Result.IsSuccessStatusCode)
            {
                List<CabanaViewModel> cabanas = JsonConvert.DeserializeObject<List<CabanaViewModel>>(body);
                return View(cabanas);
            }
            else
            {
                ViewBag.NotFound = body;
                return View("ResultadoBusqueda",new List<CabanaViewModel>());
            }
            
        }

        [HttpGet]
        public ActionResult BuscarHabilitadas()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }

            HttpClient client = new HttpClient();
            string urlBase = URLBaseApiCabanas;
            string url = urlBase + "FinByHabilitadas";
            var tarea = client.GetAsync(url);
            tarea.Wait();

            string body = LeerContenido(tarea.Result);

            if (tarea.Result.IsSuccessStatusCode)
            {
                List<CabanaViewModel> cabanas = JsonConvert.DeserializeObject<List<CabanaViewModel>>(body);
                return View(cabanas);
            }
            else
            {
                ViewBag.NotFound = body;
                return View("ResultadoBusqueda", new List<CabanaViewModel>());
            }
        }

        [HttpPost]
        public ActionResult BuscarPorMaxHuespedes(int maxHuespedes)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }

            HttpClient client = new HttpClient();
            string urlBase = URLBaseApiCabanas;
            string url = urlBase + "FindByMaxHuespedes/" + maxHuespedes;
            var tarea = client.GetAsync(url);
            tarea.Wait();

            string body = LeerContenido(tarea.Result);

            if (tarea.Result.IsSuccessStatusCode)
            {
                List<CabanaViewModel> cabanas = JsonConvert.DeserializeObject<List<CabanaViewModel>>(body);
                return View(cabanas);
            }
            else
            {
                ViewBag.NotFound = body;
                return View("ResultadoBusqueda", new List<CabanaViewModel>());
            }
        }

        [HttpPost]
        public ActionResult BuscarPorTipo(int idTipo)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }

            HttpClient client = new HttpClient();
            string urlBase = URLBaseApiCabanas;
            string url = urlBase + "FindByTipo/" + idTipo;
            var tarea = client.GetAsync(url);
            tarea.Wait();

            string body = LeerContenido(tarea.Result);

            if (tarea.Result.IsSuccessStatusCode)
            {
                List<CabanaViewModel> cabanas = JsonConvert.DeserializeObject<List<CabanaViewModel>>(body);
                return View(cabanas);
            }
            else
            {
                ViewBag.NotFound = body;
                return View("ResultadoBusqueda", new List<CabanaViewModel>());
            }
        }


        //-------------------------------------------------------------------------------------------------------
        //CREATE-------------------------------------------------------------------------------------------------
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }

            //Traer los tipos:
            HttpClient client = new HttpClient();
            var tarea = client.GetAsync(URLBaseApiTipos);
            tarea.Wait();
            var tarea2 = tarea.Result.Content.ReadAsStringAsync();
            tarea2.Wait();

            if (tarea.Result.IsSuccessStatusCode)
            {
                List<TipoViewModel> tipos = JsonConvert.DeserializeObject<List<TipoViewModel>>(tarea2.Result);
                CabanaViewModel vm = new CabanaViewModel();
                {
                    Cabana = new CabanaDTO(),
                    Tipos = tipos
                };
                return View(librovm);
            }
            else
            {
                ViewBag.Mensaje = tarea2.Result;
                return View();
            }



            IEnumerable<Tipo> tipos= RepositorioTipo.FindAll();
            ViewBag.Tipos = tipos;
            CabanaViewModel vm = new CabanaViewModel();
            return View(vm);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CabanaViewModel vm, int idTipo)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }

            try
            {
                FileInfo fi = new FileInfo(vm.Foto.FileName);
                string extension = fi.Extension; //me quedo solo con la extension del archivo

                if (extension != ".png" && extension != ".jpg")
                {
                    throw new Exception("El archivo debe ser .png o .jpg");
                }
                string nomArchivoFoto = vm.Cabana.NombreCabana +"_001" + extension;

                Tipo tipo = RepositorioTipo.FindById(idTipo);
                vm.Cabana.Tipo = tipo;
                vm.Cabana.FotoCabana = nomArchivoFoto;
                CUAltaCabana.Alta(vm.Cabana);

                string rutaWwwRoot = WHE.WebRootPath;
                string rutaCarpeta = Path.Combine(rutaWwwRoot, "Imagenes"); //Genero la ruta hasta la carpeta
                string rutaArchivo = Path.Combine(rutaCarpeta, nomArchivoFoto); //Genero la ruta hasta la foto

                FileStream fs = new FileStream(rutaArchivo, FileMode.Create); //conecto el IFromFile (mi foto) a FileSystem de la maquina
                
                vm.Foto.CopyTo(fs);

                return RedirectToAction(nameof(Index));


            }
            catch (Exception ex)
            {
                IEnumerable<Tipo> tipos = RepositorioTipo.FindAll();
                ViewBag.Tipos = tipos;
                ViewBag.ErrorInfo=ex.Message;
                // Este if es para mostrar el error de unique
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Cannot insert duplicate key row in object")) 
                {
                    //ViewBag.ErrorInfo = " ";
                    ViewBag.ErrorUnique = "El nombre de cabaña ya existe";
                }
                return View();
            }
        }


        //-------------------------------------------------------------------------------------------------------
        //NO IMPLEMENTADOS-----------------------------------------------------------------------------------------

        // GET: CabanaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CabanaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CabanaController/Edit/5
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

        // GET: CabanaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CabanaController/Delete/5
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
    }
}
