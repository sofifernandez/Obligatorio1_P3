using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.CU;
using Aplicacion.InterfacesCU;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesDominio;
using System.IO;
using MVC.Models;
using System.Net.NetworkInformation;


namespace MVC.Controllers
{
    public class CabanaController : Controller
    {
        public IWebHostEnvironment WHE { set; get; } 
        IAltaCabana CUAltaCabana { get; set; } 
        IRepositorioCabana RepositorioCabana { get; set; }
        IRepositorioTipo RepositorioTipo { get; set; }

        public CabanaController(IAltaCabana cuAltaCabana, IRepositorioCabana repositorioCabana, IRepositorioTipo repositorioTipo, IWebHostEnvironment whe)
        {
            CUAltaCabana = cuAltaCabana;
            RepositorioCabana = repositorioCabana;
            RepositorioTipo = repositorioTipo;
            WHE = whe;
        }

        //-------------------------------------------------------------------------------------
        //LISTADO-----------------------------------------------------------------------------
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email"))) 
            {
                return Redirect("/Usuario/Login");
            }
            IEnumerable<Cabana> cabanas = RepositorioCabana.FindAll();
            ViewBag.Tipos= RepositorioTipo.FindAll();
            return View(cabanas);
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

            IEnumerable<Cabana> cabanas=RepositorioCabana.FindCabanaNombre(nombre);
            if (cabanas.Count()==0) 
            {
                ViewBag.NotFound = "No existen resultados";
            } 
            return View("ResultadoBusqueda", cabanas); 
            
        }

        [HttpGet]
        public ActionResult BuscarHabilitadas()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }

            IEnumerable<Cabana> cabanas = RepositorioCabana.FindCabanasHabilitadas();
            if (cabanas.Count() == 0)
            {
                ViewBag.NotFound = "No existen resultados";
            }
            return View("ResultadoBusqueda", cabanas);
        }

        [HttpPost]
        public ActionResult BuscarPorMaxHuespedes(int maxHuespedes)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            } 

            IEnumerable<Cabana> cabanas = RepositorioCabana.FindCabanaMax(maxHuespedes);
            if (cabanas.Count() == 0)
            {
                ViewBag.NotFound = "No existen resultados";
            }
            return View("ResultadoBusqueda", cabanas);
        }

        [HttpPost]
        public ActionResult BuscarPorTipo(int idTipo)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }

            IEnumerable<Cabana> cabanas = RepositorioCabana.FindCabanaTipo(idTipo);
            if (cabanas.Count() == 0)
            {
                ViewBag.NotFound = "No existen resultados";
            }
            return View("ResultadoBusqueda", cabanas);
        }


        //-------------------------------------------------------------------------------------------------------
        //CREATE-------------------------------------------------------------------------------------------------
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return Redirect("/Usuario/Login");
            }
            IEnumerable<Tipo> tipos= RepositorioTipo.FindAll();
            ViewBag.Tipos = tipos;
            AltaCabanaViewModel vm = new AltaCabanaViewModel();
            return View(vm);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaCabanaViewModel vm, int idTipo)
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
