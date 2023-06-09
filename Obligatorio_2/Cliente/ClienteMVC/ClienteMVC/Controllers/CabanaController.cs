﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using ClienteMVC.Models;
using ClienteMVC.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;
using System.Collections.Generic;
using NuGet.Common;
using System.Net.Http.Headers;

namespace ClienteMVC.Controllers
{
    public class CabanaController : Controller 
    {
        public IConfiguration Conf { get; set; }
        public IWebHostEnvironment WHE { set; get; }

        public string URLBaseApiCabanas { get; set; }
        public string URLBaseApiTipos { get; set; }

        public CabanaController(IConfiguration conf, IWebHostEnvironment whe)
        {
            Conf = conf;
            URLBaseApiCabanas = Conf.GetValue<string>("ApiCabanas");
            URLBaseApiTipos = Conf.GetValue<string>("ApiTipos");
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

       


        private string LeerContenido(HttpResponseMessage respuesta)
        {
            HttpContent contenido = respuesta.Content;
            Task<string> tarea2 = contenido.ReadAsStringAsync();
            tarea2.Wait();
            return tarea2.Result;
        }

        private HttpResponseMessage TraerTipos() 
        {
            HttpClient cliente = new HttpClient();
            string url = URLBaseApiTipos;
            Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
            tarea1.Wait();
            HttpResponseMessage respuesta = tarea1.Result;
            return respuesta;
        }



        //-------------------------------------------------------------------------------------
        //LISTADO-----------------------------------------------------------------------------
        public ActionResult Index()
        {
            //Traemos las cabanas
            HttpClient cliente = new HttpClient();
            string url = URLBaseApiCabanas;
            Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
            tarea1.Wait();
            HttpResponseMessage respuesta = tarea1.Result;
            string body = LeerContenido(respuesta);

            HttpResponseMessage respuestaTipos = TraerTipos(); //traemos los tipos para la búsqueda por tipos

            if (respuesta.IsSuccessStatusCode && respuestaTipos.IsSuccessStatusCode)
            {
                List<CabanaDTO> cabanas = JsonConvert.DeserializeObject<List<CabanaDTO>>(body);
                List<TipoViewModel> tipos1 = JsonConvert.DeserializeObject<List<TipoViewModel>>(LeerContenido(respuestaTipos));
                ViewBag.Tipos = tipos1;
                return View(cabanas);
            }
            else
            {
                ViewBag.Error = body;
                return View(new List<CabanaDTO>());
            }

        }




        //-------------------------------------------------------------------------------------
        //BÚSQUEDAS-----------------------------------------------------------------------------
        [HttpPost]
        public ActionResult BuscarPorNombre(string nombre) 
        {
           
            HttpClient client = new HttpClient();
            string urlBase = URLBaseApiCabanas;
            string url = urlBase + "FindByNombre/" + nombre;
            var tarea = client.GetAsync(url);
            tarea.Wait();

            string body = LeerContenido(tarea.Result);

            if (tarea.Result.IsSuccessStatusCode)
            {
                List<CabanaDTO> cabanas = JsonConvert.DeserializeObject<List<CabanaDTO>>(body);
                return View("ResultadoBusqueda",cabanas);
            }
            else
            {
                ViewBag.NotFound = body;
                return View("ResultadoBusqueda",new List<CabanaDTO>());
            }
            
        }

        [HttpGet]
        public ActionResult BuscarHabilitadas()
        {
            

            HttpClient client = new HttpClient();
            string urlBase = URLBaseApiCabanas;
            string url = urlBase + "FindByHabilitadas";
            var tarea = client.GetAsync(url);
            tarea.Wait();

            string body = LeerContenido(tarea.Result);

            if (tarea.Result.IsSuccessStatusCode)
            {
                List<CabanaDTO> cabanas = JsonConvert.DeserializeObject<List<CabanaDTO>>(body);
                return View("ResultadoBusqueda",cabanas);
            }
            else
            {
                ViewBag.NotFound = body;
                return View("ResultadoBusqueda", new List<CabanaDTO>());
            }
        }

        [HttpPost]
        public ActionResult BuscarPorMaxHuespedes(int maxHuespedes)
        {
           

            HttpClient client = new HttpClient();
            string urlBase = URLBaseApiCabanas;
            string url = urlBase + "FindByMaxHuespedes/" + maxHuespedes;
            var tarea = client.GetAsync(url);
            tarea.Wait();

            string body = LeerContenido(tarea.Result);

            if (tarea.Result.IsSuccessStatusCode)
            {
                List<CabanaDTO> cabanas = JsonConvert.DeserializeObject<List<CabanaDTO>>(body);
                return View("ResultadoBusqueda", cabanas);
            }
            else
            {
                ViewBag.NotFound = body;
                return View("ResultadoBusqueda", new List<CabanaDTO>());
            }
        }

        [HttpPost]
        public ActionResult BuscarPorTipo(int idTipo)
        {
           

            HttpClient client = new HttpClient();
            string urlBase = URLBaseApiCabanas;
            string url = urlBase + "FindByTipo/" + idTipo;
            var tarea = client.GetAsync(url);
            tarea.Wait();

            string body = LeerContenido(tarea.Result);

            if (tarea.Result.IsSuccessStatusCode)
            {
                List<CabanaDTO> cabanas = JsonConvert.DeserializeObject<List<CabanaDTO>>(body);
                return View("ResultadoBusqueda", cabanas);
            }
            else
            {
                ViewBag.NotFound = body;
                return View("ResultadoBusqueda", new List<CabanaDTO>());
            }
        }

        [HttpPost]
        public ActionResult BuscarMonto(int monto)
        {
            HttpClient client = new HttpClient();
            string url = URLBaseApiCabanas + "FindByMonto/" + monto;
            var tarea = client.GetAsync(url);
            tarea.Wait();
            string body = LeerContenido(tarea.Result);

            if (tarea.Result.IsSuccessStatusCode)
            {
                List<CabanaViewModelByMonto> cabanas = JsonConvert.DeserializeObject<List<CabanaViewModelByMonto>>(body);
                return View(cabanas);
            }
            else
            {
                ViewBag.NotFound = body;
                return View(new List<CabanaViewModelByMonto>());
            }
        }



        //-------------------------------------------------------------------------------------------------------
        //CREATE-------------------------------------------------------------------------------------------------
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("logeado") != "registrado") return RedirectToAction("login", "usuario");

            //Traer los tipos:
            HttpClient client = new HttpClient();
            var tarea = client.GetAsync(URLBaseApiTipos);
            tarea.Wait();
            var tarea2 = tarea.Result.Content.ReadAsStringAsync();
            tarea2.Wait();

            if (tarea.Result.IsSuccessStatusCode)
            {
                List<TipoViewModel> tiposCabana = JsonConvert.DeserializeObject<List<TipoViewModel>>(tarea2.Result);
                CabanaViewModel cabanaVM = new CabanaViewModel()
                {
                    Cabana = new CabanaDTO(),
                    Tipos = tiposCabana
                };
                return View(cabanaVM);
            }
            else
            {
                ViewBag.Mensaje = tarea2.Result;
                return View();
            }

        }

        
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create(CabanaViewModel vm)
        {
            
            try
            {
                string rutaWwwRoot = WHE.WebRootPath;
                string rutaCarpeta = Path.Combine(rutaWwwRoot, "Imagenes"); //Genero la ruta hasta la carpeta
                FileInfo fi = new FileInfo(vm.Foto.FileName);
                string extension = fi.Extension; //me quedo solo con la extension del archivo

                if (extension != ".png" && extension != ".jpg")
                {
                    throw new Exception("El archivo debe ser .png o .jpg");
                }

                string nomArchivoFoto = vm.Cabana.NombreCabana + "_001" + extension;
                string rutaArchivo = Path.Combine(rutaCarpeta, nomArchivoFoto); //Genero la ruta hasta la foto

                vm.Cabana.TipoId = vm.IdTipoSeleccionado;
                vm.Cabana.FotoCabana = nomArchivoFoto;

                HttpClient cliente = new HttpClient();

                cliente.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                var tarea = cliente.PostAsJsonAsync(URLBaseApiCabanas, vm.Cabana);
                tarea.Wait();
                

                HttpResponseMessage respuestaTipos = TraerTipos();
                List<TipoViewModel> tipos = JsonConvert.DeserializeObject<List<TipoViewModel>>(LeerContenido(respuestaTipos));
                vm.Tipos = tipos;

                if (tarea.Result.IsSuccessStatusCode)
                {
                    FileStream fs = new FileStream(rutaArchivo, FileMode.Create);
                    vm.Foto.CopyTo(fs);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var tarea2 = tarea.Result.Content.ReadAsStringAsync();
                    tarea2.Wait();
                    ViewBag.ErrorInfo = tarea2.Result; //Cuando Da error por la descripcion<10 pero larga OCURRIO ERROR INESPERADO
                    return View(vm);
                }

            }
            catch (Exception ex)
            {
                
                ViewBag.ErrorInfo=ex.Message;
                // Este if es para mostrar el error de unique
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Cannot insert duplicate key row in object")) 
                {
                    //ViewBag.ErrorInfo = " ";
                    ViewBag.ErrorUnique = "El nombre de cabaña ya existe";
                }
                return View(vm);
            }
        }









        //-------------------------------------------------------------------------------------------------------
        //NO IMPLEMENTADOS-----------------------------------------------------------------------------------------


        public ActionResult Details(int id)
        {
            return RedirectToAction(nameof(Index));
        }


        // GET: CabanaController/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
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
